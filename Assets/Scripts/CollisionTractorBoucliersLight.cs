using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTractorBoucliersLight : MonoBehaviour
{

    private List<GameObject> _trees = new List<GameObject>();

    private MeshRenderer[] _treeRender;
    private float _coefCroissance = 0.3f;

    //
    public GameObject boucliers1;
    public GameObject boucliers2;
    public GameObject boucliers3;
  
    public static GameObject newObject;
    //

    //
    public Material materialLight1;
    public Material materialLight2;
    public Material materialLight3;
    
    private GameObject _parcelle;
    private Renderer _parcelleRender;
    //


    //
    private List<GameObject> _tractors = new List<GameObject>();
    private MeshRenderer[] _tractorRender;
    //

    
    private bool _hit;

    void Start()
    {
        
        //
        _tractors = GameObject.FindGameObjectsWithTag("tractor").ToList();
        _tractorRender = new MeshRenderer[_tractors.Count];
        for (int i = 0; i < _tractors.Count; i++)
            _tractorRender[i] = _tractors[i].GetComponent<MeshRenderer>();
        //
       
        //Pour faire spawn dès le début les boucliers 2
        newObject = Instantiate(boucliers2, ARManagerBoucliersLight._newParcelle.transform.position, ARManagerBoucliersLight._newParcelle.transform.rotation);
        newObject.transform.SetParent(ARManagerBoucliersLight._newParcelle.transform);
        //

        //
        _parcelle = GameObject.FindGameObjectWithTag("parcelle");
        _parcelleRender = _parcelle.GetComponent<Renderer>();
        //
        
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

           
            //
            if (_coefCroissance == 0.3f){
                print("if 1");
                
                if (newObject != null)
                    Destroy(newObject);
                
                SpawnPrefab(boucliers1);
                _parcelleRender.material = materialLight1;

            }
            if (_coefCroissance == 0.4f){
                print("if 2");
                
                if (newObject != null)
                    Destroy(newObject);
                
                SpawnPrefab(boucliers2);
                _parcelleRender.material = materialLight2;             
            }
            if (_coefCroissance == 0.5f){
                print("if 3");
                
                if (newObject != null)
                    Destroy(newObject);
                    _parcelleRender.material = materialLight3;
                
                SpawnPrefab(boucliers3);   
            }
            //


                
        });


        var ptille = GameObject.FindGameObjectsWithTag("Ptille");
        foreach(var x  in ptille){
            x.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
    }

    private void Update()
    {
        /*
        _hit = false;
        Vector3 pointOne = gameObject.transform.position;
        for (int t = 0; t < _trees.Count; t++)
        {
            float distance = Vector3.Distance(_trees[t].transform.position, pointOne);

            _treeRender[t].material.color = Color.white;

            if (distance < 0.03f * Tractors.SizeMulti * _coefCroissance)
            {
                if (!Tractors.TractorInitialisation)
                {
                    _hit = true;
                    break;
                }
                
                _treeRender[t].GetComponent<MeshRenderer>().material.color = Color.red;

                
                return;

            }
        }
*/
         
    }

    List<GameObject> trigger = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.CompareTag("tree")){

            if (TractorsBoucliersLight.TractorInitialisation){
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;

                //
                for (int i = 0; i < _tractors.Count; i++)
                    _tractors[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                //    


            }else{
            ptill();
            }
                
        }

         if (TractorsBoucliersLight.TractorInitialisation)
            return;

         if (other.gameObject.CompareTag("Ptille"))
        {
            trigger.Add(other.gameObject);
        }
    }

    void ptill(){
        foreach(var x in trigger){
            print(x.name);
            if(x.gameObject.CompareTag("Ptille"))
                    x.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("tree")){
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

            //
            for (int i = 0; i < _tractors.Count; i++)
                _tractors[i].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            //    


        }
        if(other.gameObject.CompareTag("Ptille")){
            trigger.Remove(other.gameObject);
        }

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

    //
     public void SpawnPrefab(GameObject prefab)
    {
        newObject = Instantiate(prefab, ARManagerBoucliersLight._newParcelle.transform.position, ARManagerBoucliersLight._newParcelle.transform.rotation);
        newObject.transform.SetParent(ARManagerBoucliersLight._newParcelle.transform);
    }
    //

}
