using System;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

namespace pxg.DataStructure
{
    public class Mesh
    {
        public List<Vector3> Vertices { get; set; }
        public List<int> Triangles { get; set; }

        public void createTriangle(List<Vector3> points, List<float> values, float tau)
        {
            var caseIndex = 0;
            for (var i = 0; i < values.Count; i++)
            {
                if (values[i] > tau)
                {
                    caseIndex += (int) Math.Pow(2, i);
                }
            }
            
            var edges = new int[15];
            Array.Copy(CaseDictionary.Faces, caseIndex * 15, edges, 0, 15);

            foreach (var e in edges)
            {
                if (e == -1) continue;
                
                var p1i = EdgeToPoint.getPointIndices(e)[0];
                var p2i = EdgeToPoint.getPointIndices(e)[1];

                var p = ComputePosition(points[p1i], points[p2i], values[p1i], values[p2i], tau);
                Vertices.Add(Vertices.Contains(p) ? Vertices[Vertices.IndexOf(p)] : p);
            }
        }

        private Vector3 ComputePosition(Vector3 p1, Vector3 p2, float v1, float v2, float tau)
        {
            var t = (tau - v1) / (v2 - v1);
            var p = new Vector3();
            p = p + (p1 * (1 - t));
            p = p + (p2 * t);

            return p;
        }
    }
}