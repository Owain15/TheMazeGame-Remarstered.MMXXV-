using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TheMazeGame_Remarstered.MMXXV_.Classes.GameObjects;

namespace TheMazeGame_Remarstered.MMXXV_.Classes.WorldObjects
{
	internal class Player: WorldObject
	{
		(double Lateral, double Rotainal) VelocityMax = (10, 5);


		public Player()
		{
			Size = (30, 30);

			Location = (200, 200);

			Angle = 0;

			Velocity = (0,0);
			
			Mass = 10;

			isVisable = true;

			PhisicsOn = true;

			ObjectRotation.CenterX = Size.X / 2;
			ObjectRotation.CenterY = Size.Y -( Size.Y / 4);
			ObjectRotation.Angle = Angle;

			ObjectImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\TheMazeGame(Remarstered.MMXXV)\\Res\\Player\\PlayerBasic.png"));
		}

		public Player(int startX , int startY )
		{
			Size = (30, 30);

			Location = (startX, startY);

			Angle = 0;

			Velocity = (0, 0);

			Mass = 10;

			isVisable = true;

			PhisicsOn = true;

			ObjectRotation.CenterX = Size.X / 2;
			ObjectRotation.CenterY = Size.Y - (Size.Y / 4);
			ObjectRotation.Angle = Angle;

			ObjectImage.ImageSource = new BitmapImage(new Uri("C:\\Users\\ojdav\\visual studio files\\WPF\\TheMazeGame(Remarstered.MMXXV)\\Res\\Player\\PlayerBasic.png"));
		}
		public void DetectCollitions(World currentWorld)
		{
			Rect object1 = new Rect(Location.X,Location.Y,Size.X,Size.Y);
			
			foreach(Wall wall in currentWorld.Map)
			{
				
				//object1.IntersectsWith(wall);


			}

		}

		public void UpdatePlayerInputs(Inputs.Inputs inputStats)
		{
			//Velocity.Lateral
			
			if (!inputStats.DownState() && !inputStats.UpState())
			{
				if (Velocity.Lateral < 0)
				{
					Velocity.Lateral ++;
				}

				if (Velocity.Lateral > 0)
				{
					Velocity.Lateral --;
				}

			}
			else
			{
				if(inputStats.UpState() && !inputStats.DownState())
				{					
					Velocity.Lateral -= 1;

					if (Velocity.Lateral < -VelocityMax.Lateral)
					{ Velocity.Lateral = -VelocityMax.Lateral; }
	
				}

				if(inputStats.DownState() && !inputStats.UpState())
				{	
					Velocity.Lateral += 1;

					if(Velocity.Lateral > VelocityMax.Lateral)
					{ Velocity.Lateral = VelocityMax.Lateral; }
					
				}

			}

			//Velocity.Rotationl
			
			if (!inputStats.LeftState() && !inputStats.RightState())
			{
				if (Velocity.Rotationl < 0)
				{
					Velocity.Rotationl ++;
				}

				if (Velocity.Rotationl > 0)
				{
					Velocity.Rotationl --;
				}
			}
			else
			{
				if (inputStats.LeftState() && !inputStats.RightState())
				{
					Velocity.Rotationl -= 1;

					if (Velocity.Rotationl < - VelocityMax.Rotainal)
					{ Velocity.Rotationl = - VelocityMax.Rotainal; }
				}

				if (inputStats.RightState() && !inputStats.LeftState())
				{
					Velocity.Rotationl += 1;

					if (Velocity.Rotationl > VelocityMax.Rotainal)
					{ Velocity.Rotationl = VelocityMax.Rotainal; }
				}

			} 



		}

		public void UpdatePlayerData()
		{
			//Angle

			Angle += Velocity.Rotationl;
			
			if(Angle < 0)
			{ Angle += 360; }
			if(Angle>359)
			{ Angle -= 360; }



			//Location = 		

			Location = ConvertVelocity();

			//Location.X += Velocity.Lateral;
			//Location.Y += Velocity.Lateral;


		}


		private (double X, double Y) ConvertVelocity()
		{

			return new (Location.X + Velocity.Lateral *  Math.Sin(-(Angle * (Math.PI / 180))), Location.Y + Velocity.Lateral * Math.Cos(-(Angle * (Math.PI / 180)))); 

		}


	}



}
