﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LatexEditor
{
	class LatexLine : Component // Class only for line properties 
	{
        public string lineStyle { get; set; }
        public string lineSize { get; set; }
        public string lineEnd { get; set; }
        public string lineColor { get; set; }
       
        public LatexLine() { }
        public LatexLine(Canvas mainCanvas)
		{
            lineColor = "Black";
            this.mainCanvas = mainCanvas;
        }

    }
}
