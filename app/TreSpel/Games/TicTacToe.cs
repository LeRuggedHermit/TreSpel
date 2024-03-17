using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreSpel.Games
{
    class TicTacToe : IGame
    {
        //Definierar brädet som en array med integers (tio stycken, 0-9)
        int[] Board = new int[9];
        //datorn ges ett initialvärde på -1
        int Datorn = -1;
        //detsamma för spelarens input:
        int PlayersInput = -1;
        //skapar en bol som avgör om spelet pågår eller ej.
        bool Playing = true;
        public void Play()
        {
            //ger brädets rutor noll-värden: 
            //dessa ska fyllas i av spelaren och datorn med ettor och tvåor:
            Board[0] = 0;
            Board[1] = 0;
            Board[2] = 0;
            Board[3] = 0;
            Board[4] = 0;
            Board[5] = 0;
            Board[6] = 0;
            Board[7] = 0;
            Board[8] = 0;

            //skapar random-objekt för att generera dator-respons:
            Random random = new Random();


            Console.WriteLine("Spela Luffarschack!");

            //metod för att skriva ut spelbrädet:
            void PrintTheBoard()
            {
                //for-loopar genom för att fördela dem:
                for (int i = 0; i < 9; i++)
                {
                    //en ruta på brädet ska representeras med . om den saknar värde
                    if (Board[i] == 0)
                    {
                        Console.Write(" . ");
                    }
                    else if (Board[i] == 1)
                    {
                        //om spelaren tar en ruta markeras det med ett "X"
                        Console.Write(" X ");
                    }
                    else if (Board[i] == 2)
                    {
                        //om datorn tar en ruta markeras det med "O"
                        Console.Write(" O ");
                    }

                    //radbrytning ska ske vid index 2 och 5:
                    if (i == 2 || i == 5)
                    {
                        Console.WriteLine();
                    }
                }
            }

            //bol för att kontroller om spelet är slut:
            bool CheckTheBoard()
            {
                //kontrollera för horisontell vinst på översta raden:
                if (Board[0] == Board[1] && Board[1] == Board[2])
                {
                    //kontrollera om spelaren eller datorn vann:
                    if (Board[0] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        Playing = false;
                        return true;
                    }
                    else if (Board[0] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        Playing = false;
                        return true;
                    }
                }

                //kontrollera för horisontell vinst på mellersta raden:
                else if (Board[3] == Board[4] && Board[4] == Board[5])
                {
                    if (Board[3] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        Playing = false;
                        return true;
                    }
                    else if (Board[3] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        Playing = false;
                        return true;
                    }
                }

                //kontrollera för horisontell vinst på nedersta: raden:
                else if (Board[6] == Board[7] && Board[7] == Board[8])
                {
                    if (Board[6] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        Playing = false;
                        return true;
                    }
                    else if (Board[6] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        Playing = false;
                        return true;
                    }
                }

                //kontrollera för vertikal vinst: 
                if (Board[0] == Board[3] && Board[3] == Board[6])
                {
                    if (Board[0] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        Playing = false;
                        return true;
                    }
                    else if (Board[0] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        Playing = false;
                        return true;
                    }
                }

                else if (Board[1] == Board[4] && Board[4] == Board[7])
                {
                    if (Board[1] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        Playing = false;
                        return true;
                    }
                    else if (Board[1] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        Playing = false;
                        return true;
                    }
                }

                else if (Board[2] == Board[5] && Board[5] == Board[8])
                {
                    if (Board[2] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        Playing = false;
                        return true;

                    }
                    else if (Board[2] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        Playing = false;
                        return true;
                    }
                }

                //kontrollera för diagonal vinst:
                if (Board[0] == Board[4] && Board[4] == Board[8])
                {
                    if (Board[0] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        Playing = false;
                        return true;
                    }
                    else if (Board[0] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        Playing = false;
                        return true;
                    }
                }

                else if (Board[2] == Board[4] && Board[4] == Board[6])
                {
                    if (Board[2] == 1)
                    {
                        Console.WriteLine("Spelaren vinner!");
                        return true;
                    }
                    else if (Board[2] == 2)
                    {
                        Console.WriteLine("Datorn vinner!");
                        return true;
                    }
                }

             

                return false;
            }

         

            while (Playing)
            {
                PrintTheBoard();
                CheckTheBoard();


                if (Playing != true)
                {
                    Console.WriteLine("Vill du spela igen? Y/N");
                    string Playagain = Console.ReadLine().ToUpper();

                    if (Playagain == "Y")
                    {
                        // reset:ar spelet och nollställer brädet:
                        Array.Clear(Board, 0, Board.Length);
                        //spelarna får ursprungs värden:
                        PlayersInput = -1;
                        Datorn = -1;
                        // spel-bolen är sann igen:
                        Playing = true;
                        //vi skriver ut brädet igen och börjar om
                        PrintTheBoard();
                    }
                    else
                    {
                        Console.WriteLine("Tack för att du spelade Tic Tac Toe!");
                        Playing = false;
                        return; // Avslutar metoden och återvänder till menyn
                    }
                }

                //kontrollerar input och ser till att rutan är ledig:
                while (PlayersInput == -1 || Board[PlayersInput] != 0)
                {
                    //hämtar input:
                    PlayersInput = int.Parse(Console.ReadLine());
                }
                //spelar representeras av en 1:a
                Board[PlayersInput] = 1;

                //samma kontroll för datorns input:
                while (Datorn == -1 || Board[Datorn] != 0)
                {
                    //randomiserat svar:
                    Datorn = random.Next(8);
                }
                //datorn representeras av en 2:a
                Board[Datorn] = 2;

                //konsolen rensas:
                Console.Clear();
            }
        }

    }
}
