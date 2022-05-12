using System;

namespace MarsRover
{
	class Program
	{
		static void Main(string[] args)
		{
			Navigator navigator = new Navigator();
			navigator.SetUpperRight(5, 5);
			navigator.SetRover(1, 2, 'N');
			navigator.Navigate("LMLMLMLMM");
			navigator.PrintPosition();

			navigator.SetRover(3, 3, 'E');
			navigator.Navigate("MMRMMRMRRM");
			navigator.PrintPosition();
			Console.ReadLine();
		}
	}
}
