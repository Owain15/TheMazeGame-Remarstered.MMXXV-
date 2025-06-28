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
	internal class Player: WorldObject
	{
		public Player()
		{
			Size = (50, 50);

			Location = (200, 200);

			Angle = 0;

			Velocity = (0,0);
			
			Mass = 10;

			isVisable = true;

			PhisicsOn = true;

			ObjectRotation.CenterX = Size.X / 2;
			ObjectRotation.CenterY = (Size.X/2) + (Size.Y / 4);
			ObjectRotation.Angle = Angle;

			ObjectImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\TheMazeGame(Remarstered.MMXXV)\\Res\\Player\\PlayerBasic.png"));
		}
		

		public void UpdatePlayerInput(Inputs.Inputs inputStats)
		{

			if(inputStats.UpState())
			{
				Velocity.Y += 1;

				if(Velocity.Y > 10)
				{ Velocity.Y = 10; }
			}

			if(inputStats.DownState())
			{
				Velocity.Y -= 1;

				if (Velocity.Y < -10)
				{ Velocity.Y = -10; }
			}

			if(inputStats.LeftState() && !inputStats.RightState())
			{
				Angle = Angle - 5;
				
				if(Angle < 0)
				{ Angle = 360 - Angle; }
			}

			if(inputStats.RightState() && !inputStats.LeftState())
			{
				Angle = Angle + 5;
				
				if(Angle > 360)
				{ Angle = Angle - 360; }
			}





		}

		public void UpdatePlayerData()
		{

		}

	}
}
