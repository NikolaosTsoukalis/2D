using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

public class EntityCollisionMap
{
    private List<Rectangle> map;
    public List<Rectangle> Map
    {
        get{return map;}
        set{map = value;}
    }
    public EntityCollisionMap()
    {
        Map = new();
    }

    public void AddToCollisionMap(Rectangle rectangle)
    {
        if(!Map.Contains(rectangle))
        {
            Map.Add(rectangle);
        }
    }

    public void RemoveFromCollisionMap(Rectangle rectangle)
    {
        if(Map.Contains(rectangle))
        {
            Map.Remove(rectangle);
        }
    }
    
    public void ResetCollisionMap()
    {
        Map = new();
    }

}