﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LatexEditor
{
    class Save
    {

        public static void saveJpg(string fileName, Canvas canvas)
        {
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width,
            (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            rtb.Render(canvas);

            BitmapEncoder jpegEncoder = new JpegBitmapEncoder();
            jpegEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (var fs = System.IO.File.OpenWrite(fileName))
            {
                jpegEncoder.Save(fs);
            }
        }

        public static void saveTex(string filePath, List<Component> components)
        {
            StreamWriter fileBegin = File.CreateText(filePath);
            fileBegin.WriteLine("\\documentclass{standalone}");
            fileBegin.WriteLine("\\usepackage{tikz}");
            fileBegin.WriteLine("\\begin{document}");
            fileBegin.WriteLine("\\begin{tikzpicture}");
            fileBegin.Close();
            foreach (Component component in components)
                component.SaveToLatex(filePath);
            StreamWriter fileEnd = File.AppendText(filePath);
            fileEnd.WriteLine("\\end{tikzpicture}");
            fileEnd.WriteLine("\\end{document}");
            fileEnd.Close();
        }
    }
}
