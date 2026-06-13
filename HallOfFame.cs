using System;
using System.Linq;
using System.Collections.Generic;

public class HallOfFame : BaseScreen
{
    private static List<Player> player_list = new List<Player>();
    public static IReadOnlyList<Player> Players => player_list;

    public static void Add_player(Player new_player)
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

    public override BaseScreen Run()
    {
        int difficulty = HOF_difficulty();
        ShowHOF(difficulty);
        
        return new Menu();
    }

    private int HOF_difficulty()
    {
        int line_index = 28;
        int HOF_difficulty = 1;
        bool difficulty_is_choosed = false;
        bool change = true; 
        
        while (!difficulty_is_choosed)
        {
            if (change)
            {
                UiFunctions.ClearMenu();
                UiFunctions.ClearPrint(27, GetText("Jaki poziom trudności chcesz zobaczyć?", "Which difficulty do you want to see?"));
                UiFunctions.ClearPrint(28, GetText("1. ŁATWY", "1. EASY"));
                UiFunctions.ClearPrint(29, GetText("2. ŚREDNI", "2. MEDIUM"));
                UiFunctions.ClearPrint(30, GetText("3. TRUDNY", "3. HARD"));
                change = false;
            }

            Console.Clear();
            Console.WriteLine(UiFunctions.ColorSelection(line_index));

            ConsoleKeyInfo x = Console.ReadKey(true);

            if (x.Key == ConsoleKey.UpArrow && line_index > 28) line_index--;
            else if (x.Key == ConsoleKey.DownArrow && line_index < 30) line_index++;
            else if (x.Key == ConsoleKey.Enter)
            {
                if (line_index == 28) HOF_difficulty = 1;
                else if (line_index == 29) HOF_difficulty = 2;
                else if (line_index == 30) HOF_difficulty = 3;
                
                difficulty_is_choosed = true;
            }
        }
       return HOF_difficulty; 
    }

    private void ShowHOF(int difficulty)
    {
     
        UiFunctions.ClearMenu();
        UiFunctions.ClearPrint(27, GetText(" TABLICA WYNIKÓW ", " HALL OF FAME "));
        UiFunctions.ClearPrint(33, GetText("                                    ESC aby wyjść", "                                    ESC to exit"));
        
        List<Player> filtered_players = player_list.Where(p => p.difficulty == difficulty).ToList();

        int line = 28;
        for (int x = 0; x < 5; x++)
        {
            if (x < filtered_players.Count)
            {
                Player p = filtered_players[x];
                string points_suffix = GetText("pkt", "p");
                
                if (p.new_game_plus == true)
                {
                    UiFunctions.ClearPrint(line, $"{x + 1}. NG+  {p.name} | {p.score} {points_suffix} | {p.time_reached:F2} s");
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

     
        UiFunctions.Render();

        bool isshowing = true;
        while (isshowing)
        {
            ConsoleKeyInfo xi = Console.ReadKey(true);
            if (xi.Key == ConsoleKey.Escape)
            {
                isshowing = false;
            }
        }
    }
}