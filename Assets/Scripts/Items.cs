
public enum Item
{
    HOE, SEEDS, EMPTY, INVALID, CACTUS_SEEDS
}

public static class Items
{
    public static string Name(this Item item)
    {
        switch (item)
        {
            case Item.HOE:
                return "Hoe";
            case Item.SEEDS:
                return "Seeds";
            case Item.EMPTY:
                return "Empty";
            case Item.INVALID:
                return "Invalid";
            case Item.CACTUS_SEEDS:
                return "Cactus Seeds";
            default:
                return "Unknown";
        }
    }

    public static bool IsSeeds(this Item item)
    {
        switch (item)
        {
            case Item.SEEDS:
            case Item.CACTUS_SEEDS:
                return true;
            default:
                return false;
        }
    }
}