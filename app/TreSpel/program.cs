using TreSpel;


using TreSpel.Games;



//välkomstmeddelanden:
Console.WriteLine("Välkommen till Simons tre spel!");
Console.WriteLine("Du kommer få ett par alternativ:");

//while-loopen håller spel-programmet igång:
while (true)
{
    //åkallar menyn:
    ShowMenu();
    //Lägger användarens val av spel i variabel:
    int choice = GetUserChoice();

    //kör spelaren val genom en switch för att välja programmets väg:
    switch (choice)
    {
        //om spelaren vill spela luffarschack - val 1:
        case 1:
            PlayGame(new TicTacToe());
            break;
            //hänga gubbe - val 2:
        case 2:
            PlayGame(new Hangman());
            break;
            //sten-sax-påse - val 3:
        case 3:
            PlayGame(new RockPaperScissors());
            break;
            //annars om spelaren vill avsluta - val 4:
        case 4:
            Environment.Exit(0);
            break;
            //och spelaren måste välja någon av dessa:
        default:
            Console.WriteLine("Felaktigt val. Försök igen.");
            break;
    }
}
    
//metod för att visa menyn:
    static void ShowMenu()
{
    Console.WriteLine("1. Luffarschack");
    Console.WriteLine("2. Hänga gubbe");
    Console.WriteLine("3. Sten-Sax-Påse");
    Console.WriteLine("4. Avsluta");
}

//hämtar in spelarens input och val:
static int GetUserChoice()
{
    Console.Write("Skriv ditt val: ");
    return int.Parse(Console.ReadLine());
}

//metod för att spela spel: använder interface IGame:
static void PlayGame(IGame game)
{
    //vi spelar...
    game.Play();
    //när vi är färdiga får spelaren detta meddelande:
    Console.WriteLine("tryck på enter för att återvända till menyn.");
    Console.ReadLine();
}

//interface för spel:
interface IGame
{
    //med en spel-funktion:
    void Play();
}









