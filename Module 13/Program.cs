using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace Module13
{
	class Program
	{
		static void Main(string[] args)
		{
			Estimate(20);

			Console.ReadKey();
		}

		static void CreateMatrix(int n)
		{
			var matrix = new int[n][];

			for (int i = 0; i < n; i++)
			{
				matrix[i] = new int[n];
			}

			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					matrix[i][j] = i + j;
				}
			}
		}

		static void Estimate(int n)
		{
			for (int i = 0; i < n; i++)
			{
				CreateMatrix(10000);
			}
		}
	}

}