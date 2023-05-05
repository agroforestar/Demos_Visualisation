using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTractor : MonoBehaviour
{

    private List<GameObject> _trees = new List<GameObject>();

    private MeshRenderer[] _treeRender;
    private bool _hit;

    void Start()
    {
        _trees = GameObject.FindGameObjectsWithTag("tree").ToList();
        _treeRender = new MeshRenderer[_trees.Count];
        
        for (int i = 0; i < _trees.Count; i++)
            _treeRender[i] = _trees[i].GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        _hit = false;
        Vector3 pointOne = gameObject.transform.position;
        for (int t = 0; t < _trees.Count; t++)
        {
            float distance = Vector3.Distance(_trees[t].transform.position, pointOne);

            _treeRender[t].material.color = Color.white;

            if (distance < 0.05f * Tractors.SizeMulti)
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
    }


    private void OnTriggerEnter(Collider other)
    {
        if (Tractors.TractorInitialisation)
            return;
        
        if (other.gameObject.CompareTag("Ptille"))
        {
            if(_hit)
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            else
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
    }

}
