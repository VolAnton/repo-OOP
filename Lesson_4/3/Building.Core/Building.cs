using System;
using System.Collections.Generic;
using System.Text;

namespace Building.Core
{
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
}
