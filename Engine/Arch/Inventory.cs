using System;
using System.Collections.Generic;

namespace _2D_RPG;

public class Inventory
{
    private Tuple<int,int> Size;
    private Tuple<int,int> InventoryPosition;
    private Dictionary<string,Tuple<int,int>> InventoryData;
    public Inventory()
    {
        InventoryData = new(); // here we create the inventory base on saved data or as a new Dictionary of items and positions.
    }

    public Dictionary<string,Tuple<int,int>> LoadInventoryData()
    {
        bool inventorySavedData = false;
        if(inventorySavedData == false)
        {
            return new Dictionary<string,Tuple<int,int>>();
        }
        return null;
    }

    public Tuple<int,int> GetInventorySize()
    {
        //HERE CALCULATE SIZE
        return this.Size;
    }
    public void Update(){}

    public void Draw(){}
}
