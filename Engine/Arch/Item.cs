using System;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;


public class Item
{
    private int id;
    public int ID
    {
        get{return id;}
        set{id =  Convert.ToInt32(value);}
    }

    private string type;
    public string Type
    {
        get{return type;}
        set{type = value.ToString();}
    }

    private Texture2D texture;
    public Texture2D Texture
    {
        get{return texture;}
        set{texture = value;}
    }

    public Item(int ID, string itemType)
    {
        this.ID = ID;
        this.Type = itemType;    
    }
    
    public Item(int ID, string itemType, Texture2D texture)
    {
        this.ID = ID;
        this.Type = itemType;
        this.Texture = texture;
    }

    
}
