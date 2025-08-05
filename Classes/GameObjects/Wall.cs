using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TheMazeGame_Remarstered.MMXXV_.Classes.GameObjects
{
    class Wall
    {

		(double X, double Y) PointA;
		(double X, double Y) PointB;

		double Width;

		Brush WallBrush;

		//Line LineRender = new Line();

		//newLine.Stroke = Brushes.WhiteSmoke;

		//	newLine.Width = 4;

			//newLine.X1 = 50;
			//newLine.Y1 = 50;

			//newLine.X2 = 50;
			//newLine.Y2 = 100;

			//newCanvas.Children.Add(newLine);

		public Wall((double X, double Y)pointA,(double X , double Y)pointB)
		{
			PointA = pointA;
			PointB = pointB;

			Width = 4;
			
			WallBrush = Brushes.WhiteSmoke;

		}

		public Line GetLineRender()
		{
			return GetNewLine(); 
		}

		private Line GetNewLine()
		{
			Line render = new Line();

			render.Stroke = WallBrush;

			render.StrokeThickness = Width;

			render.X1 = PointA.X;
			render.Y1 = PointA.Y;

			render.X2 = PointB.X;
			render.Y2 = PointB.Y;

			return render;
		}

		public (Point P1,Point P2)GetPoints()
		{
			return (new Point(PointA.X, PointA.Y), new Point(PointB.X, PointB.Y));
		}

	
	
	}
}
