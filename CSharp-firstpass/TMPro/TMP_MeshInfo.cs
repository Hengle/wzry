﻿namespace TMPro
{
    using System;
    using System.Runtime.InteropServices;
    using UnityEngine;

    [StructLayout(LayoutKind.Sequential)]
    public struct TMP_MeshInfo
    {
        public Vector3[] vertices;
        public Vector2[] uv0s;
        public Vector2[] uv2s;
        public Color32[] vertexColors;
        public Vector3[] normals;
        public Vector4[] tangents;
        public UIVertex[] uiVertices;
        public UIVertex[][] meshArrays;
    }
}

