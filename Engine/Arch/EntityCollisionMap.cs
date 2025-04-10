using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class EntityCollisionMap
{
    private List<Tuple<string, Rectangle>> map;
    public List<Tuple<string, Rectangle>> Map
    {
        get{return map;}
        set{map = value;}
    }
    public EntityCollisionMap()
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
    public void DebugDraw(Game game)
    {
        foreach(Tuple<string,Rectangle> rect in Map)
        {
            Texture2D mapTexture = new Texture2D(game.GraphicsDevice, 1,1);
            mapTexture.SetData(new[] { Color.Yellow });
            Globals.SpriteBatch.Draw(mapTexture,rect.Item2, Color.Yellow);   
        }
    }
}