using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreSpel.Games
{
    class Hangman : IGame
    {
        public void Play()
        {
            //hälsar spelaren välkommen:
            Console.WriteLine("Välkommen till hänga gubbe");
            Console.WriteLine("nu ska vi se...");

            //skapar ordlista i form av en array med ord:
            string[] Ordlista = new string[20];
            //varje index i arrayen är ett ord:
            Ordlista[0] = "trombon";
            Ordlista[1] = "bokhylla";
            Ordlista[2] = "diskbänk";
            Ordlista[3] = "hundkoja";
            Ordlista[4] = "volvo";
            Ordlista[5] = "Osaka";
            Ordlista[6] = "braskamin";
            Ordlista[7] = "Vetedeg";
            Ordlista[8] = "surkål";
            Ordlista[9] = "godispapper";
            Ordlista[10] = "lingonsylt";
            Ordlista[11] = "domherre";
            Ordlista[12] = "bastuba";
            Ordlista[13] = "avgrundsvrål";
            Ordlista[14] = "varmkorv";
            Ordlista[15] = "valross";
            Ordlista[16] = "vedklabbe";
            Ordlista[17] = "ingen";
            Ordlista[18] = "kvarvarande";
            Ordlista[19] = "fantasi";

            //skapar ett random-objekt:
            Random random = new Random();
            //datorns val är ett slumpmässigt index i ordlistan mellan 0 och 19:
            var X_id = random.Next(0, 19);

            //Detta är "det hemliga ordet" för rundan: 
            var hemligaOrdet = Ordlista[X_id];
            //varje gissning är ett tecken så här används char:
            char[] gissning = new char[hemligaOrdet.Length];

           
            Console.Write("Försök att gissa: ");
            //så länge som p = o och mindre än ordets längd ska vi iterera:
            for (int p = 0; p < hemligaOrdet.Length; p++)
                gissning[p] = '*';

            //vi har fem chanser att gissa fel:
            int guessesLeft = 5;


            //spelet pågår så länge vi har gissningar kvar:
            while (guessesLeft > 0)
            {
                Console.Write("Gissa en bokstav: ");
                string input = Console.ReadLine();

                //om gissningen är längre än ett tecken...
                if (input.Length != 1)
                {

                    //skriver vi ut ett meddelande och fortsätter spela:
                    Console.WriteLine("Var god gissa endast en bokstav.");
                    continue;
                }
                //Spelarens input översatt:
                char playersGuess = char.Parse(input);

                //rätt gissning sätts till falskt
                bool correctGuess = false;

                //Iterera för att se om vi har vunnit:
                for (int j = 0; j < hemligaOrdet.Length; j++)
                {
                    //om spelarens gissning är lika med något i hemliga ordet...
                    if (playersGuess == hemligaOrdet[j])
                    {
                        //så har vi en vinnare:
                        gissning[j] = playersGuess;
                        correctGuess = true;
                    }
                }

                //om gissningen är fel:
                if (!correctGuess)
                {
                    //tar vi bort en gissning:
                    guessesLeft--;
                    //och berättar hur många chanser som finns kvar:
                    Console.WriteLine($"Fel gissning! Du har {guessesLeft} gissningar kvar.");
                }

                //skriv ut gissning:
                Console.WriteLine(gissning);

                //om ordet är korrekt:
                if (new string(gissning) == hemligaOrdet)
                {
                    //grattis till spelaren 
                    Console.WriteLine("Grattis! Du har gissat rätt ord.");
                    //och bryt loopen
                    break;
                }
            }
            //har spelaren inga gissningar kvar...
            if (guessesLeft == 0)
            {
                //får den detta tråkiga meddelande
                Console.WriteLine($"Tyvärr, du har inga gissningar kvar. Rätt ord var: {hemligaOrdet}");
            }
            Console.WriteLine("Spelar hänga gubbe...");
        }
    }
}
