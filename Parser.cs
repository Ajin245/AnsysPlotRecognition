using AnsysPlotRecognition.Models;
using System;
using System.Linq;

namespace AnsysPlotRecognition
{
    public static class PlotInformationParser
    {
        public static bool ParseSolutionInformation(PlotResult plotResult)
        {
            try
            {
                //Проверяем тип анализа, в данном случае наличие "Time" говорит о Transient анализе
                if (plotResult.RecognizedText.ToLower().Contains("time"))
                {
                    //TODO Добавить проверку парсинга
                }
                string[] data = plotResult.RecognizedText.Split('\n');
                //Если есть запись о типе solution
                string solution = data.FirstOrDefault(x => x.ToLower().Contains("soluti"));
                //При распознавании могут быть ошибки поэтому стоит ввести дополнительные критерии поиска словосочетаний
                string plotType = data.FirstOrDefault(x => x.ToLower().Contains("fail"));
                string step = data.FirstOrDefault(x => x.ToLower().Contains("step"));
                string substep = data.FirstOrDefault(x => x.ToLower().Contains("sub"));
                string time = data.FirstOrDefault(x => x.ToLower().Contains("time"));
                string smn = data.FirstOrDefault(x => x.ToLower().Contains("smn"));
                string smx = data.FirstOrDefault(x => x.ToLower().Contains("smx") || x.ToLower().Contains("smk"));

                plotResult.SolutionInformation = new SolutionInformation(
                    solution,
                    plotType,
                    Convert.ToInt32(ExtractValue(step)),
                    Convert.ToInt32(ExtractValue(substep)),
                    Convert.ToDouble(ExtractValue(time)),
                    Convert.ToDouble(ExtractValue(smn)),
                    Convert.ToDouble(ExtractValue(smx))
                    );
                return true;
            }
            //Обработка FormatException, если не получилось распарсить строку
            catch (FormatException ex)
            {
                Program.Logger.Trace(ex);
                return false;
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex);
                return false;
            }
        }
        private static string ExtractValue(string inputString)
        {
            string result = "";
            if (inputString != null && inputString.Contains("="))
            {
                var resultValue = inputString.Split('=');
                if (resultValue[1].Contains("—"))
                {
                    resultValue[1] = resultValue[1].Replace('—', '-');
                }
                result = resultValue[1].Trim();
            }
            return result;
        }

        
    }
}
