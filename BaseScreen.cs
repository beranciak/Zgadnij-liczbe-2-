using System;
public abstract class BaseScreen
{
    protected string GetText(string polish, string english)
    {
        return Settings.english_mode ? english : polish;
    }

    public abstract BaseScreen Run();
}