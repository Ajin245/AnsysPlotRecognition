using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace AnsysPlotRecognition.Models
{
    public class PlotResult : INotifyPropertyChanged
    {
        private static int id = 1;
        private string _filePath;
        private string _fileName;
        private Image _originalImg;
        private Image _cropImg;
        private string _recognizedText;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; }
        public string FilePath { 
            get
            {
                return _filePath;
            }
            set 
            {
                if (value != _filePath)
                {
                    _filePath = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string FileName { 
            get
            {
                return _fileName;
            }
            set
            {
                if (value != _fileName)
                {
                    _fileName = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Image OriginalImg {
            get 
            {
                return _originalImg;
            }
            set 
            {
                if (value != _originalImg)
                {
                    _originalImg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Image CropImg {
            get 
            {
                return _cropImg;
            }
            set
            {
                if (value != _cropImg)
                {
                    _cropImg = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string RecognizedText { 
            get 
            {
                return _recognizedText;
            }
            set 
            {
                if (value != _recognizedText)
                {
                    _recognizedText = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public PlotResult() { }
        public PlotResult(string filePath)
        {
            try
            {
                Id = PlotResult.id++;
                FilePath = filePath;
                FileName = Path.GetFileName(filePath);
                OriginalImg = Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return FileName;
        }
    }
}
