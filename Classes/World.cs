using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TheMazeGame_Remarstered.MMXXV_.Classes.GameObjects;
using TheMazeGame_Remarstered.MMXXV_.Classes.WorldObjects;

namespace TheMazeGame_Remarstered.MMXXV_.Classes
{
	internal class World
	{

		(double X, double Y) Dimentions;

		public Player player;

		public List<Wall> Map;

		List<WorldObject> ObjectList;

		//Get Map Data from text File "TestMap.txt"
		public World()
		{
			Dimentions = (200, 200);

			player = new Player(80,80);

			Map = new List<Wall>();

			Map.Add(new Wall((30, 30), (30, 150)));
			Map.Add(new Wall((30, 150), (150, 150)));
			Map.Add(new Wall((150, 150), (150, 30)));

			ObjectList = new List<WorldObject>();
			
		}

		public void UpdateGameState(Inputs.Inputs inputStates)
		{

			player.UpdatePlayerInputs(inputStates);

			if(inputStates.EscState())
			{ Environment.Exit(0); }


			player.UpdatePlayerData();

			// check if player position is valid
			if (player.Location.X < 0)
			{ player.Location.X = Dimentions.X; }
			if (player.Location.X > Dimentions.X)
			{ player.Location.X = 0; }
			if (player.Location.Y < 0)
			{ player.Location.Y = Dimentions.Y; }
			if (player.Location.Y > Dimentions.Y)
			{ player.Location.Y = 0; }


			//DetectCollitions

			Rect playerHitBox = new Rect(player.Location.X,player.Location.Y,player.Size.X,player.Size.Y);
			
			for(int i = 0; i < Map.Count; i ++)
			//foreach(Wall wall in Map)
			{
				(Point p1, Point p2) wallData = Map[i].GetPoints();
				Rect wallHitBox = new Rect(wallData.p1,wallData.p2);

				if(wallHitBox.IntersectsWith(playerHitBox))
				{
					//HandleCollition()
					HandelPLayerCollition(Map[i]);
				}

			}


		}

		private void HandelPLayerCollition(Wall wall)
		{
			
		}

		public Canvas RenderMap(Canvas gameWorld)
		{
			Canvas newCanvas = gameWorld;

			Rectangle border = new Rectangle();
			border.Width = Dimentions.X;
			border.Height = Dimentions.Y;
			border.Fill = Brushes.Black;
			border.Stroke = Brushes.DarkGray;

			newCanvas.Children.Add(border);

			foreach (Wall wall in Map)
			{
				newCanvas.Children.Add(wall.GetLineRender());
			}

			return newCanvas;
		}

	}
}
