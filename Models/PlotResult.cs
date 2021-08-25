using System;
using System.Drawing;
using System.IO;

namespace AnsysPlotRecognition.Models
{
    public class PlotResult
    {
        private static int id = 1;
        public int Id { get; }
        public string FilePath { get; set; }
        public string FIleName { get; set; }
        public Image OriginalImg { get; set; }
        public Image CropImg { get; set; }
        public string RecognizedText { get; set; }

        public PlotResult() {}
        public PlotResult(string filePath)
        {
            try
            {
                Id = PlotResult.id++;
                FilePath = filePath;
                FIleName = Path.GetFileName(filePath);
                OriginalImg = Image.FromFile(filePath);
                CropImg = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class ROI
    {

    }
}
