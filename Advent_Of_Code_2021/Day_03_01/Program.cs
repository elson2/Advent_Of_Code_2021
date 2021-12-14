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
			uint gammaRate = 0;
			for(int i = 0; i < input[0].Length; i++)
			{
				int nrOfZero = 0;
				int nrOfOne = 0;
				gammaRate <<= 1;

				for (int x = 0; x < input.Count; x++)
				{
					char currentChar = input[x][i];
					if (currentChar == '0')
						nrOfZero++;
					else
						nrOfOne++;
				}
				if (nrOfOne > nrOfZero)
					gammaRate = (gammaRate + 1);
			}

			Console.WriteLine(gammaRate);
		}
	}
}
