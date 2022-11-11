
public enum Item
{
    HOE, Wood_SEEDS, EMPTY, INVALID, CACTUS_SEEDS, MUSHROOM_SEEDS, DANDELION_SEEDS, SUNFLOWER_SEEDS
}

public static class Items
{
    public static string Name(this Item item)
    {
        switch (item)
        {
            case Item.HOE:
                return "Hoe";
            case Item.Wood_SEEDS:
                return "Tree Seed";
            case Item.EMPTY:
                return "Empty";
            case Item.INVALID:
                return "Invalid";
            case Item.CACTUS_SEEDS:
                return "Sharpshooter Seed";
            case Item.MUSHROOM_SEEDS:
                return "Hypno-candy";
            case Item.DANDELION_SEEDS:
                return "Spikedelion Seed";
            case Item.SUNFLOWER_SEEDS:
                return "Sunflower Seed";
            default:
                return "Unknown";
        }
    }

    public static bool IsSeeds(this Item item)
    {
        switch (item)
        {
            case Item.SUNFLOWER_SEEDS:
            case Item.Wood_SEEDS:
            case Item.CACTUS_SEEDS:
            case Item.MUSHROOM_SEEDS:
            case Item.DANDELION_SEEDS:
                return true;
            default:
                return false;
        }
    }
}