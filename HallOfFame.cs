using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Diagnostics;

static class HallOfFame
{

    static private List<Player> player_list = new List<Player>();
    static public IReadOnlyList<Player> Players => player_list;
    static public void Add_player(Player new_player)
    {
        player_list.Add(new_player);

        player_list = player_list
         .OrderByDescending(p => p.score)
         .ThenBy(p => p.time_reached)
         .ToList();

    }

    public static void ClearList()
    {
        player_list.Clear();
    }


    static public int HOF_difficulty()
    {
        Console.Clear();
        UiFunctions.ClearMenu();
        
        // TŁUMACZENIA W locie
        UiFunctions.ClearPrint(27, Settings.english_mode ? "Which difficulty do you want to see?" : "Jaki poziom trudności chcesz zobaczyć?");
        UiFunctions.ClearPrint(28, Settings.english_mode ? "1. EASY" : "1. ŁATWY");
        UiFunctions.ClearPrint(29, Settings.english_mode ? "2. MEDIUM" : "2. ŚREDNI");
        UiFunctions.ClearPrint(30, Settings.english_mode ? "3. HARD" : "3. TRUDNY");
        
        int HOF_difficulty = 1;
        int line_index = 28;
        Console.Clear();
        Console.WriteLine(UiFunctions.ColorSelection(line_index));
        bool difficulty_is_choosed = false;
        
        while (difficulty_is_choosed == false)
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
                    HOF_difficulty = 1;
                }
                else if (line_index == 29)
                {
                    HOF_difficulty = 2;
                }
                else if (line_index == 30)
                {
                     HOF_difficulty = 3;
                }
                difficulty_is_choosed = true;
            }

            Console.Clear();
            Console.WriteLine(UiFunctions.ColorSelection(line_index));
        }
       return HOF_difficulty; 
    }

    static public void ShowHOF(int difficulty)
    {
        bool isshowing = true;
        while (isshowing)
        {

            UiFunctions.ClearMenu();
            Console.Clear();
            
            // TŁUMACZENIA W locie
            UiFunctions.ClearPrint(27, Settings.english_mode ? " HALL OF FAME " : " TABLICA WYNIKÓW ");
            UiFunctions.ClearPrint(33, Settings.english_mode ? "                                    ESC to exit" : "                                    ESC aby wyjść");
            
            List<Player> filtered_players = player_list.Where(p => p.difficulty == difficulty).ToList();

            int line = 28;
            for (int x = 0; x < 5; x++)
            {

                if (x < filtered_players.Count)
                {
                    Player p = filtered_players[x];
                    string points_suffix = Settings.english_mode ? "p" : "pkt";
                    
                    if (p.new_game_plus == true)
                    {
                        
                        UiFunctions.ClearPrint(line, $"{x + 1}. NG+  {p.name} | {p.score} {points_suffix} | {p.time_reached:F2} s");
                        Console.Clear();
                        Console.WriteLine(UiFunctions.ColorSelection(line));
                    }
                    else
                    {
                        UiFunctions.ClearPrint(line, $"{x + 1}. {p.name} | {p.score} {points_suffix} | {p.time_reached:F2} s");
                    }
                }
                else
                {
                    UiFunctions.ClearPrint(line, $"{x + 1}. ---");
                }
                line++;
            }
            ConsoleKeyInfo xi = Console.ReadKey(true);
            if (xi.Key == ConsoleKey.Escape)
            {
                isshowing = false;
            }
        }
    }
}