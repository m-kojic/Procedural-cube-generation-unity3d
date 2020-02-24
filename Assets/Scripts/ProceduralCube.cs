using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralCube : MonoBehaviour
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
        UpdateUNormals();
        UpdateUVs();
        UpdateMesh();
    }

    private void UpdateUNormals()
    {
        var Bottom = new Vector3(0, -1, 0);
        var Front = new Vector3(0, 0, -1);
        var Right = new Vector3(1, 0, 0);
        var Back = new Vector3(0, 0, 1);
        var Left = new Vector3(-1, 0, 0);
        var Top = new Vector3(0, 1, 0);

        normals = new Vector3[]
        {
            //Bottom normals
            Bottom, Bottom, Bottom, Bottom,
            //Front normals
            Front, Front, Front, Front,
            //Right normals
            Right, Right, Right, Right,
            //Back normals
            Back, Back, Back, Back,
            //Left normals
            Left, Left, Left, Left,
            //Top normals
            Top, Top, Top, Top
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
            uv01, uv00, uv10, uv11,
            //Front vertices
            uv00, uv01, uv11, uv10,
            //Right vertices
            uv00, uv01, uv11, uv10,
            //Back vertices
            uv00, uv01, uv11, uv10,
            //Left vertices
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
        //mesh.normals = normals; //Unity can recalculate normals for you if you use mesh.RecalculateNormals(); but you can uncomment this line if you want to set normals manually
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

        meshFilter.mesh = mesh;
    }

    private void CreateMesh()
    {

        //Bottom vertices
        var v0 = new Vector3(0, 0, 0);
        var v1 = new Vector3(0, 0, 1);
        var v2 = new Vector3(1, 0, 1);
        var v3 = new Vector3(1, 0, 0);

        //Top vertices
        var v4 = new Vector3(0, 1, 0);
        var v5 = new Vector3(0, 1, 1);
        var v6 = new Vector3(1, 1, 1);
        var v7 = new Vector3(1, 1, 0);

        //Vertices
        vertices = new Vector3[] {
            //Bottom
            v0, v1, v2, v3,
            //Front
            v0, v4, v7, v3,
            //Right
            v3, v7, v6, v2,
            //Back
            v2, v6, v5, v1,
            //Left
            v1, v5, v4, v0,
            //Top
            v4, v5, v6, v7
        };


        //Triangles 
        triangles = new int[] {
            //Bottom
            3, 1, 0,
            3, 2, 1,
            //Front
            4, 5, 7,
            7, 5, 6,
            //Right
            8, 9, 11,
            11, 9, 10,
            //Back
            12, 13, 15,
            15, 13, 14,
            //Left
            16, 17, 19,
            19, 17, 18,
            //Top
            20, 21, 23,
            23, 21, 22
        };
    }
}
