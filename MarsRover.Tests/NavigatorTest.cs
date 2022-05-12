using Xunit;

namespace MarsRover.Tests
{
	public class NavigatorTest
	{
		[Fact]
		public void CanNavigator()
		{
			Navigator navigator = new Navigator();
			navigator.SetUpperRight(5, 5);
			navigator.SetRover(1, 2, 'N');
			navigator.Navigate("LMLMLMLMM");
			string position = navigator.GetPosition();
			Assert.Equal("1 3 N", position);
		}
	}
}
