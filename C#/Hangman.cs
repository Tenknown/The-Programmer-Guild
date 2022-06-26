class Hangman
{
    string[] words = Array.Empty<string>();
    string chosenWord;
    string guessedF = "";
    char[] guessedT;
    static void Main(string[] args)
    {
        Hangman Hn = new Hangman();
        Hn.startGame();
    }

    void startGame()
    {
        words = System.IO.File.ReadAllLines("Words.txt"); //Read our Words.txt line for line so we end up with a string array
        chosenWord = words[new Random().Next(0, words.Length)]; //asign our chosenWord variable to a random word
        Console.WriteLine("Word chosen");
        guessedT = new char[chosenWord.Length]; // asign a size for our guessedT variable
        for(int i= 0; i < chosenWord.Length; i++)
        {
            guessedT[i] = '*'; // Here we check out how many letter our word contains and then fill in with *
        }
        Console.WriteLine(new string(guessedT));
        gameloop(); //start our gameLoop
    }

    void gameloop()
    {
        while (true) //while(true) == forever unless break;
        {
            char letter = Convert.ToChar(Console.ReadLine()[0]); //here we type in our guess
            if (chosenWord.Contains(letter)){
              for(int i=0;i<chosenWord.Length;i++)
                {
                    if (chosenWord[i] == letter) // we check for more instances of our letter in chosenWord
                    {
                        guessedT[i] = letter; // replace * with letter
                    } 
                }
            }
            else
            {
                guessedF += $"-{letter}";
            }
            Console.WriteLine($"wrong guesses {new string(guessedF)}"); //print our wrong guesses
            Console.WriteLine($"Right guesses {new string(guessedT)}"); //print our right guesses
            if (new string(guessedT) == chosenWord)break; //if we guess right the game while loop stops
        }
        Console.WriteLine($"You guessed right the word was {chosenWord}");
        Console.WriteLine($"wanna play again? y/yes | n/no");
        if (Console.ReadLine().ToLower()=="yes"||Console.ReadLine().ToLower() == "y") //check if they want to play again
        {
            startGame();
        }
        else
        {
            Environment.Exit(0); //stop the application 
        }
    }
}
