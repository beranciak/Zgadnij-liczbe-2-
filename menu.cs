using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

class Menu
{
     // POLSKA WERSJA ASCII ART Z RAMKĄ (Twój polski napis wpisany w ramkę)
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

     // ANGIELSKA WERSJA ASCII ART Z RAMKĄ
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

     // Właściwość, która dynamicznie wydaje odpowiednie ASCII ART
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
     
     public int MenuStart()
     {
          UiFunctions.ClearMenu();
          
          // TŁUMACZENIA W locie ZA POMOCĄ Settings.english_mode
          UiFunctions.ClearPrint(28, Settings.english_mode ? "PLAY" : "GRAJ");
          UiFunctions.ClearPrint(29, Settings.english_mode ? "OPTIONS" : "OPCJE");

          if (HallOfFame.Players.Count > 0)
          {
               UiFunctions.ClearPrint(30, Settings.english_mode ? "HALL OF FAME" : "TABLICA WYNIKÓW");
               UiFunctions.ClearPrint(31, Settings.english_mode ? "EXIT" : "WYJŚCIE");
          }
          else
          {
               UiFunctions.ClearPrint(30, Settings.english_mode ? "EXIT" : "WYJŚCIE");
          }


          Console.Clear();
          Console.WriteLine(UiFunctions.ColorSelection(menu_index));

          while (IsChoosed == false)
          {

               ConsoleKey x = ConsoleKey.NoName;

               while (x != ConsoleKey.UpArrow && x != ConsoleKey.DownArrow && x != ConsoleKey.Enter)
               {
                    x = Console.ReadKey(true).Key;

               }

               if (x == ConsoleKey.UpArrow)
               {
                    if (menu_index > 28)
                    {
                         menu_index--;
                    }
               }
               else if (x == ConsoleKey.DownArrow)
               {
                    if (HallOfFame.Players.Count > 0)
                    {

                         if (menu_index < 31)
                         {
                              menu_index++;
                         }
                    }
                    else
                    {

                         if (menu_index < 30)
                         {
                              menu_index++;
                         }
                    }
               }
               else if (x == ConsoleKey.Enter && (menu_index == 28 || menu_index == 29 || menu_index == 30 || (menu_index == 31 && HallOfFame.Players.Count > 0)))
               {
                    menu_selceted = true;
                    return menu_index;
               }

               Console.Clear();
               Console.WriteLine(UiFunctions.ColorSelection(menu_index));
          }

          return 3;
     }
}