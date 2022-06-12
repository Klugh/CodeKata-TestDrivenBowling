using Xunit;

namespace Bowling.UnitTests
{
	public class ScoreCard
	{
		private Game g;

		public ScoreCard()
		{
			g = new Game();
		}

		private void rollMany(int n, int Pins)
		{
			for (int i = 0; i < n; i++)
			{
				g.roll(Pins);
			}
		}

		private void rollSpare()
		{
			g.roll(5);
			g.roll(5);
		}

		private void rollStrike()
		{
			g.roll(10);
		}

		[Fact]
		public void gutterGame()
		{
			rollMany(20, 0);
			Assert.Equal(0, g.score());
		}

		[Fact]
		public void allOnes()
		{
			rollMany(20, 1);
			Assert.Equal(20, g.score());
		}

		[Fact]
		public void oneSpare()
		{
			rollSpare();
			g.roll(3);
			rollMany(17, 0);
			Assert.Equal(16, g.score());
		}

		[Fact]
		public void oneStrike()
		{
			rollStrike();
			g.roll(3);
			g.roll(4);
			rollMany(16, 0);
			Assert.Equal(24, g.score());
		}

		[Fact]
		public void perfectGame()
		{
			rollMany(12, 10);
			Assert.Equal(300, g.score());
		}
	}
}