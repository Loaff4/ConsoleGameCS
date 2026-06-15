namespace Items.Interfaces;

public interface IItemOwner
{
    List<BaseItem> InventoryItems {get; protected set;}
    public void DeleteItem(BaseItem item);
    public void SellItem(BaseItem item);

}