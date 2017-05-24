using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace BrainTrainer
{
	public static class ExRandom
	{
		static Random random = new Random();

		public static bool FlipCoin(double rate)
		{
			if (rate < 0) return false;
			return random.NextDouble() < rate;
		}

		public static double NextGaussian(double mu = 0, double sigma = 1)
		{
			var u1 = random.NextDouble();
			var u2 = random.NextDouble();

			var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
								Math.Sin(2.0 * Math.PI * u2);

			var rand_normal = mu + sigma * rand_std_normal;

			return rand_normal;
		}

		public static double NextPosGaussian(double mu = 0, double sigma = 1)
		{
			return Math.Abs(NextGaussian(mu, sigma));
		}

		public static double NextDouble(double max = 1)
		{
			return random.NextDouble() * max;
		}

		public static Symbols NextSymbol()
		{
			return (Symbols)random.Next(8);
		}

		public static (Symbols, Symbols) NextSymbol2()
		{
			Symbols first = NextSymbol();
			Symbols second = NextSymbol();

			while (first != second)
			{
				second = NextSymbol();
			}

			return (first, second);
		}
	}
}
