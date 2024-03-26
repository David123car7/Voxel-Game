using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VoxelData
{
    public static float3[] voxelVerts = new float3[] {

        new float3(0f, 0f, 0f), 
        new float3(1f, 0f, 0f),
        new float3(1f, 1f, 0f),
        new float3(0f, 1f, 0f),

        new float3(0f, 0f, 1f),
        new float3(1f, 0f, 1f),
        new float3(1f, 1f, 1f),
        new float3(0f, 1f, 1f),
    };

    public static float2[] voxelTexCoord0 = new float2[] {
        new float2(0f, 0f),
        new float2(1f, 0f),
        new float2(1f, 0f),
        new float2(0f, 0f),
        new float2(0f, 1f),
        new float2(1f, 1f),
        new float2(1f, 1f),
        new float2(0f, 1f),
    };

    public static int3[] voxelTris = new int3[] {

        new int3(0, 3, 1), // Back Face
        new int3(1, 3, 2), // Back Face

        new int3(5, 6, 4), // Front Face
        new int3( 4, 6, 7), // Front Face

        new int3(3, 7, 2), // Top Face
        new int3(2, 7, 6), // Top Face

        new int3(1, 5, 0), // Bottom Face
        new int3(0, 5, 4), // Bottom Face

        new int3(4, 7, 0), // Left Face
        new int3(0, 7, 3), // Left Face

        new int3(1, 2, 5), // Right Face
        new int3(5, 2, 6), // Right Face
	};

    public static readonly float2[] voxelUvs = new float2[6] {

        new Vector2 (0f, 0f),
        new Vector2 (0f, 1f),
        new Vector2 (1f, 0f),
        new Vector2 (1f, 0f),
        new Vector2 (0f, 1f),
        new Vector2 (1f, 1f)

    };


}
