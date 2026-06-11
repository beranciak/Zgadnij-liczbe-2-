using System;



class Program
{
    static void Main(string[] args)
    {


        Menu EnglishMenu = new Menu();


        int number_of_selected_menu = 28; // first menu index  = new game 
        bool gamerun = true;
        while (gamerun)
        {
            number_of_selected_menu = EnglishMenu.MenuStart();

            switch (number_of_selected_menu)
            {
                case 28:
                    {
                        GameLogic MainGame = new GameLogic();

                        MainGame.ChooseMode();

                        if (MainGame.new_game_plus == false && Settings.challange_question == true) MainGame.Is_challenge_mode();

                        MainGame.ChooseDifficulty();
                        MainGame.GameStart();
                        break;
                    }
                case 29:
                    {
                        Settings.ShowOptions();
                        break;
                    }
                case 30:
                    {
                        if (HallOfFame.Players.Count > 0)
                        {
                            HallOfFame.ShowHOF(HallOfFame.HOF_difficulty());
                        }
                        else
                        {
                            gamerun = false;
                        }
                        break;
                    }
                case 31:
                    {
                        gamerun = false;
                        break;
                    }


            }
        }





    }
}


