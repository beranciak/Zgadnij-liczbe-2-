using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

class Menu : BaseScreen
{
     
     private static readonly string PolishMenuCoreArt = @"
======================================================================================
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||     /$$$$$$$$  /$$$$$$   /$$$$$$  /$$$$$$$  /$$   /$$ /$$$$$$    /$$$$$          ||
||    |_____ $$  /$$__  $$ /$$__  $$| $$__  $$| $$$ | $$|_  $$_/   |__  $$          ||
||         /$$/ | $$  \__/| $$  \ $$| $$  \ $$| $$$$| $$  | $$        | $$          ||
||        /$$/  | $$ /$$$$| $$$$$$$$| $$  | $$| $$ $$ $$  | $$        | $$          ||
||       /$$/   | $$|_  $$| $$__  $$| $$  | $$| $$  $$$$  | $$   /$$  | $$          ||  
||      /$$/    | $$  \ $$| $$  | $$| $$  | $$| $$\  $$$  | $$  | $$  | $$          ||
||     /$$$$$$$$|  $$$$$$/| $$  | $$| $$$$$$$/| $$ \  $$ /$$$$$$|  $$$$$$/          ||
||    |________/ \______/ |__/  |__/|_______/ |__/  \__/|______/ \______/           ||
||                                                                                  || 
||     /$$       /$$$$$$  /$$$$$$  /$$$$$$$$ /$$$$$$$  /$$$$$$$$        /$$$$$$     || 
||    | $$      |_  $$_/ /$$__  $$|_____ $$ | $$__  $$| $$_____/       /$$__  $$    || 
||    | $$        | $$  | $$  \__/     /$$/ | $$  \ $$| $$            |__/  \ $$    || 
||    | $$        | $$  | $$          /$$/  | $$$$$$$ | $$$$$           /$$$$$$/    || 
||    | $$        | $$  | $$         /$$/   | $$__  $$| $$__/          /$$____/     ||
||    | $$        | $$  | $$    $$  /$$/    | $$  \ $$| $$            | $$          || 
||    | $$$$$$$$ /$$$$$$|  $$$$$$/ /$$$$$$$$| $$$$$$$/| $$$$$$$$      | $$$$$$$$    ||
||    |________/|______/ \______/ |________/|_______/ |________/      |________/    ||
||                                                                                  ||
||                                                                                  ||
|| _________________________________________________________________________________||
|| ///                                                                           \\\||
|| /                                                                               \||
||                                                                                  ||
||                                     NEW GAME                                     ||
||                                      OPTIONS                                     ||
||                                       EXIT                                       ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||\                                                                                /||
||\\\                                                                            ///||
======================================================================================
";

  
     private static readonly string EnglishMenuCoreArt = @"
======================================================================================
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                 /$$$$$$  /$$   /$$ /$$$$$$$$  /$$$$$$   /$$$$$$                  ||
||                /$$__  $$| $$  | $$| $$_____/ /$$__  $$ /$$__  $$                 ||
||               | $$  \__/| $$  | $$| $$      | $$  \__/| $$  \__/                 ||
||               | $$ /$$$$| $$  | $$| $$$$$   |  $$$$$$ |  $$$$$$                  ||
||               | $$|_  $$| $$  | $$| $$__/    \____  $$ \____  $$                 ||  
||               | $$  \ $$| $$  | $$| $$       /$$  \ $$ /$$  \ $$                 ||
||               |  $$$$$$/|  $$$$$$/| $$$$$$$$|  $$$$$$/|  $$$$$$/                 ||
||                \______/  \______/ |________/ \______/  \______/                  ||
||                                                                                  || 
||    /$$   /$$ /$$   /$$ /$$      /$$ /$$$$$$$  /$$$$$$$$ /$$$$$$$      /$$$$$$    || 
||   | $$$ | $$| $$  | $$| $$$    /$$$| $$__  $$| $$_____/| $$__  $$    /$$__  $$   || 
||   | $$$$| $$| $$  | $$| $$$$  /$$$$| $$  \ $$| $$      | $$  \ $$   |__/  \ $$   || 
||   | $$ $$ $$| $$  | $$| $$ $$/$$ $$| $$$$$$$ | $$$$$   | $$$$$$$/     /$$$$$$/   || 
||   | $$  $$$$| $$  | $$| $$  $$$| $$| $$__  $$| $$__/   | $$__  $$    /$$____/    ||
||   | $$\  $$$| $$  | $$| $$\  $ | $$| $$  \ $$| $$      | $$  \ $$   | $$         || 
||   | $$ \  $$|  $$$$$$/| $$ \/  | $$| $$$$$$$/| $$$$$$$$| $$  | $$   | $$$$$$$$   ||
||   |__/  \__/ \______/ |__/     |__/|_______/ |________/|__/  |__/   |________/   ||
||                                                                                  ||
||                                                                                  ||
|| _________________________________________________________________________________||
|| ///                                                                           \\\||
|| /                                                                               \||
||                                                                                  ||
||                                     NEW GAME                                     ||
||                                      OPTIONS                                     ||
||                                       EXIT                                       ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||                                                                                  ||
||\                                                                                /||
||\\\                                                                            ///||
======================================================================================
";

 
     public static string MenuCoreArt 
     { 
          get 
          {
               return Settings.english_mode ? EnglishMenuCoreArt : PolishMenuCoreArt;
          } 
     }

     public List<string> menu_list { get; private set; } = new List<string>() { "NEW  GAME", "OPTIONS", "EXIT", "HALL OF FAME" };

     public string GetIndexWord()
     {
          return menu_list[menu_index];
     }

     public bool menu_selceted { get; private set; } = false;
     public int menu_index = 28;
     private bool IsChoosed = false;
    public override BaseScreen Run()
     {
        // Musimy zresetować bufor ekranu na starcie
        UiFunctions.RefreshFrame(); 

        int current_line = 28;
        bool change = true;
        
        bool showHallOfFame = HallOfFame.Players.Count > 0; 
        
        int max_line = showHallOfFame ? 31 : 30;

        while (true)
        {
            if (change)
            {
                UiFunctions.ClearMenu();
                UiFunctions.ClearPrint(27, GetText("MENU GŁÓWNE", "MAIN MENU"));
                UiFunctions.ClearPrint(28, GetText("1. GRAJ", "1. PLAY"));

                if (showHallOfFame)
                {
                    UiFunctions.ClearPrint(29, GetText("2. TABLICA WYNIKÓW", "2. HALL OF FAME"));
                    UiFunctions.ClearPrint(30, GetText("3. OPCJE", "3. OPTIONS"));
                    UiFunctions.ClearPrint(31, GetText("4. WYJŚCIE", "4. EXIT"));
                }
                else
                {
                    UiFunctions.ClearPrint(29, GetText("2. OPCJE", "2. OPTIONS"));
                    UiFunctions.ClearPrint(30, GetText("3. WYJŚCIE", "3. EXIT"));
                }
                change = false;
            }

            Console.Clear();
            Console.WriteLine(UiFunctions.ColorSelection(current_line));

            ConsoleKeyInfo xi = Console.ReadKey(true);

            if (xi.Key == ConsoleKey.UpArrow && current_line > 28) 
            {
                current_line--;
            }
            else if (xi.Key == ConsoleKey.DownArrow && current_line < max_line) 
            {
                current_line++;
            }
            else if (xi.Key == ConsoleKey.Enter)
            {
                switch (current_line)
                {
                    case 28: 
                        return new GameLogic(); 
                        
                    case 29: 
                        if (showHallOfFame) return new HallOfFame();
                        else return new Settings(); 
                        
                    case 30: 
                        if (showHallOfFame) return new Settings(); 
                        else return null;
                        
                    case 31: 
                        if (showHallOfFame) return null;
                        break;
                }
            }
        }
    }
}