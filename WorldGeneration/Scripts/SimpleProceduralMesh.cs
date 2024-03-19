using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))] //It creates those modifiers automatic 
public class SimpleProceduralMesh : MonoBehaviour
{
    private Mesh mesh;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreatePlane();
    }

    void CreatePlane()
    {
        mesh.vertices = new Vector3[]
        {
            new Vector3(0,0, 0),
            new Vector3(0,0, 1),
            new Vector3(1,0, 0),
            new Vector3(1,0, 1),
        };

        mesh.triangles = new int[] {
          0,1,2,
          2,1,3
        };
    }
}
