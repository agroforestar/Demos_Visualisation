using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Tractors : MonoBehaviour
{
    private List<GameObject> _anglesTractor = new List<GameObject>();
    
    public GameObject _tractorPrefab;
    private GameObject _newtractor;
    
    private GameObject _newParcelle;
    private GameObject _sizePanel;
    private GameObject _panel;

    private bool _spawnTractor;
    private bool _tractorMove;
    public static bool TractorInitialisation;

    private int _tractorTargetAngles;

    private Camera _camera;

    public static float SizeMulti = 1;
    
    [SerializeField] GameObject _pTille;

    // Start is called before the first frame update
    void Start()
    {
        _sizePanel = GameObject.Find("SizePanel");
        _panel = GameObject.Find("Panel");
        
        _sizePanel.SetActive(false);
        _panel.SetActive(false);
        
        _camera = FindObjectOfType<Camera>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_spawnTractor)
            return;
        
        if (Input.touchCount < 1)
            return;
        
        Touch touch = Input.GetTouch(0);

        Ray touchPos = _camera.ScreenPointToRay(touch.position);
        RaycastHit hit;
        switch (touch.phase)
        {
            case TouchPhase.Moved:
                if (Physics.Raycast(touchPos, out hit))
                {
                    if (hit.transform.gameObject.name.Contains("Parcelle"))
                    {
                        Vector3 pos = hit.point;
                        var anchor = MoveTractor(pos);
                        _newtractor.transform.localPosition = anchor.transform.localPosition;
                        _newtractor.transform.rotation = anchor.transform.rotation;
                        _tractorMove = false;
                    }
                }
                break;
        }

    }

    public void GetAnglesFromParcelle()
    {
        _anglesTractor.Clear();
        _newParcelle = ARManager._newParcelle;
        
        int childCount = _newParcelle.transform.childCount;
        
        for (int i = 0; i < childCount; i++)
        {
            if(char.IsDigit(_newParcelle.transform.GetChild(i).name[0]))
                _anglesTractor.Add(_newParcelle.transform.GetChild(i).gameObject);
        }
        _anglesTractor = _anglesTractor.OrderBy(x => int.Parse(x.name)).ToList();
        
        List<Vector3> listVectors = new List<Vector3>();
        foreach (var angles in _anglesTractor)
            listVectors.Add(angles.transform.position);
        
        var interpolatedPoints = Interpolation(50, listVectors);
        SpawnPtille(interpolatedPoints);
    }

    GameObject MoveTractor(Vector3 actualPosition)
    {
        float distance = Single.PositiveInfinity;
        GameObject nearestPosition = null;

        foreach (var anchor in _anglesTractor)
        {
            var newDistance = Vector3.Distance(anchor.transform.position, actualPosition);

            if (newDistance < distance)
            {
                distance = newDistance;
                nearestPosition = anchor;
                _tractorTargetAngles = _anglesTractor.IndexOf(anchor);
            }
        }

        return nearestPosition;
    }

    public void AddTractors()
    {
        if(!_spawnTractor)
        {
            _sizePanel.SetActive(true);
        }
        else
        {
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Ajouter tracteur";
            GameObject.Find("AddTractor").GetComponent<Image>().sprite = Resources.Load<Sprite>("d_iconaddedlocal@2x");

            _tractorMove = false;
            _spawnTractor = false;
            Destroy(_newtractor);
        }
    }

    public void PlayAndStop()
    {
        if (!_spawnTractor)
            return;

        if (!TractorInitialisation)
            return;
        
        _tractorMove = !_tractorMove;
        
        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text = _tractorMove ? "Stop" : "Play";

        if (_tractorMove)
            _newtractor.GetComponent<Animator>().enabled = true;
        else
            _newtractor.GetComponent<Animator>().enabled = false;
        
        StartCoroutine(TractorMovement());
    }

    public void SpawnTractor()
    {
        var button = GameObject.Find("AddTractor");

        button.GetComponent<Image>().sprite = Resources.Load<Sprite>("IconHide");
        button.GetComponentInChildren<TextMeshProUGUI>().text = "Supprimer tracteur";
        
        SizeMulti = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        _tractorTargetAngles = 0;
        
        _newtractor = Instantiate(_tractorPrefab, _newParcelle.transform);
        _newtractor.transform.position = _anglesTractor[0].transform.position;
        _newtractor.transform.rotation = _anglesTractor[0].transform.rotation;
        _newtractor.transform.localScale *= SizeMulti;
        
        _spawnTractor = true;
        _sizePanel.SetActive(false);

        foreach (var renderer in  _newtractor.GetComponentsInChildren<MeshRenderer>())
            renderer.enabled = false;

        TractorInitialisation = false;
        _tractorMove = true;
        
        StartCoroutine(TractorMovement());
    }

    IEnumerator TractorMovement()
    {
        float speed = TractorInitialisation ? 0.25f : 0.75f;

        if (!_spawnTractor)
            yield return null;
        
        while (_tractorMove)
        {
            if (_tractorTargetAngles >= _anglesTractor.Count - 1)
            {
                _tractorTargetAngles = 0;
                _newtractor.transform.position = _anglesTractor[_tractorTargetAngles].transform.position;
                
                if (!TractorInitialisation)
                    _tractorMove = false;
            }
        
            var position = _newtractor.transform.position;
            position = Vector3.MoveTowards(position, _anglesTractor[_tractorTargetAngles+1].transform.position, Time.deltaTime * speed);
            _newtractor.transform.position = position;
            
            _newtractor.transform.rotation = Quaternion.Lerp(_newtractor.transform.rotation, _anglesTractor[_tractorTargetAngles + 1].transform.rotation, Time.deltaTime * 7);
            
            float distance = Vector3.Distance(position, _anglesTractor[_tractorTargetAngles+1].transform.position);
          
            if (distance < 0.001f)
                _tractorTargetAngles++;
            yield return null;
        }
        if (!TractorInitialisation)
        {
            foreach (var renderer in _newtractor.GetComponentsInChildren<MeshRenderer>())
                renderer.enabled = true;

            TractorInitialisation = true;
        }
    }

    private void SpawnPtille(List<Vector3> pTillePos)
    {
        foreach (var position in pTillePos)
        {
            var p = Instantiate(_pTille, _newParcelle.transform);
            p.transform.position = position;
            
        }
    }

    private List<Vector3> Interpolation(float distance, List<Vector3> vectors)
    {
        List<Vector3> points = new List<Vector3>();

        float totalDistance = 0f;
        float interval;
        
        if(vectors.Count < 2)
        {
            print("Error only two vectors");
            return points;
        }
        
        for (int i = 1; i < vectors.Count; i++)
        {
            totalDistance += Vector3.Distance(vectors[i - 1], vectors[i]);
        }
        interval = totalDistance / distance;
        List<float> maxPoints =  new List<float>();
        for (int i = 1; i < vectors.Count; i++)
        {
            float dist = Vector3.Distance(vectors[i - 1], vectors[i]);
            maxPoints.Add(Mathf.FloorToInt(dist / interval));
        }

        for (int i = 0; i < vectors.Count-2; i++)
        {
            for (int j = 0; j < maxPoints[i]; j++)
            {
                float val = (maxPoints[i] - j) / maxPoints[i];
                var vector = Vector3.Lerp(vectors[i], vectors[i + 1], val);
                points.Add(vector);
            }
        }
        return points;
    }

}
