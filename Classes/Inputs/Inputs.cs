using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheMazeGame_Remarstered.MMXXV_.Classes.Inputs
{
	internal  class Inputs
	{
		bool Up;
		bool Down;
		bool Left;
		bool Right;

		public Inputs()
		{
			Up = false;
			Down = false;
			Left = false;
			Right = false;
		}

		public void UpdateAllInputStates()
		{
			Up = Keyboard.IsKeyDown(Key.Up);
			Down = Keyboard.IsKeyDown(Key.Down);
			Left = Keyboard.IsKeyDown(Key.Left);
			Right = Keyboard.IsKeyDown(Key.Right);


		}

		public bool ActiveInputs()
		{
			return (Up || Down || Left || Right) == true;
		}

		public bool UpState()
		{ return Up; }

		public bool DownState()
		{ return Down; }

		public bool LeftState()
		{ return Left; }

		public bool RightState()
		{ return Right; }
	}
}
