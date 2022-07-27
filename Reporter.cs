using AnsysPlotRecognition.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace AnsysPlotRecognition
{
    class Reporter
    {
        public static bool WriteReport(List<SolutionInformation> solutions, string directoryPath, string fileName = "test.xlsx")
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var package = new ExcelPackage();
                var sheet = package.Workbook.Worksheets.Add("PlotInformation");

                //Шаблон содержимого отчета
                //Шапка
                sheet.Cells["A1"].Value = "**ВРЕМЕННЫЙ ТЕКСТ**";
                sheet.Cells["A3"].Value = "FILENAME";
                sheet.Cells["A4"].Value = "STEP";
                sheet.Cells["A5"].Value = "SUBSTEP";
                sheet.Cells["A6"].Value = "TIME";
                sheet.Cells["A8"].Value = "MIN";
                sheet.Cells["A9"].Value = "MAX";

                for (int i = 0; i < solutions.Count; i++)
                {
                    //Cells[ строка, столбец ]

                    //sheet.Cells[2,i + 2].Value = solutions[i];
                    sheet.Cells[3, i + 2].Value = solutions[i].Solution;
                    sheet.Cells[4, i + 2].Value = solutions[i].Step;
                    sheet.Cells[5, i + 2].Value = solutions[i].SubStep;
                    sheet.Cells[6, i + 2].Value = solutions[i].Time;
                    sheet.Cells[7, i + 2].Value = solutions[i].PlotType;
                    var smn = sheet.Cells[8, i + 2];
                    var smx = sheet.Cells[9, i + 2];

                    smn.Value = solutions[i].SMN;
                    smx.Value = solutions[i].SMX;

                    smn.Style.Numberformat.Format = "0.00E+00";
                    smx.Style.Numberformat.Format = "0.00E+00";
                }

                File.WriteAllBytes($"{directoryPath}\\{fileName}", package.GetAsByteArray());
                return true;
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex);
                return false;
            }
        }
    }
}
