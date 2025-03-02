using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Inventory
{
    private Tuple<int,int> Size;
    private Tuple<int,int> InventoryPosition;
    private Dictionary<string,Tuple<int,int>> BaseInventoryData; // item name,position(x,y)
    private Dictionary<string,string> EquippedInventoryData; // item name, item position.
    private Texture2D InventoryTexture;
    public Inventory()
    {
        LoadInventoryData();// here we create the inventory base on saved data or as a new Dictionary of items and positions.
    }

    public void LoadInventoryData()
    {
        bool inventorySavedData = false; // this is the marker for loding the inventory saved holdings
        if(inventorySavedData == false)
        {
            BaseInventoryData = new Dictionary<string,Tuple<int,int>>();
        }

    }

    public Tuple<int,int> GetInventorySize()
    {
        //HERE CALCULATE SIZE
        return this.Size;
    }

    public Tuple<int,int> GetItemPosition(string itemName)
    {
        return BaseInventoryData.GetValueOrDefault(itemName);
    }

    public string GetItemPosition(Tuple<int,int> itemLocation)
    {
        return BaseInventoryData.GetValueOrDefault(itemLocation).ToString();
    }

    public bool SetInventoryTexture(Texture2D texture)
    {
        //HERE CALCULATE SIZE
        this.InventoryTexture = texture;
        return true;
    }

    public Dictionary<string,Tuple<int,int>> LoadEmptyInventory()
    {
        BaseInventoryData = new Dictionary<string,Tuple<int,int>>();
        for(int x = 0; x < GetInventorySize().Item1; x++)
        {
            for(int y = 0; y < GetInventorySize().Item2; y++)
            {
                BaseInventoryData.Add(("Item X: " + x + " Y: " + y ),new Tuple<int,int>(x,y));
            }
        }
        return null;
    }
    public void Update(){}

    public void Draw(){}
}
