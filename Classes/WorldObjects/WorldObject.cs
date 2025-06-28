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

		public (int X, int Y) Size;
		public (int X, int Y) Location;

		public int Angle;

		public RotateTransform ObjectRotation = new RotateTransform();
		public ImageBrush ObjectImage = new ImageBrush();


		public (int X, int Y) Velocity;
		public int Mass;

		public bool PhisicsOn;
		public bool isVisable;

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
