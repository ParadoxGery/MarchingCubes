using System;
using System.Collections.Generic;
using UnityEngine;

namespace pxg.DataStructure
{
    public class MarchingCube
    {
        public MarchingCube(List<Vector3> p, List<float> v)
        {
            Points = p;
            Values = v;
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
                        var points = new List<Vector3>();
                        var values = new List<float>();

                        points.Add(new Vector3(x, y, z));
                        values.Add(chunk.getValue(x, y, z));
                        points.Add(new Vector3(x + step, y, z));
                        values.Add(chunk.getValue(x + step, y, z));
                        points.Add(new Vector3(x, y + step, z));
                        values.Add(chunk.getValue(x, y + step, z));
                        points.Add(new Vector3(x, y, z + step));
                        values.Add(chunk.getValue(x, y, z + step));
                        points.Add(new Vector3(x + step, y + step, z));
                        values.Add(chunk.getValue(x + step, y + step, z));
                        points.Add(new Vector3(x + step, y, z + step));
                        values.Add(chunk.getValue(x + step, y, z + step));
                        points.Add(new Vector3(x, y + step, z + step));
                        values.Add(chunk.getValue(x, y + step, z + step));
                        points.Add(new Vector3(x + step, y + step, z + step));
                        values.Add(chunk.getValue(x + step, y + step, z + step));
                        
                        cubes.Add(new MarchingCube(points, values));
                    }
                }
            }

            return cubes;
        }
    }
}
