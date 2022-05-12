using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
	public class Navigator
	{
		private readonly int[] UpperRightCoord = new int[2];

		private readonly Dictionary<char, int> Directions = new Dictionary<char, int>
		{
			{'W', 1 },
			{'N', 2 },
			{'E', 3 },
			{'S', 4 }
		};

		private Rover rover;

		public void SetUpperRight(int x, int y)
		{
			UpperRightCoord[0] = x;
			UpperRightCoord[1] = y;
		}

		public void SetRover(int x, int y, char d)
		{
			rover = new Rover { X = x, Y = y, Direction = Directions[d]};
		}

		public Rover Navigate(string letters)
		{
			if (rover == null)
			{
				Console.WriteLine("No rover deployed yet!");
				return null;
			}
			char[] movements = letters.ToCharArray();

			foreach(char c in movements)
			{
				if (c == 'M')
				{
					Move(rover);
				}
				else if(c == 'L' || c == 'R')
				{
					Rotate(rover, c);
				}
				else
				{
					Console.WriteLine($"Invalid command character {c}");
				}

				
			}
			return rover;
		}

		private void Rotate(Rover rover, char c)
		{
			int currentDirection = rover.Direction;
			if (c == 'R')
			{
				int next = (currentDirection + 1 > 4) ? 1 : (currentDirection + 1);
				rover.Direction = next;
			}
			else if (c == 'L')
			{
				int next = (currentDirection - 1 <= 0) ? 4 : (currentDirection - 1);
				rover.Direction = next;
			}
		}

		private void Move(Rover rover)
		{
			switch(rover.Direction)
			{
				case 1:
					rover.X--;
					break;
				case 2:
					rover.Y++;
					break;
				case 3:
					rover.X++;
					break;
				case 4:
					rover.Y--;
					break;
				default:
					Console.WriteLine($"Unknown direction {rover.Direction}");
					break;
			}

			// The rover must not be allowed to navigate beyond the perimeter of the plain 
			if (rover.X < 0)
			{
				rover.X = 0;
			}
			else if (rover.X > UpperRightCoord[0])
			{
				rover.X = UpperRightCoord[0];
			}
			
			if(rover.Y < 0)
			{
				rover.Y = 0;
			}
			else if (rover.Y > UpperRightCoord[1])
			{
				rover.Y = UpperRightCoord[1];
			}
		}

		public string GetPosition()
		{
			char[] keys = Directions.Keys.ToArray();
			char d = keys[rover.Direction - 1];
			return $"{rover.X} {rover.Y} {d}";
		}

		public void PrintPosition()
		{
			Console.WriteLine(GetPosition());
		}
	}

	public class Rover
	{
		public int X;

		public int Y;

		public int Direction;
	}
}
