using System;

public static class Score
{
    public static int CurrentScore { get; private set; }
    public static event Action<int> ScoreChanged;

    public static void Increase(int amount)
    {
        CurrentScore += amount;
        ScoreChanged?.Invoke(CurrentScore);
    }

    public static void Reset()
    {
        CurrentScore = 0;
    }
}