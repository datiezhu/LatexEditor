﻿
using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LatexEditor
{
	class LatexPoint : LatexNode
	{

        public Ellipse ellipse { get; set; }
        public string PointColor { get; set; }

        public LatexPoint (Canvas mainCanvas)
		{
            ellipse = new Ellipse();
            ellipse.Width = 6;
            ellipse.Height = 6;
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            ellipse.Fill = new SolidColorBrush(Colors.Black);
            ellipse.StrokeThickness = 6;
            PointColor = "black";
            this.mainCanvas = mainCanvas;
        }

		/// <summary>
		/// Creates an instance with set position.
		/// </summary>
		/// <param name="x">X position.</param>
		/// <param name="y">Y position.</param>
		public LatexPoint (double x, double y, Canvas mainCanvas) : this(mainCanvas)
		{            
            this.X = x;
			this.Y = y;      
        }

		/// <summary>
		/// Creates an instance from existing Point class object.
		/// </summary>
		/// <param name="point">Position object</param>
		public LatexPoint (Point point, Canvas mainCanvas) : this(mainCanvas)
        {
			this.X = point.X;
			this.Y = point.Y;         
        }

        public void SetPosition(LatexPoint point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }


        public override void SaveToLatex(string filePath)
        {
            StreamWriter file = File.AppendText(filePath);
            file.WriteLine("\\fill[fill=" + PointColor + "] (" + X.ToString(new CultureInfo("en-US")) + " , " + RecalculateCoordinateY(Y).ToString(new CultureInfo("en-US")) + ") circle(50pt) node{ };");
            file.Close();
        }

        internal void Draw()
        {    
            Canvas.SetLeft(ellipse, X);
            Canvas.SetTop(ellipse, Y);
            mainCanvas.Children.Remove(ellipse);
            mainCanvas.Children.Add(ellipse);
        }

        public override bool Contain(Ellipse elipse)
        {
            if (ellipse == elipse)
                return true;
            return false;
        }

        public void UpdatePoint(LatexPoint latexPoint)
        {
            SetPosition(latexPoint);
            Canvas.SetLeft(ellipse, latexPoint.X);
            Canvas.SetTop(ellipse, latexPoint.Y);            
        }
    }
}
