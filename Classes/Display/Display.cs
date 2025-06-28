using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TheMazeGame_Remarstered.MMXXV_.Classes.WorldObjects;

namespace TheMazeGame_Remarstered.MMXXV_.Classes.Display
{
	internal class Display
	{
		private Canvas Window;

		public static Canvas Show(World gameWorld)
		{
			Canvas gameState = new Canvas();

			Random ran = new Random();

			int index = ran.Next(0, 3);
			Brush testColor;
			

			
			Rectangle test = new Rectangle
			{
				Height = 30,
				Width = 30,
				Fill = Brushes.PowderBlue	
			};

				switch(index)
				{
					case 0: { test.Fill = Brushes.Red; break; }
					case 1: { test.Fill = Brushes.Aqua; break; }
					case 2: { test.Fill = Brushes.Green; break; }
					case 3: { test.Fill = Brushes.Yellow; break; }
					defult: { test.Fill = Brushes.Purple; break; }
				}

			


			


			gameState.Background = Brushes.Black;
			gameState.Children.Add(test);

			Canvas.SetLeft(test, 150);
			Canvas.SetTop(test, 150);

			return gameState;
		}

		public static Canvas Render(World gameWorld)
		{
			Canvas newCanvas = new Canvas();

			newCanvas.Background = Brushes.Black;
			
			newCanvas = gameWorld.player.RenderRectangle(newCanvas);

			return newCanvas;
		}

	}
}


////private void RenderPlayer(Canvas display)
////{
////	Rectangle ship = new Rectangle
////	{
////		Height = player.Height,
////		Width = player.Width,
////		Fill = Brushes.Aqua
////	};

////	display.Children.Add(ship);

////	Canvas.SetLeft(ship, player.Left);
////	Canvas.SetTop(ship, player.Top);


////	//Rotation.CenterX = ship.Width / 2;
////	//Rotation.CenterY = ship.Height;
////	ship.RenderTransform = player.Rotation;

////}


