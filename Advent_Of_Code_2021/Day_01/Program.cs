﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Day_01
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = @"C:\Users\felli\Desktop\Hobbies\.Net\Advent_of_Code\Advent_Of_Code_2021\Advent_Of_Code_2021\Day_01\input.sql";
			List<int> input = new List<int>();
			using(StreamReader reader = new StreamReader(path))
			{
				while (!reader.EndOfStream)
				{
					input.Add(int.Parse(reader.ReadLine()));
				}
			}

			
			int nrOfIncreasements = 0;
			int current = input[0];
			for(int i = 1; i < input.Count; i++)
			{
				if (input[i] > current)
				{
					nrOfIncreasements++;
				}
				current = input[i];
			}
			Console.WriteLine(nrOfIncreasements);
		}
	}
}
