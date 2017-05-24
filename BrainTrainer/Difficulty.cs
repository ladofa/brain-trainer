using System;
using System.Collections.Generic;
using System.Text;

namespace BrainCore
{
    public class Difficulty
    {
		int dims;
		public int Dims
		{
			get => dims;
		}

		List<string> names;

		List<Tuple<double[], bool>> data;

		public Difficulty(int dims, List<string> names)
		{
			this.dims = dims;
			this.names = new List<string>(names);
		}

		

		public double[] GenerateRandom()
		{
			//--generate random unit vector with positive value
			double[] vector = new double[dims];
			for (int i = 0; i < dims; i++)
			{
				vector[i] = NextPositive();
				
			}
			return Generate(vector);
		}

		public double[] Generate(double[] vector, int maxItemNum = 50)
		{
			//generate unit vector
			double vectorLength = 0;
			for (int i = 0; i < dims; i++)
			{
				vectorLength += Math.Pow(vector[i], 2);
			}

			vectorLength = Math.Sqrt(vectorLength);

			double[] unit = new double[dims];

			for (int i = 0; i < dims; i++)
			{
				unit[i] = vector[i] / vectorLength;
			}

			List<Tuple<double, double, bool>> sortedData = new List<Tuple<double, double, bool>>();

			for (int k = 0; k < data.Count; k++)
			{
				double[] e = data[k].Item1;
				//calc projection length
				double scalar = 0;
				for (int i = 0; i < dims; i++)
				{
					scalar += unit[i] * e[i];
				}

				//get projection point
				double[] p = new double[dims];
				for (int i = 0; i < dims; i++)
				{
					p[i] = unit[i] * scalar;
				}

				double dist = 0;
				for (int i = 0; i < dims; i++)
				{
					dist += Math.Pow(p[i] - vector[i], 2);
				}

				sortedData.Add(new Tuple<double, double, bool>(dist, scalar, data[k].Item2));
			}

			sortedData.Sort((e1, e2) => e1.Item1.CompareTo(e2.Item1));
			var selected = sortedData.GetRange(0, Math.Min(sortedData.Count - 1, maxItemNum));

			if (sortedData.Count == 0)
			{
				return unit;
			}

			//understand selection status
			int countPos = 0;
			double avrPos = 0;
			int countNeg = 0;
			double avrNeg = 0;

			double maxPos = 0;
			double minNeg = double.MaxValue;

			

			foreach (var e in selected)
			{
				bool succeed = e.Item3;
				double scalar = e.Item2;
				if (succeed)
				{
					countPos++;
					avrPos += scalar;

					if (scalar > maxPos)
					{
						maxPos = scalar;
					}
				}
				else
				{
					countNeg++;
					avrNeg += scalar;

					if (scalar < minNeg)
					{
						minNeg = scalar;
					}
				}
			}

			//final difficulty
			double resultScalar;
			
			if (countPos == 0)
			{
				//level down
				resultScalar = minNeg / 2;
			}
			else if (countNeg == 0)
			{
				//level up
				resultScalar = maxPos * 2;
			}
			else
			{
				//little bit upper
				avrPos /= countPos;
				resultScalar = ((avrPos + maxPos) / 2) * (random.NextDouble() * 0.3);
			}

			double[] result = new double[dims];
			for (int i = 0; i < dims; i++)
			{
				result[i] = unit[i] * resultScalar;
			}

			return result;
		}

		#region random

		static Random random = new Random();

		static double NextGaussian(double mu = 0, double sigma = 1)
		{
			var u1 = random.NextDouble();
			var u2 = random.NextDouble();

			var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
								Math.Sin(2.0 * Math.PI * u2);

			var rand_normal = mu + sigma * rand_std_normal;

			return rand_normal;
		}

		static double NextPositive()
		{
			double x;
			do
			{
				x = NextGaussian(0.5, 0.5);
			}
			while (x > 0.1 && x < 0.9);

			return x;
		}
	}

#endregion
}
