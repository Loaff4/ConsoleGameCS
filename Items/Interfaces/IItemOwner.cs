namespace ConsoleGame.Items.Interfaces;

public interface IItemOwner

{
    List<BaseItem> InventoryItems {get; protected set;}
    public void DeleteItem(BaseItem item);
    public void SellItem(BaseItem item);

    public void GiveItem(BaseItem item, IItemOwner newOwner);

    public void ReceiveItem(BaseItem item);
}