using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lesson_4
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

    public sealed class Building
    {
        // статический номер здания, начинается с 1001
        private static int lastIdNumber = 1_001;

        // уникальный номер здания
        private int _idNumber;

        // высота здания
        private float _height;

        // количество этажей
        private int _floor;

        // количество квартир
        private uint _apartments;

        // количество подъездов
        private uint _entrance;


        public Building()
        {
            GenerateIdNumber();
        }

        public Building(float height, int floor, uint apartments, uint entrance) : this()
        {
            _height = height;
            _floor = floor;
            _apartments = apartments;
            _entrance = entrance;
        }

        public int IdNumber
        {
            get
            {
                return _idNumber;
            }
            set
            {
                if (value.GetType().ToString() == "System.Int32")
                {
                    _idNumber = value;
                }
            }
        }

        public float Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value.GetType().ToString() == "System.Single")
                {
                    _height = value;
                }
            }
        }

        public int Floor
        {
            get
            {
                return _floor;
            }
            set
            {
                if (value.GetType().ToString() == "System.Int32")
                {
                    _floor = value;
                }
            }
        }

        public uint Apartments
        {
            get
            {
                return _apartments;
            }
            set
            {
                if (value.GetType().ToString() == "System.UInt32")
                {
                    _apartments = value;
                }
            }
        }

        public uint Entrance
        {
            get
            {
                return _entrance;
            }
            set
            {
                if (value.GetType().ToString() == "System.UInt32")
                {
                    _entrance = value;
                }
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"Уникальный номер здания: {IdNumber}.\n" +
                $"Высота здания: {Height}.\n" +
                $"Количество этажей: {Floor}.\n" +
                $"Количество квартир: {Apartments}.\n" +
                $"Число подъездов: {Entrance}.");
        }

        public void GetFullInfo()
        {
            GetInfo();
            GetFloorHeight();
            GetApartmentsInEntrance();
            GetApartmentsOnFloor();
        }

        public void GetFloorHeight()
        {
            if (Floor == 0)
            {
                return;
            }
            Console.WriteLine($"Расчетная высота этажа равна: {Math.Round((decimal)(Height / Floor), 2)} (м).");
        }

        public void GetApartmentsInEntrance()
        {
            if (Entrance == 0)
            {
                return;
            }
            Console.WriteLine($"Расчетное число квартир в одном подъезде: {Math.Round((decimal)(Apartments / Entrance), 0)}.");
        }

        public void GetApartmentsOnFloor()
        {
            if (Entrance == 0 || Floor == 0)
            {
                return;
            }
            Console.WriteLine($"Расчетное число квартир на одном этаже: {Math.Round((decimal)(Apartments / Entrance / Floor), 0)}.");
        }

        private void GenerateIdNumber()
        {
            _idNumber = lastIdNumber;
            lastIdNumber = _idNumber + 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int building_1 = Creator.CreateBuild(60.56f, 20, 80, 2);
            int building_2 = Creator.CreateBuild(41.32f, 11, 48, 2);
            int building_3 = Creator.CreateBuild(22.9f, 5, 178, 5);

            Creator.GetBuildByIdNumber(building_1)?.GetInfo();

            Console.WriteLine();
            Creator.GetBuildByIdNumber(building_2)?.GetFullInfo();

            Console.WriteLine();
            Creator.GetBuildByIdNumber(building_3)?.GetFullInfo();

            Creator.DestroyBuildByIdNumber(building_3);
            Creator.GetBuildByIdNumber(building_3)?.GetFloorHeight();
            Creator.GetBuildByIdNumber(building_3)?.GetApartmentsInEntrance();
            Creator.GetBuildByIdNumber(building_3)?.GetApartmentsOnFloor();

            Console.WriteLine();
            int building_4 = Creator.CreateBuild(22.9f, 5, 178, 5);
            Creator.GetBuildByIdNumber(building_4)?.GetFullInfo();
            Creator.DestroyBuildByIdNumber(building_4);
            Creator.GetBuildByIdNumber(building_4)?.GetFullInfo();

            Console.WriteLine();
            int building_5 = Creator.CreateBuild(32.99f, 6, 111, 4);
            Console.WriteLine($"Уникальный номер здания: {Creator.GetBuildByIdNumber(building_5)?.IdNumber.ToString()}");
            Creator.GetBuildByIdNumber(building_5)?.GetFloorHeight();
            Creator.GetBuildByIdNumber(building_5)?.GetApartmentsInEntrance();
            Creator.GetBuildByIdNumber(building_5)?.GetApartmentsOnFloor();
            Console.ReadKey();
        }
    }
}
