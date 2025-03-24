using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Final_app
{

    internal class VisualRecognition
    {
        private string tessDataPath = @"./tessdata"; // Make sure tessdata is in the right location
        private string language;
        private int trashHold;

        public VisualRecognition(string path, string language, int trashHold)
        {
            tessDataPath = path;
            this.language = language;
            this.trashHold = trashHold;
        }

        public string ExtractTextFromImage(Image image)
        {
            string extractedText = "";
            using (Bitmap bitmap = new Bitmap(image))
            {
                try
                {
                    using (var engine = new TesseractEngine(tessDataPath, language, EngineMode.Default))
                    {
                        using (var pix = PixConverter.ToPix(bitmap))
                        {
                            using (var page = engine.Process(pix))
                            {
                                extractedText = page.GetText();
                                if (page.GetMeanConfidence() * 100 < trashHold)
                                {
                                    throw new Exception("Recognition is to low: " + page.GetMeanConfidence());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("OCR extraction failed: " + ex.Message);
                }
            }

            return extractedText;
        }

    }
}