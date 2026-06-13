using System;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
 
public static class UiFunctions
{
    private static Random generator = new Random();
 
    private static string Mark(string wordtomark)
    {
        string start_line = "<>";
        string end_line = "<>";
        return start_line + wordtomark + end_line;
    }
 
    public static string ColorSelection(int LineMarked)
    {
        string[] lines = copy.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        string word_toreplace = "";
        char[] LineArray = lines[LineMarked].ToCharArray();
 
        for (int i = 0; i < LineArray.Length; i++)
        {
            char c = LineArray[i];
            if (c == ' ' && i > 0 && i < LineArray.Length - 1 && LineArray[i - 1] != ' ' && LineArray[i + 1] != ' ')
            {
                word_toreplace += " ";
            }
            if (c != ' ' && c != '|')
            {
                word_toreplace += c;
            }
        }
        if (word_toreplace == "")
        {
            return copy;
        }
 
        string word_with_spaces = "  " + word_toreplace + "  ";
        string newtext = copy.Replace(word_with_spaces, Mark(word_toreplace));
        return newtext;
    }
 
    public static string copy { private set; get; } = Menu.MenuCoreArt;
 
    public static string GetCopy()
    {
        return copy;
    }
 
    public static void RefreshFrame()
    {
        copy = Menu.MenuCoreArt;
    }
 
   
   
    public static void ClearPrint(int line, string text)
    {
        string[] lines = copy.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        char[] TextArray = lines[line].ToCharArray();
 
        int line_length = lines[line].Length;
        int text_length = text.Length;
        int diffrence = (line_length - text_length) / 2;
 
        for (int i = diffrence; i < diffrence + text_length; i++)
        {
            TextArray[i] = text[i - diffrence];
        }
 
        lines[line] = new string(TextArray);
        copy = string.Join(Environment.NewLine, lines);
    }
 
    public static void Render()
    {
        Console.Clear();
        Console.WriteLine(copy);
    }
 
    
    public static void ClearMenu()
    {
        for (int i = 27; i < 38; i++)
        {
            ClearPrint(i, new string(' ', 82));
        }
        Render();
    }
 
    public static string PlaceForWriting(string what_will_be_writed, int which_line, int max_length, bool only_numbers)
    {
        ClearPrint(33, Settings.english_mode ? "                                    ESC to exit" : "                                    ESC aby wyjść");
        string front = what_will_be_writed;
        string writed_string = "";
        string place_for_typing = new string('_', max_length);
        char[] place_for_typing_array = place_for_typing.ToArray();
 
        ClearPrint(which_line, front + place_for_typing);
        Render();
 
        while (true)
        {
            ConsoleKeyInfo x = Console.ReadKey(true);
            char char_key = x.KeyChar;
 
            if (x.Key == ConsoleKey.Enter)
            {
                return writed_string;
            }
 
            if (x.Key == ConsoleKey.Escape)
            {
                return "-1";
            }
 
            if (x.Key == ConsoleKey.Backspace && writed_string.Length > 0)
            {
                int index_to_remove = writed_string.Length - 1;
                place_for_typing_array[index_to_remove] = '_';
                writed_string = writed_string.Remove(index_to_remove);
                place_for_typing = new string(place_for_typing_array);
                ClearPrint(which_line, front + place_for_typing);
                Render();
                continue;
            }
 
            if (writed_string.Length < max_length)
            {
                if (only_numbers)
                {
                    int key = 10;
                    bool is_number = int.TryParse(char_key.ToString(), out key);
                    if (is_number)
                    {
                        place_for_typing_array[writed_string.Length] = x.KeyChar;
                        writed_string += key;
                        place_for_typing = new string(place_for_typing_array);
                        ClearPrint(which_line, front + place_for_typing);
                        Render();
                    }
                }
                else if (!char.IsControl(char_key))
                {
                    place_for_typing_array[writed_string.Length] = x.KeyChar;
                    writed_string += char_key;
                    place_for_typing = new string(place_for_typing_array);
                    ClearPrint(which_line, front + place_for_typing);
                    Render();
                }
            }
        }
    }
 
    public static string RandomComunicates(int number_to_guess, int number_writed)
    {
        int generated_number = generator.Next(1, 6);
        if (Settings.english_mode)
        {
            if (number_to_guess > number_writed)
            {
                switch (generated_number)
                {
                    case 1: return "Too low! Try entering a larger number.";
                    case 2: return "You're aiming too low. Go higher!";
                    case 3: return "My number is bigger. Keep trying!";
                    case 4: return "You're on the right track, but you need to aim higher.";
                    case 5: return "Value is too small! Search in a higher range.";
                    default: return "Too low! Try entering a larger number.";
                }
            }
            else
            {
                switch (generated_number)
                {
                    case 1: return "Too high! Try entering a smaller number.";
                    case 2: return "You overshot! My number is smaller.";
                    case 3: return "You're aiming too high. Come down a bit!";
                    case 4: return "Oops, the value is too high! Try something smaller.";
                    case 5: return "Almost there! But you need to aim a little lower.";
                    default: return "Too high! Try entering a smaller number.";
                }
            }
        }
        else
        {
            if (number_to_guess > number_writed)
            {
                switch (generated_number)
                {
                    case 1: return "Za mało! Spróbuj wpisać większą liczbę.";
                    case 2: return "Celujesz zbyt nisko. Podnieś trochę stawkę!";
                    case 3: return "Moja liczba jest większa. Próbuj dalej!";
                    case 4: return "Jesteś na dobrym tropie, ale musisz celować wyżej.";
                    case 5: return "Zbyt mała wartość! Szukaj w wyższych przedziałach.";
                    default: return "Za mało! Spróbuj wpisać większą liczbę.";
                }
            }
            else
            {
                switch (generated_number)
                {
                    case 1: return "Za dużo! Spróbuj wpisać mniejszą liczbę.";
                    case 2: return "Przestrzeliłeś! Moja liczba jest mniejsza.";
                    case 3: return "Celujesz zbyt wysoko. Zejdź trochę w dół!";
                    case 4: return "Ups, za wysoka wartość! Spróbuj czegoś mniejszego.";
                    case 5: return "Prawie, prawie! Ale musisz celować odrobinę niżej.";
                    default: return "Za dużo! Spróbuj wpisać mniejszą liczbę.";
                }
            }
        }
    }
}
 