using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionTractor : MonoBehaviour
{

    private List<GameObject> trees = new List<GameObject>();

    private Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        trees = GameObject.FindGameObjectsWithTag("tree").ToList();
        var original =  GameObject.Find("Manager").GetComponent<Tractors>().texturePath;
        texture = new Texture2D(original.width, original.height, original.format, false);
        texture.SetPixels(original.GetPixels());
        texture.Apply();
        ARManager._newParcelle.GetComponent<Renderer>().material.mainTexture = texture;
    }

    private void Update()
    {
        foreach (var tree in trees)
        {
            Vector3 pointOne = gameObject.transform.position;

            float distance = Vector3.Distance(tree.transform.position, pointOne);

            tree.GetComponent<MeshRenderer>().material.color = Color.white;
            if(distance < 0.05f * Tractors.SizeMulti)
            {
                tree.GetComponent<MeshRenderer>().material.color = Color.red;
                if(!Tractors.TractorInitialisation)
                    SetTextureRed();
            }
            
        }
    }

    void SetTextureRed()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        
        if (Physics.Raycast(ray, out hit))
        {
            MeshRenderer renderer = hit.collider.GetComponent<MeshRenderer>();
            if (renderer == null) return;

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

            int x = Mathf.FloorToInt(uv.x * texture.width);
            int y = Mathf.FloorToInt(uv.y * texture.height);
            int width = 40;
            int height = 40;
            
            int xMin = Mathf.RoundToInt(x - width / 2.0f);
            int yMin = Mathf.RoundToInt(y - height / 2.0f);
            int xMax = xMin + width;
            int yMax = yMin + height;

            for (int i = xMin; i < xMax; i++) {
                for (int j = yMin; j < yMax; j++) {
                    texture.SetPixel(i, j, Color.red);
                }
            }
            texture.Apply();
        }
        
       
    }
    
}
