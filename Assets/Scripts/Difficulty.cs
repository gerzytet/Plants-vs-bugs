public enum Difficulty
{
    EASY, NORMAL, HARD
}

public static class Difficulties
{
    public static float CostMultiplier(this Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                return 0.75f;
            case Difficulty.NORMAL:
                return 1.0f;
            case Difficulty.HARD:
                return 1.5f;
            default:
                return 1f;
        }
    }
    
    public static float BugMultiplier(this Difficulty difficulty)
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                return 0.75f;
            case Difficulty.NORMAL:
                return 1.0f;
            case Difficulty.HARD:
                return 1.5f;
            default:
                return 1f;
        }
    }
}