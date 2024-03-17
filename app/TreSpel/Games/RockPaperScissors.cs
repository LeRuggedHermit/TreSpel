using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreSpel.Games
{
    class RockPaperScissors : IGame
    {
        public void Play()
        {
            //Skapar ett slumpmässigt objekt för senare användning:
            Random random = new Random();

            //bol för att kontrollera om spelaren vill spela:
            bool PlayAgain = true;

            //string för spelarens val:
            string Player;

            //string för datorns val:
            string Computer;

            //sträng för att ta emot svar om spelaren vill spela igen:
            string Answer;

            //medans playagain är sann:
            while (PlayAgain)
            {
                //nollställ svaren:
                Player = "";
                Computer = "";
                Answer = "";

                //spelaren måste välja sten, sax eller påse: om så inte är fallet fortsätter vi fråga:
                while (Player != "STEN" && Player != "SAX" && Player != "PÅSE")
                {

                    //Ber spelaren välja korrekt alternativ:
                    Console.WriteLine("Skriv STEN, SAX eller PÅSE");

                    //Hämtar in respons och lägger i variabel:
                    Player = Console.ReadLine();

                    //jag vill ha respons i versaler så om så inte är fallet ser vi till att det blir så här:
                    Player = Player.ToUpper();
                }


                //använder random-objektet i en switch för att datorn ska välja ett slumpmässigt alternativ av tre:
                //switchen används för att översätta responsen till ett för spelet giltigt alternativ:
                switch (random.Next(1, 4))
                {
                    case 1:
                        Computer = "STEN";
                        break;
                    case 2:
                        Computer = "SAX";
                        break;
                    case 3:
                        Computer = "PÅSE";
                        break;
                }

                //skriv ut till spelaren vem som har valt vad:
                Console.WriteLine("du har valt:" + Player + "\nDatorn har valt:" + Computer);


                //switch för att jämföra spelare och datorns svar och avgöra resultatet:
                switch (Player)
                {
                    case "STEN":
                        if (Computer == "STEN")
                        {
                            Console.WriteLine("Spelet är oavgjort!");
                        }
                        else if (Computer == "SAX")
                        {
                            Console.WriteLine("Spelaren vinner! Klokt val!");
                        }
                        else if (Computer == "PÅSE")
                        {
                            Console.WriteLine("Spelaren förlorar - Datorn är för förutseende för dig!");
                        };
                        break;
                    case "SAX":
                        if (Computer == "SAX")
                        {
                            Console.WriteLine("Spelet är oavgjort!");
                        }
                        else if (Computer == "PÅSE")
                        {
                            Console.WriteLine("Spelaren vinner! Klokt val!");
                        }
                        else if (Computer == "STEN")
                        {
                            Console.WriteLine("Spelaren förlorar - Datorn är för förutseende för dig!");
                        };
                        break;
                    case "PÅSE":
                        if (Computer == "PÅSE")
                        {
                            Console.WriteLine("Spelet är oavgjort!");
                        }
                        else if (Computer == "SAX")
                        {
                            Console.WriteLine("Spelaren vinner! Klokt val!");
                        }
                        else if (Computer == "STEN")
                        {
                            Console.WriteLine("Spelaren förlorar - Datorn är för förutseende för dig!");
                        };
                        break;
                }

                //Bol för att uppnå korrekt respons:
                bool response = true;

                //medans response är sann...
                while (response == true)
                {

                    //skrivs den här frågan ut: vi vill ha ett y eller ett n:
                    Console.WriteLine("Vill du spela igen? Y/N: ");

                    //svaret läggs här:
                    Answer = Console.ReadLine();

                    //och görs om till versaler:
                    Answer = Answer.ToUpper();

                    //Om spelare skriver Y spelar vi igen, skriver den N så stänger vi av programmet.
                    //Skriver spelaren något annat fortsätter vi fråga efter giltig respons:
                    if (Answer == "Y")
                    {
                        PlayAgain = true;
                        response = false;
                    }
                    else if (Answer == "N")
                    {
                        PlayAgain = false;
                        response = false;
                    }
                    else { response = true; }
                }
            }
            Console.WriteLine("Du spelar Sten-Sax-Påse...");
        }
    }
}
