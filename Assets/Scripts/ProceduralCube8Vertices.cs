using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCube8Vertices : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uvs;
    private Vector3[] normals;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        mesh.name = "Procedural Cube";

        CreateMesh();
        UpdateUVs();
        UpdateUNormals();
        UpdateMesh();
    }

    private void UpdateUNormals()
    {
        var Down = new Vector3(0, -1, 0);
        var Up = new Vector3(0, 1, 0);
        normals = new Vector3[]
        {
            //Bottom vertices
            Down, Down, Down, Down,

            //Top vertices
            Up, Up, Up, Up
        };
    }

    private void UpdateUVs()
    {
        var uv00 = new Vector2(0, 0);
        var uv10 = new Vector2(1, 0);
        var uv01 = new Vector2(0, 1);
        var uv11 = new Vector2(1, 1);

        uvs = new Vector2[]
        {
            //Bottom vertices
            uv00, uv01, uv11, uv10,

            //Top vertices
            uv00, uv01, uv11, uv10
        };
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uvs;
        //mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

        meshFilter.mesh = mesh;
    }

    private void CreateMesh()
    {
        //Vertices
        vertices = new Vector3[] {
            //Bottom vertices
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 0, 0),

            //Top vertices
            new Vector3(0, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 1, 0)
        };


        //Triangles 
        triangles = new int[] {
            //Front
            0, 4, 3,
            3, 4, 7,

            //Right
            3, 7, 2,
            2, 7, 6,

            //Back
            2, 6, 1,
            1, 6, 5,

            //Left
            1, 5, 0,
            0, 5, 4,

            //Bottom - Counter-clockwise
            3, 1, 0,
            3, 2, 1,
            
            //Top
            4, 5, 7,
            7, 5, 6
        };
    }
}
