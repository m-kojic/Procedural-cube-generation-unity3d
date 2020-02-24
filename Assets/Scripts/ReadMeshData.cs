using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadMeshData : MonoBehaviour
{
    MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        var uvs = meshFilter.mesh.uv;
        var vertices = meshFilter.mesh.vertices;
        var triangles = meshFilter.mesh.triangles;
        var normals = meshFilter.mesh.normals;
        Debug.Log(meshFilter.mesh.uv);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
