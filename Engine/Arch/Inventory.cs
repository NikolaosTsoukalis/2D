using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Inventory
{
    private Tuple<int,int> InventorySize;
    private Dictionary<string,Tuple<int,int>> BaseInventoryData; // item name,position(x,y)
    private Dictionary<string,string> EquippedInventoryData; // item name, item position.
    private Texture2D InventoryTexture;
    
    private Rectangle Position;
    public Inventory()
    {
        LoadInventoryData();// here we create the inventory base on saved data or as a new Dictionary of items and positions.
    }

    public void LoadInventoryData()
    {
        bool inventorySavedData = false; // this is the marker for loding the inventory saved holdings
        if(inventorySavedData == false)
        {
            LoadEmptyInventory();
        }
    }

    public Tuple<int,int> GetInventorySize()
    {
        //HERE CALCULATE SIZE
        this.InventorySize = new Tuple<int, int> (10,10);
        return this.InventorySize;
    }

    public Tuple<int,int> GetItemPosition(string itemName)
    {
        return BaseInventoryData.GetValueOrDefault(itemName);
    }

    public string GetItemAtLocation(Tuple<int,int> itemLocation)
    {
        foreach(var item in BaseInventoryData)
        {
            if(item.Value == itemLocation)
            {
                return item.Key;
            }
        }
        return null;
    }

    public bool SetInventoryTexture(Texture2D texture)
    {
        //HERE CALCULATE SIZE
        this.InventoryTexture = texture;
        return true;
    }

    public bool LoadEmptyInventory()
    {
        BaseInventoryData = new Dictionary<string,Tuple<int,int>>();
        for(int x = 0; x < GetInventorySize().Item1; x++)
        {
            for(int y = 0; y < GetInventorySize().Item2; y++)
            {
                BaseInventoryData.Add(("Item X: " + x + " Y: " + y ),new Tuple<int,int>(x,y));
            }
        }
        return true;
    }
    public void Update()
    {
        
    }

    public void Draw()
    {
        Position = new Rectangle(400,400,this.InventoryTexture.Width,this.InventoryTexture.Height);
        Globals.SpriteBatch.Draw(this.InventoryTexture, Position, Color.White);
    }
}
