using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARManagerLight : MonoBehaviour
{

    private GameObject USER;

    private ARPlaneManager _planeManager;
    private ARAnchorManager _anchorManager;
    private ARRaycastManager _arRaycastManager;

    [SerializeField] private GameObject parcelle;
    [SerializeField] private GameObject cursor;
    [SerializeField] private TextMeshProUGUI adviceText;

    public GameObject _newParcelle;
    
    private GameObject _panel;
    private GameObject _panelLegend;
    private GameObject _instantiateButton;
    
    private bool _validPos;

    List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        
        USER = FindObjectOfType<ARCameraManager>().transform.parent.gameObject;
        _planeManager = FindObjectOfType<ARPlaneManager>();
        _anchorManager = FindObjectOfType<ARAnchorManager>();
        _arRaycastManager = FindObjectOfType<ARRaycastManager>();
        
        _panel = GameObject.Find("Panel");
        _panelLegend = GameObject.Find("PanelLegend");
        _panelLegend.SetActive(false);
        _panel.SetActive(false);

        _instantiateButton = GameObject.Find("InstantiateButton");

        print(USER.name);
        s_Hits.Clear();
        StartCoroutine(InstantiateVisualisation());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValidPosition() => _validPos = true;

    IEnumerator InstantiateVisualisation()
    {
        ARPlane plane = null;
        float lastDistance = Single.PositiveInfinity;
        
        do
        {
            if (s_Hits.Count > 0)
            {
                adviceText.text = "";
                _instantiateButton.SetActive(true);
            }
            else
            {
                adviceText.text = "Veuillez avoir une surface plane en face de vous";
                _instantiateButton.SetActive(false);
            }
            
            if (_arRaycastManager.Raycast(USER.GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), s_Hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = s_Hits[0].pose;
                var hitTrackableId = s_Hits[0].trackableId;
                var hitPlane = _planeManager.GetPlane(hitTrackableId);

                cursor.transform.position = hitPose.position;
                
                plane = hitPlane;
            }

            yield return new WaitForEndOfFrame();
        } while (!_validPos);
        
        print("Instantiate parcelle");

        Vector3 position = cursor.transform.position;
        position.y += 0.085f;
        
        ARAnchor anchor = _anchorManager.AttachAnchor(plane, new Pose(position, cursor.transform.rotation));
        _newParcelle = Instantiate(parcelle, anchor.transform);
        
        _panel.SetActive(true);
        _panelLegend.SetActive(true);
        
        Destroy(cursor);
        Destroy(adviceText);
        Destroy(GameObject.Find("CursorImage"));
        Destroy(GameObject.Find("InstantiateButton"));
        
        transform.GetComponent<Tractors>().GetAnglesFromParcelle();
    }
}
