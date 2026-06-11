using System;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.VisualBasic;

class GameLogic
{
    public bool is_game_continuing { get; private set; } = false;
    public int difficulty { get; private set; } = 0;

    public bool challenge_mode { private set; get; } = false;
    public bool new_game_plus { private set; get; } = false;

    private int number_of_tries { set; get; } = 1000000;

    private Random generator = new Random();
    public int current_number { get; private set; }

    public int generate_new_number(int difficulty)
    {
        switch (difficulty)
        {
            case 1:
                current_number = generator.Next(1, 101);
                break;
            case 2:
                current_number = generator.Next(1, 250);
                break;
            case 3:
                current_number = generator.Next(1, 500);
                break;
        }
        return current_number;
    }

    public void ChooseMode() // this function is for seting value of new_game_plus
    {
        int line_index = 28;

        UiFunctions.ClearMenu();
        UiFunctions.ClearPrint(27, Settings.english_mode ? "Choose game mode" : "Wybierz tryb gry");
        UiFunctions.ClearPrint(28, Settings.english_mode ? "1. Classic" : "1. Klasyczny");
        UiFunctions.ClearPrint(29, Settings.english_mode ? "2. New game plus (every 6 tries new number is generated)" : "2. Nowa gra plus (co 6 prób nowa liczba)");

        Console.Clear();
        Console.WriteLine(UiFunctions.ColorSelection(line_index));
        bool mode_is_chosen = false;

        while (mode_is_chosen == false)
        {
            ConsoleKey x = ConsoleKey.NoName;
            while (x != ConsoleKey.UpArrow && x != ConsoleKey.DownArrow && x != ConsoleKey.Enter)
            {
                x = Console.ReadKey(true).Key;
            }

            if (x == ConsoleKey.UpArrow)
            {
                if (line_index > 28)
                {
                    line_index--;
                }
            }
            else if (x == ConsoleKey.DownArrow)
            {
                if (line_index < 29)
                {
                    line_index++;
                }
            }
            else if (x == ConsoleKey.Enter && (line_index == 28 || line_index == 29))
            {
                mode_is_chosen = true;
                if (line_index == 29)
                {
                    new_game_plus = true;
                }
            }

            Console.Clear();
            Console.WriteLine(UiFunctions.ColorSelection(line_index));
        }
    }

    public void ChooseDifficulty() // this function is for seting value of difficulty
    {
        int line_index = 28;
        Console.Clear();
        UiFunctions.ClearMenu();

        UiFunctions.ClearPrint(27, Settings.english_mode ? "Choose the difficulty" : "Wybierz poziom trudności");
        UiFunctions.ClearPrint(28, Settings.english_mode ? "1. Easy 1-100" : "1. Łatwy 1-100");
        UiFunctions.ClearPrint(29, Settings.english_mode ? "2. Medium 1-250" : "2. Średni 1-250");
        UiFunctions.ClearPrint(30, Settings.english_mode ? "3. Hard 1-500" : "3. Trudny 1-500");

        Console.Clear();
        Console.WriteLine(UiFunctions.ColorSelection(line_index));

        bool difficulty_is_chosen = false;

        while (!difficulty_is_chosen)
        {
            ConsoleKey x = ConsoleKey.NoName;
            while (x != ConsoleKey.UpArrow && x != ConsoleKey.DownArrow && x != ConsoleKey.Enter)
            {
                x = Console.ReadKey(true).Key;
            }

            if (x == ConsoleKey.UpArrow)
            {
                if (line_index > 28)
                {
                    line_index--;
                }
            }
            else if (x == ConsoleKey.DownArrow)
            {
                if (line_index < 30)
                {
                    line_index++;
                }
            }
            else if (x == ConsoleKey.Enter && (line_index == 28 || line_index == 29 || line_index == 30))
            {
                if (line_index == 28)
                {
                    difficulty = 1;
                }
                else if (line_index == 29)
                {
                    difficulty = 2;
                }
                else if (line_index == 30)
                {
                    difficulty = 3;
                }
                difficulty_is_chosen = true;
            }

            Console.Clear();
            Console.WriteLine(UiFunctions.ColorSelection(line_index));
        }
    }

    public void Is_challenge_mode()
    {
        int choice_index = 29;
        Console.Clear();
        UiFunctions.ClearMenu();

        UiFunctions.ClearPrint(27, Settings.english_mode ? "Which mode do you want to play?" : "W jakim trybie chcesz zagrać?");
        UiFunctions.ClearPrint(28, Settings.english_mode ? "It's a mode with limited tries" : "Jest to tryb z ograniczoną liczbą prób");
        UiFunctions.ClearPrint(29, Settings.english_mode ? "1. Normal Mode" : "1. Tryb Normalny");
        UiFunctions.ClearPrint(30, Settings.english_mode ? "2. Challenge Mode" : "2. Tryb Wyzwania");

        Console.Clear();
        Console.WriteLine(UiFunctions.ColorSelection(choice_index));

        bool player_thinking = true;
        while (player_thinking == true)
        {
            ConsoleKeyInfo x = Console.ReadKey(true);

            if (x.Key == ConsoleKey.UpArrow)
            {
                if (choice_index > 29)
                {
                    Console.Clear();
                    choice_index--;
                }
            }

            if (x.Key == ConsoleKey.DownArrow)
            {
                if (choice_index < 30)
                {
                    choice_index++;
                }
            }

            if (x.Key == ConsoleKey.Enter)
            {
                if (choice_index == 29)
                {
                    return;
                }
                else
                {
                    UiFunctions.ClearMenu();
                    UiFunctions.ClearPrint(28, Settings.english_mode ? "You chose challenge mode" : "Wybrałeś tryb wyzwania");

                    string challenge_prompt = Settings.english_mode ? "Type maximum of 99 number of tries: " : "Wpisz maksymalnie 99 prób: ";
                    string result = UiFunctions.PlaceForWriting(challenge_prompt, 29, 2, true);
                    if (result == "-1") return;
                    number_of_tries = int.Parse(result);
                    challenge_mode = true;
                    return;
                }
            }
            Console.Clear();
            Console.WriteLine(UiFunctions.ColorSelection(choice_index));
        }
    }

    public void GameStart()
    {
        int number_to_guess = generate_new_number(difficulty); // LICZBA DO ZGADNIECAIA 

        if (!challenge_mode)
        {
            number_of_tries = 1000000;
        }

        if (new_game_plus)
        {
            number_of_tries = 6;
        }

        string number_of_tries_string = number_of_tries.ToString();
        UiFunctions.ClearMenu();
        Console.Clear();
        UiFunctions.ClearPrint(27, Settings.english_mode ? "Guess the number!" : "Zgadnij liczbę!");

        Stopwatch stoper = new Stopwatch();
        stoper.Start();

        int tries = 0;
       
        bool playing = true;
        while (playing)
        {
            
            tries++;
            if (challenge_mode && number_of_tries == 0)
            {
                UiFunctions.ClearMenu();
                UiFunctions.ClearPrint(28, Settings.english_mode ? "YOU LOST" : "PRZEGRAŁEŚ");
                UiFunctions.ClearPrint(29, Settings.english_mode ? "Press any key to continue" : "Naciśnij dowolny klawisz, aby kontynuować");
                ConsoleKeyInfo x = Console.ReadKey(true);
                return;
            }
            else if (new_game_plus && number_of_tries == 0)
            {
                number_to_guess = generate_new_number(difficulty);
                number_of_tries = 6;
                
            }

            if (challenge_mode)
            {
                UiFunctions.ClearPrint(29, "                                                ");
                string tries_left_text = Settings.english_mode ? "tries left: " : "pozostało prób: ";
                UiFunctions.ClearPrint(29, tries_left_text + number_of_tries_string);
            }
            else
            {

                string tries_used = Settings.english_mode ? "try : " : "próba: ";
                UiFunctions.ClearPrint(29, tries_used + tries);
            }




            int guessed_number = 0;
            string guess_prompt = Settings.english_mode ? "Your guess: " : "Twój strzał: ";
            int.TryParse(UiFunctions.PlaceForWriting(guess_prompt, 28, 3, true), out guessed_number);

            if (guessed_number == -1) { return; }
            Console.Clear();

            if (number_to_guess != guessed_number)
            {
                number_of_tries--;
                number_of_tries_string = number_of_tries.ToString();
                UiFunctions.ClearPrint(30, "                                                      ");
                UiFunctions.ClearPrint(30, UiFunctions.RandomComunicates(number_to_guess, guessed_number));
            }
            else
            {
                stoper.Stop();
                Player new_player = new Player();
                new_player.set_time(stoper.Elapsed.TotalSeconds);
                UiFunctions.ClearMenu();
                UiFunctions.ClearPrint(28, Settings.english_mode ? "YOU WON!!!" : "WYGRAŁEŚ!!!");
                UiFunctions.ClearPrint(30, (Settings.english_mode ? "POINTS: " : "PUNKTY: ") + (new_player.score - tries));
                UiFunctions.ClearPrint(31, (Settings.english_mode ? "TIME: " : "CZAS: ") + new_player.time_reached);

                if (challenge_mode)
                {
                    UiFunctions.ClearPrint(29, Settings.english_mode ? "ESC TO EXIT" : "ESC ABY WYJŚĆ");
                    bool escape = false;
                    while (!escape)
                    {
                        ConsoleKeyInfo xe = Console.ReadKey(true);
                        if (xe.Key == ConsoleKey.Escape) { return; }
                    }
                }



                new_player.set_points(tries);

                string name_prompt = Settings.english_mode ? "Type your name: " : "Wpisz swoje imię: ";
                new_player.set_pname(UiFunctions.PlaceForWriting(name_prompt, 29, 12, false));

                if (new_game_plus) { new_player.ngp(true); }
                new_player.new_difficulty(difficulty);
                HallOfFame.Add_player(new_player);
                return;
            }
        }
    }
}
// potestuj ten nowy tryb z generowaniem nowych liczb bo cos nie dzialalo