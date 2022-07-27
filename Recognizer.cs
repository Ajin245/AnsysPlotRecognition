using Emgu.CV;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace AnsysPlotRecognition
{
    public class Recognizer
    {
        private Tesseract _tesseract;

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        /// <param name="dataModelPath">Путь до файла с языковыми моделями</param>
        public Recognizer(string dataModelPath)
        {
            _tesseract = new Tesseract(dataModelPath, "eng", OcrEngineMode.TesseractLstmCombined);
        }
        /// <summary>
        /// Распознает текст на картинке
        /// </summary>
        /// <param name="img">Картинка, на которой расположен текст для распознавания</param>
        /// <returns>Кортеж, состоящий из распознанного текста и булевого значения об успешности операции</returns>
        public (string, bool) RecognizeIt(Bitmap img)
        {
            try
            {
                Image<Bgr, byte> crop = new Image<Bgr, byte>(img);
                _tesseract.SetImage(crop);
                _tesseract.Recognize();
                return (_tesseract.GetUTF8Text(), true);
            }
            catch (Exception ex)
            {
                return (ex.Message, false);
            }
        }
        /// <summary>
        /// Распознает текст на картинке
        /// </summary>
        /// <param name="img">Картинка, на которой расположен текст для распознавания</param>
        /// <param name="rect">Область, в которой необходимо производить распознавание</param>
        /// <returns>Кортеж, состоящий из распознанного текста и булевого значения об успешности операции</returns>
        public string RecognizeIt(Bitmap img, Rectangle rect)
        {
            try
            {
                Image<Bgr, byte> pic = new Image<Bgr, byte>(img);
                pic.ROI = rect;
                _tesseract.SetImage(pic);
                
                _tesseract.Recognize();
                return _tesseract.GetUTF8Text();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
