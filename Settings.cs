using System;

public class Settings : BaseScreen
{
   public static bool english_mode { get; set; } = false;
   public static bool challange_question { get; set; } = true;

   public override BaseScreen Run()
   {
      int current_line = 28;
      bool change = true; 

      while (true)
      {
         if (change)
         {
            UiFunctions.ClearMenu();
            
            UiFunctions.ClearPrint(27, GetText("OPCJE", "OPTIONS"));
            UiFunctions.ClearPrint(28, GetText("ZMIEŃ JĘZYK: ", "CHANGE LANGUAGE: ") + GetText("POLSKI", "ENGLISH"));
            UiFunctions.ClearPrint(29, GetText("WYCZYŚĆ TABLICĘ WYNIKÓW", "CLEAR HALL OF FAME"));
            UiFunctions.ClearPrint(30, GetText("PYTANIE TRYBU WYZWANIA: ", "CHALLENGE MODE QUESTION: ") + (challange_question ? GetText("WŁĄCZONE", "ON") : GetText("WYŁĄCZONE", "OFF")));
            UiFunctions.ClearPrint(31, GetText("WYJŚCIE", "EXIT"));
            change = false;
         }

         Console.Clear();
         Console.WriteLine(UiFunctions.ColorSelection(current_line));
         
         ConsoleKeyInfo xi = Console.ReadKey(true);

         if (xi.Key == ConsoleKey.UpArrow && current_line > 28) current_line--;
         else if (xi.Key == ConsoleKey.DownArrow && current_line < 31) current_line++;
         else if (xi.Key == ConsoleKey.Enter)
         {
            change = true;
            switch (current_line)
            {
               case 28:
                  english_mode = !english_mode;
                  UiFunctions.RefreshFrame();
                  break;
                  
               case 29:
                  int line = 28;
                  bool areusure = false;
                  bool podmenu_change = true;
                  
                  while (!areusure)
                  {
                     if(podmenu_change)
                     {
                        UiFunctions.ClearMenu();
                        UiFunctions.ClearPrint(27, GetText("CZY NA PEWNO CHCESZ WYCZYŚCIĆ TABLICĘ WYNIKÓW?", "ARE YOU SURE YOU WANT TO CLEAR HALL OF FAME?"));
                        UiFunctions.ClearPrint(28, GetText("1. TAK", "1. YES"));
                        UiFunctions.ClearPrint(29, GetText("2. NIE", "2. NO"));
                        podmenu_change = false;
                     }

                     Console.Clear();
                     Console.WriteLine(UiFunctions.ColorSelection(line));

                     ConsoleKeyInfo xe = Console.ReadKey(true);

                     if (xe.Key == ConsoleKey.UpArrow && line > 28) line--;
                     else if (xe.Key == ConsoleKey.DownArrow && line < 29) line++;
                     else if (xe.Key == ConsoleKey.Enter && (line == 28 || line == 29))
                     {
                        if (line == 28)
                        {
                           HallOfFame.ClearList();
                        }
                        areusure = true;
                     }
                  }
                  break;
                  
               case 30:
                  challange_question = !challange_question;
                  break;
                  
               case 31:
                  return new Menu();
            }
         }
      }
   }
}