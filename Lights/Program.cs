using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestre1project
{
    class Program
    {

        static string[] lines = File.ReadAllLines("lights.in.txt");
        static string[] split = lines[0].Split(';');
        
        static char[] path = new char[int.Parse(split[1])* int.Parse(split[0])];
        static int min = int.MaxValue;
        static int position = 0;



        static void Main(string[] args)
        {
            // READING INFO ABOUT THE PARK FROM THE FILE
            string[] lines = File.ReadAllLines("lights.in.txt");
            string[] split = lines[0].Split(';');
            int width = int.Parse(split[1]);
            int height = int.Parse(split[0]);
            int NumOfPoles = int.Parse(split[2]);
            int range = int.Parse(split[3]);
            
            int Xindexer = 0;
            int Yindexer = 1;
            int[] LightsArray = new int[((lines.Length) - 1) * 2];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] split1 = lines[i].Split(';');                          
                LightsArray[Xindexer] = int.Parse(split1[0]); 
                LightsArray[Yindexer] = int.Parse(split1[1]);
                Xindexer = Xindexer + 2;
                Yindexer = Yindexer + 2;
            }
            // initiation of the park           
            Park park1 = new Park(width, height, NumOfPoles,LightsArray,range);
            //printing the park
            char[,] park = park1.ChangerToChar();
            for (int i = 0; i < park.GetLength(0); i++)
            {
                for (int j = 0; j < park.GetLength(1); j++)
                {
                    if (park[i,j]=='S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(park[i, j].ToString().PadLeft(4));

                    }
                    if (park[i, j] == 'U')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(park[i, j].ToString().PadLeft(4));
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            //starting point
            Console.Write("what are the coordinates of the STARING point : (X;Y) format ");
            string starting = Console.ReadLine();
            string[] startingspliter = starting.Split(';');
            int startingX = int.Parse(startingspliter[0]);
            int startingY = int.Parse(startingspliter[1]);
            //ending point
            Console.Write("what are the coordinates of the ENDING point : (X;Y) format ");
            string ending = Console.ReadLine();
            string[] endingspliter = ending.Split(';');
            int endingX = int.Parse(endingspliter[0]);
            int endingY = int.Parse(endingspliter[1]);
            park[endingX - 1, endingY - 1] = 'E';
            // finding the shortest paths
            FindMINPath(startingX - 1, startingY - 1, 'x', park);
            //printing the shortest paths
            FindPath(startingX - 1, startingY - 1, 'x', park);

            Console.ReadLine();
        }
        static void FindMINPath(int row, int col, char direction, char[,] park)
        {

            if ((col < 0) || (row < 0) || (col >= park.GetLength(1)) || (row >= park.GetLength(0)))
            {
                // We are out
                return;
            }
            // Append the direction to the path
            path[position] = direction;
            position++;
            // Check if we have found the exit
            if (park[row, col] == 'E')
            {
                minpath(path, 1, position - 1);
            }
            if (park[row, col] == 'S')
            {
                // The current cell is free. Mark it as visited
                park[row, col] = 'V';
                // Invoke recursion to explore all possible directions
                FindMINPath(row, col - 1, 'L', park); // left
                FindMINPath(row - 1, col, 'U', park); // up
                FindMINPath(row, col + 1, 'R', park); // right
                FindMINPath(row + 1, col, 'D', park); // down
                // Mark back the current cell as free
                park[row, col] = 'S';
            }
            // Remove the last direction from the path
            position--;
        }
        static void FindPath(int row, int col, char direction, char[,] park)
        {

            if ((col < 0) || (row < 0) || (col >= park.GetLength(1)) || (row >= park.GetLength(0)))
            {
                // We are out
                return;
            }
            // Append the direction to the path
            path[position] = direction;
            position++;
            // Check if we have found the exit and the path is the shortest and print it
            if (park[row, col] == 'E' && position - 2 == min)
            {
                Console.Write("Shortest path : ");
                for (int pos = 1; pos <= position - 1; pos++)
                {
                    Console.Write(path[pos] + " ");
                }
                Console.WriteLine();
                return;
            }
            if (park[row, col] == 'S')
            {
                // The current cell is free. Mark it as visited
                park[row, col] = 'V';
                // Invoke recursion to explore all possible directions
                FindPath(row, col - 1, 'L', park); // left
                FindPath(row - 1, col, 'U', park); // up
                FindPath(row, col + 1, 'R', park); // right
                FindPath(row + 1, col, 'D', park); // down
                // Mark back the current cell as free
                park[row, col] = 'S';
            }
            // Remove the last direction from the path
            position--;
        }
        static void minpath(char[] path, int startPos, int endPos)
        {
            if (endPos-startPos < min)
            {
                min = endPos - startPos;
            }
            
        }
        
    }
}
