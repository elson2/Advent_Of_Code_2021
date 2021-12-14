using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Day_04_01
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = @"C:\Users\felli\Desktop\Hobbies\.Net\Advent_of_Code\Advent_Of_Code_2021\Advent_Of_Code_2021\Day_04_01\input.sql";
			List<int> bingoNumbers = new List<int>();
			List<int[,]> bingoBoards = new List<int[,]>();

			using (StreamReader reader = new StreamReader(path))
			{
				bool numbersRead = false;
				int[,] currentBoard = new int[5, 5];
				int boardLineIndex = 0;
				while (!reader.EndOfStream)
				{
					string currentLine = reader.ReadLine();

					//read picked bingo numbers
					if (!numbersRead)
					{
						if (!string.IsNullOrEmpty(currentLine))
						{
							string[] lineSplit = currentLine.Split(',');
							foreach(string s in lineSplit)
							{
								bingoNumbers.Add(int.Parse(s));
							}
						}
						else
						{
							numbersRead = true;
						}
					}
					else
					{
						if (!string.IsNullOrEmpty(currentLine))
						{
							string[] lineSplit = currentLine.Split(' ');
							lineSplit = RemoveEmpty(lineSplit);
							for (int i = 0; i < lineSplit.Length; i++)
							{
								currentBoard[boardLineIndex, i] = int.Parse(lineSplit[i]);
							}
							boardLineIndex++;
						}
						else
						{
							boardLineIndex = 0;
							bingoBoards.Add(currentBoard);
							currentBoard = new int[5, 5];
						}
					}
				}
			}
			//Console.WriteLine(PrintBoards(bingoBoards));
			bool foundBoard = false;
			for(int i = 0; i < bingoNumbers.Count; i++)
			{
				int[] subArray = bingoNumbers.GetRange(0, i + 1).ToArray();
				for(int x = 0; x < bingoBoards.Count; x++)
				{
					int[,] currentBoard = bingoBoards[x];

					int index;
					bool finished = CheckBoard(currentBoard, subArray, out index);
					if (finished)
					{
						Console.WriteLine(BoardToString(currentBoard));
						Console.WriteLine(subArray[subArray.Length - 1]);
						foundBoard = true;
					}

				}
				if (foundBoard)
					break;
			}
		}

		public static string[] RemoveEmpty(string[] array)
		{
			List<string> returnList = new List<string>();
			foreach(string i in array)
			{
				if (!string.IsNullOrEmpty(i)){
					returnList.Add(i);
				}
			}
			return returnList.ToArray();
		}
		public static string BoardsToString(List<int[,]> boards)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < boards.Count; i++)
			{
				for (int x = 0; x < boards[i].GetLength(0); x++)
				{
					string output = "";
					for (int y = 0; y < boards[i].GetLength(1); y++)
					{
						output += boards[i][x, y];
						if (y != 4)
							output += "_";
					}
					builder.AppendLine(output);
				}
				builder.AppendLine();
			}
			return builder.ToString();
		}
		public static string BoardToString(int[,] board)
		{
			StringBuilder builder = new StringBuilder();
			for (int x = 0; x < board.GetLength(0); x++)
			{
				string output = "";
				for (int y = 0; y < board.GetLength(1); y++)
				{
					output += board[x, y];
					if (y != 4)
						output += "_";
				}
				builder.AppendLine(output);
			}
			return builder.ToString();
		}
		public static bool CheckBoard(int[,] board, int[] pickedNumbers, out int resultIndex)
		{
			//check rows
			for(int i = 0; i < board.GetLength(0); i++)
			{
				bool[] rowResults = new bool[board.GetLength(1)];
				for(int x = 0; x < board.GetLength(1); x++)
				{
					rowResults[x] = NumberInArray(pickedNumbers, board[i, x]);
				}
				if (rowResults.All(elem => elem == true))
				{
					resultIndex = i;
					return true;
				}	
			}

			//check columns
			for (int i = 0; i < board.GetLength(1); i++)
			{
				bool[] columnResults = new bool[board.GetLength(0)];
				for (int x = 0; x < board.GetLength(0); x++)
				{
					columnResults[x] = NumberInArray(pickedNumbers, board[x, i]);
				}
				if (columnResults.All(elem => elem == true))
				{
					resultIndex = i;
					return true;
				}
			}
			resultIndex = -1;
			return false;
		}
		public static bool NumberInArray(int[] array, int number)
		{
			foreach (int i in array)
				if (i == number)
					return true;
			return false;
		}
	}
}



//int[,] testBoard =
//			{
//				{1,2,3,4,5 },
//				{6,7,8,9,10 },
//				{11,12,13,14,15 },
//				{16,17,18,19,20 },
//				{21,22,23,24,25 }
//			};
//int[] testPick = { 16, 17, 18, 19, 21 };
//int result;
//Console.WriteLine(CheckBoard(testBoard, testPick, out result) + "_" + result);

//public static bool NumberInColumn(int[,] array, int number, int columnIndex)
//{
//	bool numberInLine = false;
//	for (int i = 0; i < array.GetLength(0); i++)
//	{
//		if (array[i, columnIndex] == number)
//			numberInLine = true;
//	}
//	return numberInLine;
//}
//public static bool NumberInRow(int[,] array, int number, int rowIndex)
//{
//	bool numberInLine = false;
//	for (int i = 0; i < array.GetLength(1); i++)
//	{
//		if (array[rowIndex, i] == number)
//			numberInLine = true;
//	}
//	return numberInLine;
//}
//public static bool NumberInColumn(int[,] array, int[] numbers, int columnIndex)
//{
//	for (int i = 0; i < array.GetLength(0); i++)
//	{
//		foreach (int n in numbers)
//			if (n == array[i, columnIndex])
//				return true;
//	}
//	return false;
//}
//public static bool NumberInRow(int[,] array, int[] numbers, int rowIndex)
//{
//	for (int i = 0; i < array.GetLength(0); i++)
//	{
//		foreach (int n in numbers)
//			if (n == array[rowIndex, i])
//				return true;
//	}
//	return false;
//}
