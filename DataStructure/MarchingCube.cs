using System;
using System.Collections.Generic;
using UnityEngine;

namespace pxg.DataStructure
{
    public class MarchingCube
    {
        public MarchingCube(List<Vector3> p, List<double> v)
        {
            Points = p;
            Values = v;
        }

        public List<Vector3> Points { get; set; }

        public List<double> Values { get; set; }
    }
}
