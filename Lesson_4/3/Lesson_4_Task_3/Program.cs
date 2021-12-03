using System;
using Building.Core;

namespace Lesson_4_Task_3
{
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
