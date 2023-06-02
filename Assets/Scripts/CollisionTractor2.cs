using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollisionTractor2 : MonoBehaviour
{

    private List<GameObject> _trees = new List<GameObject>();

    private MeshRenderer[] _treeRender;
    private float _coefCroissance = 0.6f;

    
    private bool _hit;

    void Start()
    {
        _trees = GameObject.FindGameObjectsWithTag("tree").ToList();
        _treeRender = new MeshRenderer[_trees.Count];
        for (int i = 0; i < _trees.Count; i++)
            _treeRender[i] = _trees[i].GetComponent<MeshRenderer>();
        
        var slider = GameObject.Find("SliderCroissance").GetComponent<Slider>();
        
        _coefCroissance = (int)slider.value == 0 ? 0.6f : (int)slider.value == 1 ? 0.8f : 1.2f;
        var scale = slider.value == 0 ? 0.4f : _coefCroissance;
        
        foreach (var tree in _trees)
        {
            tree.transform.localScale = new Vector3(scale, scale, scale);
        }
        slider.onValueChanged.AddListener((value) =>
        {
            _coefCroissance = (int)value == 0 ? 0.6f : (int)value == 1 ? 0.8f : 1.2f;
            var taille = value == 0 ? 0.4f : _coefCroissance;
            foreach (var tree in _trees)
            {
                tree.transform.localScale = new Vector3(taille, taille, taille);
            }
                
            GameObject.Find("Manager").GetComponent<Tractors2>().StartTractorInit();
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

            if (Tractors2.TractorInitialisation){
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }else{
            ptill();
            }
                
        }

         if (Tractors2.TractorInitialisation)
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
        }
        if(other.gameObject.CompareTag("Ptille")){
            trigger.Remove(other.gameObject);
        }

    }

}
