//Obe Megargel
//Tic-Tac-Toe project
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tic-Tac-Toe!");
            int chartSize = 9;
            int moveCount = 0;
            string whoTurn = "o";
            List<string> newList = new List<string>();//for the player's choices
            List<string> takenSpots = new List<string>();//may need to create the list outside the function so it does not refresh
            List<string> structure = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
            Console.WriteLine($" {structure[0]} | {structure[1]} | {structure[2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {structure[3]} | {structure[4]} | {structure[5]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {structure[6]} | {structure[7]} | {structure[8]}");
            bool winner = false;

            //create while loop that keeps going until max out on moves
            while (moveCount < chartSize)
            {
                while(winner == false)
                {
                    //initiate first player's response and get their answer
                    whoTurn = whoGo(chartSize, moveCount);
                    Console.Write($" It is {whoTurn}'s turn. Choose a number between (1 - 9):");
                    string playerChoice = Console.ReadLine();

                    bool spot = checkSpot(playerChoice, whoTurn, structure);
                    //Console.WriteLine($"{spot}");

                    //create the board
                    List<string> board = boardForge(playerChoice, structure, chartSize, whoTurn, spot);
                    Console.Write($"{board}");

                    //structure.ForEach(name => Console.Write(name + " "));//for each loop testing what the list looks like

                    winner = whoWins(structure, chartSize, moveCount, whoTurn);//returns moveCount, if someone wins it shoots the number up to end the loop
                    Console.WriteLine($"{winner}");

                    moveCount = moveCount + 1;//this adds the moves to eventually cancel when you pass the board limit
                }
            }
            
            //screencastopmatic gives video with url of your project working, either that or Youtube. you turn in 2 urls for the assignment.
            //tic-tac-toe outline
            //flowchart
            //1) create board = seperate function
            //2)display board = in create board function. If that does not work return list and display in main.
            //3)figure out who turn it is = x goes first then alternate every other = function
            //4)display who's turn it is
            //5)ask for square
            //6)check square if already occupied(this part is extra not needed)
            //7)update square
            //8)<winner>? yes => end and let people know, no => start again

            //you could have function to display board and have a list
            //you could have a function to see who wins, if nine moves are up and no winner then it is a tie.
            // when user types '1' it goes to element [0]
            //keep track of: whos turn?, board, which player
        }

        static List<string> boardForge(string playerChoice, List<string> structure, int chartSize, string whoTurn, bool spot)
        {
            //create a list with all the | and the -+-+- to display build the board
            //create a list for the numbers
            //display the board(if that does not work return both lists and display them in main)
            
            
            //bool check = checkSpot(playerChoice, whoTurn, structure);
            if (spot = true)
            {
                int playerInt = Int16.Parse(playerChoice);
                structure[playerInt -1] = whoTurn;

                Console.WriteLine("");
                Console.WriteLine($" {structure[0]} | {structure[1]} | {structure[2]}");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {structure[3]} | {structure[4]} | {structure[5]}");
                Console.WriteLine("---+---+---");
                Console.WriteLine($" {structure[6]} | {structure[7]} | {structure[8]}");
                
            }
            else
            {
                Console.WriteLine($"self bug check: boardForge says that checkpost returned a false when it should only return true.");
            }

            

            return structure;
        }
       
        static bool checkSpot(string playerChoice, string whoTurnVar, List<string> structure)
        {
            //create a list one for playerChoice
            //check if whoTurnVar is already in the list
            //if it is not in the list add it to the list
            //else ask the user to try again

            
            
            bool ok = false;//maybe use for while loop if I need one.
            while (ok = false)
            {
                
                if (structure.Contains("x") == false)
                {
                    ok = true;
                    Console.WriteLine($"There is no {playerChoice} already in the list.");
                }
                else if (structure.Contains("o") == false)
                {
                    ok = true;
                    Console.WriteLine($"There is no {playerChoice} already in the list.");
                }
                else
                {
                    Console.Write($" self bug check: {playerChoice} is already taken. It is still {whoTurnVar}'s turn. Please choose a number between (1 - 9):");
                    playerChoice = Console.ReadLine();
                }
            }
            
            

            //structure.ForEach(name => Console.Write(name + " "));//for each loop, testing
            return ok;
        }

        static bool whoWins(List<string> structure, int chartsize, int moveCount, string whoTurn)
        {
            //create an if statement for if list numbers [0], [1], [2] are all x then print x wins
            //else if those numbers are all o print o wins.
            //do the same for every possible combination
            //else return a bool saying keep going.
            bool finish = true;
            if((structure[0] == "x" && structure[1] == "x" && structure[2] == "x") 
                || (structure[0] == "o" && structure[1] == "o" && structure[2] == "o")
                || (structure[3] == "x" && structure[4] == "x" && structure[5] == "x")
                || (structure[3] == "o" && structure[4] == "o" && structure[5] == "o")
                || (structure[6] == "x" && structure[7] == "x" && structure[8] == "x")
                || (structure[6] == "o" && structure[7] == "o" && structure[8] == "o")
                || (structure[0] == "x" && structure[5] == "x" && structure[8] == "x")
                || (structure[0] == "o" && structure[5] == "o" && structure[8] == "o")
                || (structure[6] == "x" && structure[4] == "x" && structure[2] == "x")
                || (structure[6] == "o" && structure[4] == "o" && structure[2] == "o")
                ||(structure[0] == "x" && structure[3] == "x" && structure[6] == "x")
                ||(structure[0] == "o" && structure[3] == "o" && structure[6] == "o")
                ||(structure[1] == "x" && structure[4] == "x" && structure[7] == "x")
                ||(structure[1] == "o" && structure[4] == "o" && structure[7] == "o")
                ||(structure[2] == "x" && structure[5] == "x" && structure[8] == "x")
                ||(structure[2] == "o" && structure[5] == "o" && structure[8] == "o"))
            {
                moveCount = chartsize + 1;
                Console.WriteLine($" {whoTurn} is the Winner!");
                finish = true;
            }
            else
            {
                moveCount = moveCount;
                //Console.WriteLine($"loser");
                //Console.WriteLine($" moveCount: {moveCount}");
                finish = false;
            }
            
            return finish;
        }

        static string whoGo(int chartSize, int moveCount)
        {
            
            int moveMath = moveCount % 2;
            //Console.WriteLine($"self debugging: moveMath = {moveMath}");//just to test what the value is.
            string player = "";
            if (moveCount < chartSize)
            {
                if (moveMath == 1)
                {
                    player = "x";
                }
                else 
                {
                    player = "o";
                }
            }
            else
            {
                Console.WriteLine("Game over");
            }
            //code to make this alternate every time using a while loop that keep track of 9(could be a variable) moves because after that the board is full
            return player;
        }
    }
}