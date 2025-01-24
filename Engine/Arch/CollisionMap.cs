using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class CollisionMap
{
    private List<Tuple<string, Rectangle>> map;
    public List<Tuple<string, Rectangle>> Map
    {
        get{return map;}
        set{map = value;}
    }
    public CollisionMap()
    {
        Map = new();
    }

    public void AddToCollisionMap(string x, Rectangle rectangle)
    {
        Tuple<string, Rectangle> temp = new Tuple<string, Rectangle> (x,rectangle);
        if(!Map.Contains(temp))
        {
            Map.Add(temp);
        }
    }

    public void RemoveFromCollisionMap(string x, Rectangle rectangle)
    {
        Tuple<string, Rectangle> temp = new Tuple<string, Rectangle> (x,rectangle);
        if(Map.Contains(temp))
        {
            Map.Remove(temp);
        }
    }
    
    public void ResetCollisionMap()
    {
        Map = new();
    }
    public void Draw(Game game,string mapType)
    {
        Texture2D mapTexture = new Texture2D(game.GraphicsDevice, 1, 1);

        foreach(Tuple<string,Rectangle> rect in Map)
        {
            if(mapType == "Entity" )
            {
                Globals.spriteBatch.Draw(mapTexture,new Vector2(rect.Item2.X,rect.Item2.Y), Color.Yellow);
            }
            else if(mapType == "Structure" )
            {
                Globals.spriteBatch.Draw(mapTexture,new Vector2(rect.Item2.X,rect.Item2.Y), Color.Black);
            }
            
        }
    }
}