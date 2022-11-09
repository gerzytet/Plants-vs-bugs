
public class ItemStack
{
    public int count;
    public Item item;
    
    public ItemStack(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }
    
    public ItemStack(Item item)
    {
        this.item = item;
        this.count = 1;
    }
}