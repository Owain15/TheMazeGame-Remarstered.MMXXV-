using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheMazeGame_Remarstered.MMXXV_.Classes.WorldObjects;

namespace TheMazeGame_Remarstered.MMXXV_.Classes
{
	internal class World
	{

		(int X, int Y) Dimentions;

		public Player player;

		List<WorldObject> ObjectList;

		public World()
		{
			Dimentions = (200, 200);

			player = new Player();
			
			ObjectList = new List<WorldObject>();
		}

		public void UpdateGameState(Inputs.Inputs inputStates)
		{

			player.UpdatePlayerInputs(inputStates);
			player.UpdatePlayerData();

		}

	
	}
}
