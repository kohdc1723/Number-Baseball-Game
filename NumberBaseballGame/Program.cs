using System;

namespace NumberBaseballGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+----------------------------------------------------------------------+");
            Console.WriteLine("|                       <Number Baseball Game>                         |");
            Console.WriteLine("+----------------------------------------------------------------------+");
            Console.WriteLine("|   Computer selected a 3-digit number.                                |");
            Console.WriteLine("|   Each number is 0 ~ 9, without overlap.                             |");
            Console.WriteLine("|   If you match all the numbers and positions, you win.               |");
            Console.WriteLine("|   If the number and position are both correct, it's a Strike.        |");
            Console.WriteLine("|   If the number is correct and the position is wrong, it's a Ball.   |");
            Console.WriteLine("|   If the number is wrong, it's a Out.                                |");
            Console.WriteLine("+----------------------------------------------------------------------+");

            Random random = new Random();

            int[] Numbers = new int[3];

            int NumbersIndex = 0;
            while (NumbersIndex < 3)
            {
                Numbers[NumbersIndex] = random.Next(0, 10);

                bool Duplicate = false;
                for (int CheckIndex = 0; CheckIndex < NumbersIndex; CheckIndex++)
                {
                    if (Numbers[NumbersIndex] == Numbers[CheckIndex])
                    {
                        Duplicate = true;
                        break;
                    }
                }

                if (!Duplicate)
                {
                    NumbersIndex++;
                }
            }

            Console.WriteLine("<<<Computer selected a 3-digit number.>>>");
            Console.WriteLine();

            int[] guesses = new int[3];
            string[] InputMessages = { "> Input the first number.", "> Input the second number.", "> Input the third number." };

            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(InputMessages[i]);
                    guesses[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("> The number you selected.");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(guesses[i]);
                }

                if (guesses[0] == guesses[1] ||
                    guesses[1] == guesses[2] ||
                    guesses[2] == guesses[0])
                {
                    Console.WriteLine("You cannot input the overlapping number!");
                    continue;
                }

                int StrikeCount = 0;
                int BallCount = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (guesses[i] == Numbers[j])
                        {
                            if (i == j)
                            {
                                StrikeCount++;
                            }
                            else
                            {
                                BallCount++;
                            }
                        }
                    }
                }

                Console.Write("Strike: ");
                Console.WriteLine(StrikeCount);
                Console.Write("Ball: ");
                Console.WriteLine(BallCount);
                Console.Write("Out: ");
                Console.WriteLine(3 - StrikeCount - BallCount);
                Console.WriteLine();

                if (StrikeCount == 3)
                {
                    Console.WriteLine("Correct!.");
                    break;
                }
            }
        }
    }
}
