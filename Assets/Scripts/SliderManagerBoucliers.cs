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
using System.Globalization;

public class SliderManagerBoucliers : MonoBehaviour
{

    private List<GameObject> _trees = new List<GameObject>();

    private MeshRenderer[] _treeRender;
    private float _coefCroissance = 0.3f;

    /*
    public Material materialLight1;
    public Material materialLight2;
    public Material materialLight3;
    */

    public GameObject boucliers1;
    public GameObject boucliers2;
    public GameObject boucliers3;
  
    public GameObject newObject;
    
    /*
    private GameObject _parcelle;
    private Renderer _parcelleRender;
    */

    void Start()
    {
        
        /*
        _parcelle = GameObject.FindGameObjectWithTag("parcelle");
        _parcelleRender = _parcelle.GetComponent<Renderer>();
        */
        
        //Pour faire spawn dès le début les boucliers 2
        newObject = Instantiate(boucliers2, ARManager._newParcelle.transform.position, ARManager._newParcelle.transform.rotation);
        newObject.transform.SetParent(ARManager._newParcelle.transform);
        

        _trees = GameObject.FindGameObjectsWithTag("tree").ToList();
        _treeRender = new MeshRenderer[_trees.Count];
        for (int i = 0; i < _trees.Count; i++)
            _treeRender[i] = _trees[i].GetComponent<MeshRenderer>();
        
        var slider = GameObject.Find("SliderCroissance").GetComponent<Slider>();
        
        _coefCroissance = (int)slider.value == 0 ? 0.3f : (int)slider.value == 1 ? 0.4f : 0.5f;
        var scale = slider.value == 0 ? 0.3f : _coefCroissance; 

        
        foreach (var tree in _trees)
        {
            tree.transform.localScale = new Vector3(scale, scale, scale);
        }
        slider.onValueChanged.AddListener((value) =>
        {
            _coefCroissance = (int)value == 0 ? 0.3f : (int)value == 1 ? 0.4f : 0.5f;
            var taille = value == 0 ? 0.3f : _coefCroissance;
        
            StopAllCoroutines();
            foreach (var tree in _trees)
            {
                StartCoroutine(ChangeTaille(tree, taille));
            }

            if (_coefCroissance == 0.3f){
                if (newObject != null)
                    Destroy(newObject);
                
                SpawnPrefab(boucliers1);
            }
            if (_coefCroissance == 0.4f){
                if (newObject != null)
                    Destroy(newObject);
                
                SpawnPrefab(boucliers2);             
            }
            if (_coefCroissance == 0.5f){
                if (newObject != null)
                    Destroy(newObject);
                
                SpawnPrefab(boucliers3);   
            }
      
        });

    }
    
    IEnumerator ChangeTaille(GameObject go, float scale){
        float desriedTime = 2f;
        float actualTime = 0f;

        while(desriedTime > actualTime){

            go.transform.localScale = Vector3.Lerp(go.transform.localScale, new Vector3(scale, scale, scale), actualTime/desriedTime);
            actualTime += Time.deltaTime;

            yield return null;
        }

    }

    private void Update()
    {
       /*
        if (_coefCroissance == 0.3f){
            _parcelleRender.material = materialLight1;
            }
        if (_coefCroissance == 0.4f){
            _parcelleRender.material = materialLight2;
            }
        if (_coefCroissance == 0.5f){
            _parcelleRender.material = materialLight3;
            }
        */
    }
  
  public void SpawnPrefab(GameObject prefab)
    {
        newObject = Instantiate(prefab, ARManager._newParcelle.transform.position, ARManager._newParcelle.transform.rotation);
        newObject.transform.SetParent(ARManager._newParcelle.transform);
    }

}
