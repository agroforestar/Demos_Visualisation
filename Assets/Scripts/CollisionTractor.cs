using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTractor : MonoBehaviour
{

    private List<GameObject> _trees = new List<GameObject>();
    private readonly List<RaycastHit> _positions = new List<RaycastHit>();

    private Texture2D _texture;

    private MeshRenderer[] _treeRender;
    
    void Start()
    {
        _positions.Clear();
        _trees = GameObject.FindGameObjectsWithTag("tree").ToList();
        var original =  GameObject.Find("Manager").GetComponent<Tractors>().texturePath;
        _texture = new Texture2D(original.width, original.height, original.format, false);
        _texture.SetPixels(original.GetPixels());
        _texture.Apply();
        ARManager._newParcelle.GetComponent<Renderer>().material.mainTexture = _texture;
        _treeRender = new MeshRenderer[_trees.Count];
        for (int i = 0; i < _trees.Count; i++)
        {
            _treeRender[i] = _trees[i].GetComponent<MeshRenderer>();
        }
    }

    public IEnumerator AnalysePath()
    {
        RaycastHit hit = new RaycastHit();
        MeshRenderer renderer = null;

        if (!Tractors.TractorInitialisation)
        {
            Ray ray = new Ray(transform.position, -transform.up);

            if (Physics.Raycast(ray, out hit))
                renderer = hit.collider.GetComponent<MeshRenderer>();
        }

        Vector3 pointOne = gameObject.transform.position;

        for (int t = 0; t < _trees.Count; t++)
        {
            float distance = Vector3.Distance(_trees[t].transform.position, pointOne);

            _treeRender[t].material.color = Color.white;

            if (distance < 0.05f * Tractors.SizeMulti)
            {
                if (!Tractors.TractorInitialisation)
                {
                    if (renderer != null)
                        _positions.Add(hit);
                }
                else
                    _treeRender[t].GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
        yield return null;
    }

    public void SetTextureRed()
    {
        print(_positions.Count);
        
        int width = 150;
        int height = 150;
        
        foreach (var hit in _positions)
        {
            Mesh mesh = hit.collider.GetComponent<MeshFilter>().mesh;
            Vector2[] uvs = mesh.uv;
            int[] triangles = mesh.triangles;
            Vector3 barycentric = hit.barycentricCoordinate;
            int triangleIndex = hit.triangleIndex;
            Vector2 uv = Vector2.zero;
            for (int i = 0; i < 3; i++)
            {
                uv += uvs[triangles[triangleIndex * 3 + i]] * barycentric[i];
            }

            int x = Mathf.FloorToInt(uv.x * _texture.width);
            int y = Mathf.FloorToInt(uv.y * _texture.height);
        
            int xMin = Mathf.RoundToInt(x - width / 2.0f);
            int yMin = Mathf.RoundToInt(y - height / 2.0f);
            int xMax = xMin + width;
            int yMax = yMin + height;

            for (int i = xMin; i < xMax; i++) {
                for (int j = yMin; j < yMax; j++) {
                    _texture.SetPixel(i, j, Color.red);
                }
            }
        }
        _texture.Apply();
    }
    
}
