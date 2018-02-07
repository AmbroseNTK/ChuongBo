using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Item : IItemAction
{
    private string itemID;
    private int quantity;
    private string itemName;
    private string caption;

    public string ItemID
    {
        get
        {
            return itemID;
        }

        set
        {
            itemID = value;
        }
    }

    public int Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            quantity = value;
        }
    }

    public string ItemName
    {
        get
        {
            return itemName;
        }

        set
        {
            itemName = value;
        }
    }

    public string Caption
    {
        get
        {
            return caption;
        }

        set
        {
            caption = value;
        }
    }

    public Item()
    {
        ItemID = "";
        Quantity = 0;
        ItemName = "";
        Caption = "";
    }

    public Item(string itemID, int quantity)
    {
        this.ItemID = itemID;
        this.Quantity = quantity;
    }

    public void Show()
    {
        throw new NotImplementedException();
    }

    public void Open()
    {
        throw new NotImplementedException();
    }

    public void Use()
    {
        throw new NotImplementedException();
    }
}