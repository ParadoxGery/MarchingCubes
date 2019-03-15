using System;
using System.Collections.Generic;
using UnityEngine;

namespace pxg.DataStructure
{
    public class MarchingCube
    {
        public MarchingCube(List<Vector3> p, Chunk chunk)
        {
            Points = p;
            Values = new List<float>(8);
            foreach (var point in p)
            {
                Values.Add(chunk.getValue(point.x, point.y, point.z));
            }
        }

        public List<Vector3> Points { get; set; }

        public List<float> Values { get; set; }

        public static List<MarchingCube> generateCubes(int res, float dimension, Chunk chunk)
        {
            var cubes = new List<MarchingCube>();

            var step = dimension / res;
            for (var x = 0f; x < dimension; x += step)
            {
                for (var y = 0f; y < dimension; y += step)
                {
                    for (var z = 0f; z < dimension; z += step)
                    {
                        var points = new List<Vector3>(8)
                        {
                            new Vector3(x, y, z),
                            new Vector3(x + step, y, z),
                            new Vector3(x, y + step, z),
                            new Vector3(x, y, z + step),
                            new Vector3(x + step, y + step, z),
                            new Vector3(x + step, y, z + step),
                            new Vector3(x, y + step, z + step),
                            new Vector3(x + step, y + step, z + step)
                        };


                        cubes.Add(new MarchingCube(points, chunk));
                    }
                }
            }

            return cubes;
        }
    }
}
