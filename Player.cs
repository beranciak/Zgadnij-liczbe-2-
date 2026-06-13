using System;
using System.Runtime.CompilerServices;



public class Player
{
    
  
    
    public int difficulty {get; private set;} 
    public string name { get; private set; } = "";
    public double time_reached { get; private set; } = 0;
    public int score { get; private set; } = 1000;

    public bool new_game_plus {get; private set;} = false; 

    public void set_points(int tries)
    {
        score -= tries;
    }
    public void set_time(double time)
    {
        time_reached = time;
    }

    public void set_pname(string new_name)
    {
        name = new_name;
    }
    
    public void ngp(bool is_ngp)
    {
        new_game_plus = is_ngp;
    }

    public void new_difficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }


}