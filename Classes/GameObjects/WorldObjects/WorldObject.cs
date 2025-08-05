using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TheMazeGame_Remarstered.MMXXV_.Classes.WorldObjects
{
	internal class WorldObject
	{

		public (double X, double Y) Size;
		public (double X, double Y) Location;

		public double Angle = 0;

		public RotateTransform ObjectRotation = new RotateTransform();
		public ImageBrush ObjectImage = new ImageBrush();
		

		public (double Lateral, double Rotationl) Velocity = (0,0);
		
		public int Mass = 0;

		public bool PhisicsOn = true;
		public bool isVisable = true;

		public Canvas RenderRectangle(Canvas gameWindow)
		{

			System.Windows.Shapes.Rectangle newRectangle = new System.Windows.Shapes.Rectangle
			{
				Height = Size.Y,
				Width = Size.X,
				Fill = ObjectImage
			};

			gameWindow.Children.Add(newRectangle);

			Canvas.SetLeft(newRectangle, Location.X);
			Canvas.SetTop(newRectangle, Location.Y);
			

			ObjectRotation.Angle = Angle;
			
			newRectangle.RenderTransform = ObjectRotation;

			return gameWindow;
		}


	}
}
