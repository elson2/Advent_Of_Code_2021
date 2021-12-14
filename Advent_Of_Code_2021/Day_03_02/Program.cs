using System;
using System.Collections.Generic;
using System.IO;

namespace Day_03_01
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = @"C:\Users\felli\Desktop\Hobbies\.Net\Advent_of_Code\Advent_Of_Code_2021\Advent_Of_Code_2021\Day_03_01\input.sql";
			List<string> input = new List<string>();
			using (StreamReader reader = new StreamReader(path))
			{
				while (!reader.EndOfStream)
				{
					input.Add(reader.ReadLine());
				}
			}

			//for (int i = 0; i < input[0].Length; i++)
			//{
			//	if (input.Count == 1)
			//		break;
			//	int nrOfZero = 0;
			//	int nrOfOne = 0;

			//	for (int x = 0; x < input.Count; x++)
			//	{
			//		char currentChar = input[x][i];
			//		if (currentChar == '0')
			//			nrOfZero++;
			//		else
			//			nrOfOne++;
			//	}

			//	//delete Rows
			//	if(nrOfZero > nrOfOne)
			//	{
			//		KeepRowsWith(input, i, '0');
			//	}
			//	else
			//	{
			//		KeepRowsWith(input, i, '1');
			//	}
			//}

			List<string> oxygenRating = new List<string>(input);
			List<string> co2Rating = new List<string>(input);

			int indexOxygen = 0;
			while(oxygenRating.Count != 1 && indexOxygen < oxygenRating[0].Length)
			{
				int nrOfZero = 0;
				int nrOfOne = 0;

				for(int i = 0; i < oxygenRating.Count; i++)
				{
					char currentChar = oxygenRating[i][indexOxygen];
					if (currentChar == '0')
						nrOfZero++;
					else
						nrOfOne++;
				}

				if (nrOfOne >= nrOfZero)
				{
					//Console.WriteLine("Keep for {0}: 1", index);
					KeepRowsWith(oxygenRating, indexOxygen, '1');
				}
				else
				{
					//Console.WriteLine("Keep for {0}: 0", index);
					KeepRowsWith(oxygenRating, indexOxygen, '0');
				}
				indexOxygen++;
			}

			int indexCo2 = 0;
			while (co2Rating.Count != 1 && indexCo2 < co2Rating[0].Length)
			{
				int nrOfZero = 0;
				int nrOfOne = 0;

				for (int i = 0; i < co2Rating.Count; i++)
				{
					char currentChar = co2Rating[i][indexCo2];
					if (currentChar == '0')
						nrOfZero++;
					else
						nrOfOne++;
				}

				if (nrOfZero <= nrOfOne)
				{
					//Console.WriteLine("Keep for {0}: 1", index);
					KeepRowsWith(co2Rating, indexCo2, '0');
				}
				else
				{
					//Console.WriteLine("Keep for {0}: 0", index);
					KeepRowsWith(co2Rating, indexCo2, '1');
				}
				indexCo2++;
			}

			Console.WriteLine(oxygenRating[0] + "_" + oxygenRating.Count);
			Console.WriteLine(co2Rating[0] + "_" + co2Rating.Count);

		}

		public static void KeepRowsWith(List<string> list, int pos, char target)
		{
			list.RemoveAll(elem => elem[pos] == target);
		}
	}
}
