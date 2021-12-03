using System;
using System.Collections.Generic;
using System.IO;

namespace Day_02_01
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = @"C:\Users\felli\Desktop\Hobbies\.Net\Advent_of_Code\Advent_Of_Code_2021\Advent_Of_Code_2021\Day_02_01\input.sql";
			List<string> input = new List<string>();
			using (StreamReader reader = new StreamReader(path))
			{
				while (!reader.EndOfStream)
				{
					input.Add(reader.ReadLine());
				}
			}

			int depth = 0;
			int horizontal = 0;
			int aim = 0;

			foreach (string s in input)
			{
				string[] splitLine = s.Split(' ');
				int parameter = int.Parse(splitLine[1]);
				switch (splitLine[0])
				{
					case "forward":
						horizontal += parameter;
						depth += aim * parameter;
						break;
					case "down":
						aim += parameter;
						break;
					case "up":
						aim -= parameter;
						break;
				}
			}
			Console.WriteLine($"Depth: {depth}, Horizontal: {horizontal}");
			Console.WriteLine($"Result: {depth * horizontal}");
		}
	}
}
