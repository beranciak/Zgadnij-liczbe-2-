using System;
class Program
{
    static void Main(string[] args)
    {
        

        BaseScreen currentScreen = new Menu();

        while(currentScreen != null)
        {
            currentScreen = currentScreen.Run();
        }
    }
}