using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

static class Settings
{
   public static bool english_mode { private set; get; } = false;
   public static bool challange_question { private set; get; } = true;






   public static void ShowOptions()
   {
      







      int current_line = 28;

      bool options_run = true;
      while (options_run)
      {
        
         UiFunctions.ClearMenu();

         UiFunctions.ClearPrint(27, Settings.english_mode ? "OPTIONS" : "OPCJE");
         UiFunctions.ClearPrint(28, (Settings.english_mode ? "CHANGE LANGUAGE: " : "ZMIEŃ JĘZYK: ") + (Settings.english_mode ? "ENGLISH" : "POLSKI"));
         UiFunctions.ClearPrint(29, Settings.english_mode ? "CLEAR HALL OF FAME" : "WYCZYŚĆ TABLICĘ WYNIKÓW");
         UiFunctions.ClearPrint(30, (Settings.english_mode ? "CHALLENGE MODE QUESTION: " : "PYTANIE TRYBU WYZWANIA: ") + (Settings.challange_question ? (Settings.english_mode ? "ON" : "WLĄCZONE") : (Settings.english_mode ? "OFF" : "WYŁĄCZONE")));
         UiFunctions.ClearPrint(31, Settings.english_mode ? "EXIT" : "WYJŚCIE");
         Console.Clear();
         Console.WriteLine(UiFunctions.ColorSelection(current_line));
         ConsoleKeyInfo xi = Console.ReadKey(true);

         if (xi.Key == ConsoleKey.UpArrow)
         {
            if (current_line > 28)
            {
               current_line--;
            }
         }
         else if (xi.Key == ConsoleKey.DownArrow)
         {
            if (current_line < 31)
            {
               current_line++;
            }
         }

         if (xi.Key == ConsoleKey.Enter && (current_line == 28 || current_line == 29 || current_line == 30 || current_line == 31))
         {
            switch (current_line)
            {
               case 28:
                  {
                     Settings.english_mode = !english_mode;
                     UiFunctions.RefreshFrame();
                     break;
                  }
               case 29:
                  {
                     int line = 28;
                     bool areusure = false;
                     while (!areusure)
                     {

                        UiFunctions.ClearMenu();

                        Console.Clear();
                        UiFunctions.ClearPrint(27, Settings.english_mode ? "ARE YOU SURE YOU WANT TO CLEAR HALL OF FAME?" : "CZY NA PEWNO CHCESZ WYCZYŚCIĆ TABLICĘ WYNIKÓW?");
                        UiFunctions.ClearPrint(28, Settings.english_mode ? "1. YES" : "1. TAK");
                        UiFunctions.ClearPrint(29, Settings.english_mode ? "2. NO" : "2. NIE");
                        Console.Clear();
                        Console.WriteLine(UiFunctions.ColorSelection(line));

                        ConsoleKeyInfo xe = Console.ReadKey(true);

                        if (xe.Key == ConsoleKey.UpArrow)
                        {
                           if (line > 28)
                           {
                              line--;
                           }
                        }
                        else if (xe.Key == ConsoleKey.DownArrow)
                        {
                           if (line < 29)
                           {
                              line++;
                           }
                        }


                        if (xe.Key == ConsoleKey.Enter && (line == 28 || line == 29))
                        {
                           if (line == 28)
                           {
                              HallOfFame.ClearList();
                              areusure = true;
                           }
                           else { break; }

                        }
                     }
                     break;
                  }
               case 30:
                  {
                     challange_question = !challange_question;
                     break;
                  }
               case 31:
                  {
                     options_run = false;
                     break;

                  }

            }
         }
      }
      return;
   }
}


// dodaj wynik i czas do ekranu won









