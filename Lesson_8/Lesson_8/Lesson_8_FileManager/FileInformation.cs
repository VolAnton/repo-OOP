using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lesson_8_FileManager
{
    public sealed class FileInformation
    {
        public static void GetFileInfo(string path)
        {
            try
            {
                string flInput = Pathes.CutEndFilePath(path);
                if (File.Exists(flInput))
                {
                    FileInfo fl = new FileInfo(flInput);
                    FileVersionInfo fInfo = FileVersionInfo.GetVersionInfo(flInput);
                    ReportList.reportList.Add("Информация о файле: " + fl.FullName);
                    ReportList.reportList.Add("");
                    ReportList.reportList.Add($"{"Имя: ",-15} {fl.Name}");
                    ReportList.reportList.Add($"{"Размер: ",-15} {fl.Length:N0} байт");
                    ReportList.reportList.Add($"{"Дата создания: ",-15} {fl.CreationTime}");
                    ReportList.reportList.Add($"{"Тип: ",-15} {fl.Attributes}");
                    if (fl.Extension == ".exe")
                    {
                        Console.WriteLine();
                        ReportList.reportList.Add("");
                        ReportList.reportList.Add($"{"Product Name: ",-15} {fInfo.ProductName}");
                        ReportList.reportList.Add($"{"Product Version: ",-15} {fInfo.ProductVersion}");
                        ReportList.reportList.Add($"{"Company Name: ",-15} {fInfo.CompanyName}");
                        ReportList.reportList.Add($"{"Product Name: ",-15} {fInfo.ProductName}");
                        ReportList.reportList.Add($"{"File Version: ",-15} {fInfo.FileVersion}");
                        ReportList.reportList.Add($"{"File Description: ",-15} {fInfo.FileDescription}");
                        ReportList.reportList.Add($"{"Original Filename: ",-15} {fInfo.OriginalFilename}");
                        ReportList.reportList.Add($"{"Legal Copyright: ",-15} {fInfo.LegalCopyright}");
                        ReportList.reportList.Add($"{"Internal Name: ",-15} {fInfo.InternalName}");
                        ReportList.reportList.Add($"{"IsDebug: ",-15} {fInfo.IsDebug}");
                        ReportList.reportList.Add($"{"IsPatched: ",-15} {fInfo.IsPatched}");
                        ReportList.reportList.Add($"{"IsPreRelease: ",-15} {fInfo.IsPreRelease}");
                        ReportList.reportList.Add($"{"IsPrivateBuild: ",-15} {fInfo.IsPrivateBuild}");
                        ReportList.reportList.Add($"{"IsSpecialBuild: ",-15} {fInfo.IsSpecialBuild}");
                    }
                    ReportList.reportList.Add("");
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Info.OperationInfo();
            }
        }
    }
}
