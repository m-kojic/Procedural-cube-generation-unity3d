using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProceduralCubeAnimated : MonoBehaviour
{
    public Text Vertices;
    public Text Triangles;
    public GameObject VertexPrefab;
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uvs;
    private Vector3[] normals;
    private uint numberOfVertices = 0; 
    private uint numberOfTriangles = 0; 
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        mesh.name = "Procedural Cube";

        vertices = new Vector3[24];
        triangles = new int[36];

        StartCoroutine(CreateMesh());
        //UpdateUNormals();
        UpdateUVs();
        UpdateMesh();
    }

    private void Update()
    {
        UpdateMesh();
        UpdateText();
    }

    private void UpdateText()
    {
        Vertices.text = numberOfVertices.ToString();
        Triangles.text = numberOfTriangles.ToString();
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

    private IEnumerator CreateMesh()
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

        //Bottom
        StartCoroutine(CreateVertex(0, v0, Vector3.down));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(1, v1, Vector3.down));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(2, v2, Vector3.down));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(3, v3, Vector3.down));
        yield return new WaitForSeconds(1);

        //Front
        StartCoroutine(CreateVertex(4, v0, Vector3.back));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(5, v4, Vector3.back));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(6, v7, Vector3.back));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(7, v3, Vector3.back));
        yield return new WaitForSeconds(1);

        //Right
        StartCoroutine(CreateVertex(8, v3, Vector3.right));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(9, v7, Vector3.right));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(10, v6, Vector3.right));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(11, v2, Vector3.right));
        yield return new WaitForSeconds(1);

        //Back
        StartCoroutine(CreateVertex(12, v2, Vector3.forward));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(13, v6, Vector3.forward));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(14, v5, Vector3.forward));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(15, v1, Vector3.forward));
        yield return new WaitForSeconds(1);

        //Left
        StartCoroutine(CreateVertex(16, v1, Vector3.left));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(17, v5, Vector3.left));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(18, v4, Vector3.left));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(19, v0, Vector3.left));
        yield return new WaitForSeconds(1);

        //Top
        StartCoroutine(CreateVertex(20, v4, Vector3.up));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(21, v5, Vector3.up));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(22, v6, Vector3.up));
        yield return new WaitForSeconds(1);
        StartCoroutine(CreateVertex(23, v7, Vector3.up));
        yield return new WaitForSeconds(1);


        //Triangles

        //This could easly be done in a loop but I wanted to show you every step in the process

        //Bottom
        triangles[0] = 3;
        triangles[1] = 1;
        triangles[2] = 0;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);
        triangles[3] = 3;
        triangles[4] = 2;
        triangles[5] = 1;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);

        //Front
        triangles[6] = 4;
        triangles[7] = 5;
        triangles[8] = 7;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);
        triangles[9] = 7;
        triangles[10] = 5;
        triangles[11] = 6;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);

        //Right
        triangles[12] = 8;
        triangles[13] = 9;
        triangles[14] = 11;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);
        triangles[15] = 11;
        triangles[16] = 9;
        triangles[17] = 10;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);

        //Back
        triangles[18] = 12;
        triangles[19] = 13;
        triangles[20] = 15;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);
        triangles[21] = 15;
        triangles[22] = 13;
        triangles[23] = 14;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);

        //Left
        triangles[24] = 16;
        triangles[25] = 17;
        triangles[26] = 19;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);
        triangles[27] = 19;
        triangles[28] = 17;
        triangles[29] = 18;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);

        //Top
        triangles[30] = 20;
        triangles[31] = 21;
        triangles[32] = 23;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);
        triangles[33] = 23;
        triangles[34] = 21;
        triangles[35] = 22;
        numberOfTriangles++;
        yield return new WaitForSeconds(1);

        UpdateUVs();

        //Remove Points
        foreach (Transform item in transform)
        {
            item.gameObject.SetActive(false);
        }
    }

    private IEnumerator CreateVertex(int index, Vector3 vertex, Vector3 direction)
    {
        yield return new WaitForSeconds(1f);
        vertices[index] = vertex;
        Instantiate(VertexPrefab, vertex, Quaternion.identity, transform);
        Debug.DrawRay(vertex, direction * 0.5f, Color.green, 1000);
        numberOfVertices++;
    }


}
