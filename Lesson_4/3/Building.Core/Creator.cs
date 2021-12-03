using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Building.Core
{
    public static class Creator
    {
        private static Hashtable _build = new Hashtable();

        public static int CreateBuild(float height)
        {
            return CreateBuild(height, 0);
        }

        public static int CreateBuild(float height, int floor)
        {
            return CreateBuild(height, floor, 0);
        }

        public static int CreateBuild(float height, int floor, uint apartment)
        {
            return CreateBuild(height, floor, apartment, 0);
        }

        public static int CreateBuild(float height, int floor, uint apartments, uint entrance)
        {
            Building result = new Building() { Height = height, Floor = floor, Apartments = apartments, Entrance = entrance };
            _build.Add(result.IdNumber, result);

            return result.IdNumber;
        }

        public static Building GetBuildByIdNumber(int idNumber)
        {
            return (Building)_build[idNumber];
        }

        public static void DestroyBuildByIdNumber(int idNumber)
        {
            _build.Remove(idNumber);
        }

    }
}
