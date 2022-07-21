using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnsysPlotRecognition
{
    public class ElementTableParser
    {
        public string DirectoryPath { get; set; }
        public ElementTableParser( string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public SolutionInformation ParseSolutionInformation(string inputString)
        {
            try
            {
                string[] data = inputString.Split('\n');
                //Если есть запись о типе solution
                var solution = data.FirstOrDefault(x => x.ToLower().Contains("soluti"));
                //При распознавании могут быть ошибки поэтому стоит ввести дополнительные критерии поиска словосочетаний
                string plotType = data.FirstOrDefault(x => x.ToLower().Contains("fail"));
                string step = data.FirstOrDefault(x => x.ToLower().Contains("step"));
                string substep = data.FirstOrDefault(x => x.ToLower().Contains("sub"));
                string time = data.FirstOrDefault(x => x.ToLower().Contains("time"));
                string smn = data.FirstOrDefault(x => x.ToLower().Contains("smn"));
                string smx = data.FirstOrDefault(x => x.ToLower().Contains("smx") || x.ToLower().Contains("smk"));

                return new SolutionInformation(
                    solution,
                    plotType,
                    Convert.ToInt32(ExtractValue(step)),
                    Convert.ToInt32(ExtractValue(substep)),
                    Convert.ToDouble(ExtractValue(time)),
                    Convert.ToDouble(ExtractValue(smn)),
                    Convert.ToDouble(ExtractValue(smx))
                    );
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex);
                return null;
            }
        }
        private string ExtractValue(string inputString)
        {
            if (inputString != null && inputString.Contains("="))
            {
                var result = inputString.Split('=');
                if (result[1].Contains("—"))
                {
                    result[1] = result[1].Replace('—', '-');
                }
                return result[1].Trim();
            }
            return "Not extracted!";
        }

        /// <summary>
        /// Создает форматированный по шаблону файл Excel и наполняет данными из списка
        /// </summary>
        /// <param name="solutions">Список объектов SolutionInformation</param>
        /// <returns>Массив байтов для записи в файл</returns>
        private static byte[] GetReport(List<SolutionInformation> solutions)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var package = new ExcelPackage();
                var sheet = package.Workbook.Worksheets.Add("PlotInformation");
                
                //Шаблон содержимого отчета
                //Шапка
                sheet.Cells["A1"].Value = "Заменить";
                sheet.Cells["A3"].Value = "STEP";
                sheet.Cells["A4"].Value = "SUBSTEP";
                sheet.Cells["A5"].Value = "TIME";
                sheet.Cells["A7"].Value = "MIN";
                sheet.Cells["A8"].Value = "MAX";

                for (int i = 0; i < solutions.Count; i++)
                {
                    //Cells[ строка, столбец ]
                    sheet.Cells[2,i + 2].Value = solutions[i].Solution;
                    sheet.Cells[3,i + 2].Value = solutions[i].Step;
                    sheet.Cells[4,i + 2].Value = solutions[i].SubStep;
                    sheet.Cells[5,i + 2].Value = solutions[i].Time;
                    sheet.Cells[6,i + 2].Value = solutions[i].PlotType;
                    var smn = sheet.Cells[7, i + 2];
                    var smx = sheet.Cells[8, i + 2];
                    
                    smn.Value = solutions[i].SMN;
                    smx.Value = solutions[i].SMX;

                    smn.Style.Numberformat.Format = "0.00E+00";
                    smx.Style.Numberformat.Format = "0.00E+00";
                }
                return package.GetAsByteArray();
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex);
                throw;
            }
        }

        public bool WriteReport(List<SolutionInformation> solutions, string fileName = "test.xlsx")
        {
            try
            {
                File.WriteAllBytes($"{DirectoryPath}\\{fileName}", GetReport(solutions));
                return true;
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex);
                return false;
            }
        }
    }
    public class SolutionInformation
    {
        public string Solution { get; set; }
        public string PlotType { get; set; }
        public int Step { get; set; }
        public int SubStep { get; set; }
        public double Time { get; set; }
        public string RSYS { get; set; }
        public string DMX { get; set; }
        public double SMN { get; set; }
        public double SMX { get; set; }
        public SolutionInformation(string solution, string plotType, int step, int subStep, double time, double sMin, double sMax)
        {
            Solution = solution;
            PlotType = plotType;
            Step = step;
            SubStep = subStep;
            Time = time;
            SMN = sMin;
            SMX = sMax;
        }
    }
}
