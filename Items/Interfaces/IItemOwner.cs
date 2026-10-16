namespace ConsoleGame.Items.Interfaces;

public interface IItemOwner

{
    List<Item> InventoryItems {get; protected set;}
    public void RemoveItem(Item item);
    public void SellItem(Item item);

    public void GiveItem(Item item, IItemOwner newOwner);

    public void ReceiveItem(Item item);
}