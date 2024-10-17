namespace hängagubbe
{
    internal class Program
    {
       
        static string[] StringComparer(string input, string word, string[] guessword)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < word.Length; j++)
                    if (input[i] == word[j])
                    {
                        string test = ""; 
                            test += input[i];
                        guessword[j] = test;
                        
                    }
        }

            return guessword;
        }
        
        static void Main(string[] args)
        {
            List<string> words = new List<string>();
            words.Add("sko");
            words.Add("glas");
            words.Add("innebär");
            words.Add("tangetbord");
            words.Add("nötter");
            words.Add("kaffe");
            bool game = true;
            Random random = new Random();
            while (game)
            {
                
                Console.WriteLine("1, start game");
                Console.WriteLine("2, options");
                Console.WriteLine("3, Highscore");
                Console.WriteLine("4, Exit");
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        int lives = 5;
                        bool gameRound = true;
                        int points = 0;

                        string word = words[random.Next(0, 6)];
                        string[] guessword = new string[word.Length];
                        for (int i = 0; i < word.Length; i++)
                            guessword[i] = "_";

                        while (gameRound)
                        { 
                            if(lives == 0)
                            {
                                Console.WriteLine($"Dina liv tog slut! du fick {points} poäng! Rätt ord var {word}");
                                gameRound = false;
                                break;
                            }
                            
                            Console.WriteLine($"du har {lives} liv och {points} poäng");
                            Console.WriteLine($"Ordet är :{word}");
                            for (int i = 0; i < guessword.Length; i++)
                                Console.Write(guessword[i] + " ");
                            Console.WriteLine();
                            string input = Console.ReadLine();
                            input.ToLower();
                            if (input == word)
                            {
                                Console.WriteLine($"Du gissade rätt och har {lives} liv kvar");
                                word = words[random.Next(0, 6)];
                                guessword = new string[word.Length];
                                for (int i = 0; i < word.Length; i++)
                                    guessword[i] = "_";
                                points++;

                            }
                            else
                            { 
                                guessword = StringComparer(input, word, guessword);
                                lives--;
                            }

                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        game = false;
                        break;
                }
            }

        }
    }
}
