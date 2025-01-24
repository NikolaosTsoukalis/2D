using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _2D_RPG;

public class CollisionHandler
{
    private static CollisionMap entityCollisionMap;
    private static CollisionMap tileCollisionMap;
    public CollisionHandler(Main main)
    {
        tileCollisionMap = new();
        entityCollisionMap = new();
    }

    public static void handleEntityCollisionMap()
    {
        foreach(Entity currentEntity in EntityHandler.EntityList)
        {
            Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,currentEntity.Texture.Width,currentEntity.Texture.Height );
            var x = entityCollisionMap.Map.Find(x => x.Item1 == currentEntity.Name.ToString()); // Tuple(Name,Rectangle)
            
            if(x != null) // Does the map have collision for the specific entity based on name? 
            {
                if(x.Item2 == currentEntityRectangle) // Does the map have collision for the specific entity based on rectangle?
                {
                    continue;
                }
                else
                {
                    entityCollisionMap.RemoveFromCollisionMap(currentEntity.Name.ToString(),entityCollisionMap.Map.Find(x => x.Item1 == currentEntity.Name.ToString()).Item2);
                }      
            }
            entityCollisionMap.AddToCollisionMap(currentEntity.Name.ToString(),currentEntityRectangle);
        }
    }

    public static void handleTileCollisionMap()
    {
        foreach(Entity currentEntity in EntityHandler.EntityList)
        {
            Texture2D currentEntityTexture = currentEntity.Texture;
            Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,currentEntity.Texture.Width,currentEntity.Texture.Height );
        }
        //tileCollisionMap.AddToCollisionMap(tile)
    }

    public static bool IsCollidingWithEntity(Entity currentEntity)
    {
        Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,currentEntity.Texture.Width,currentEntity.Texture.Height );

        foreach(Tuple<string,Rectangle> tempTuple in entityCollisionMap.Map)
        {
            if(currentEntityRectangle.Intersects(tempTuple.Item2))
            {
                return true;
            }
            return false;
        }

        // Map is empty
        return false;
    }

    public static bool IsCollidingWithStructure(Entity currentEntity)
    {
        //Texture2D currentEntityTexture = currentEntity.Texture;
        Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,currentEntity.Texture.Width,currentEntity.Texture.Height );

        foreach(Tuple<string,Rectangle> tempTuple in tileCollisionMap.Map)
        {
            if(currentEntityRectangle.Intersects(tempTuple.Item2))
            {
                return true;
            }
            return false;
        }

        // Map is empty
        return false;
    }

    public void Update()
    {
        try
        {
            handleTileCollisionMap();
            handleEntityCollisionMap();
        }
        catch(Exception e)
        {
            MessageBox.Show("Error",e.ToString(),new List<string> {"OK"});
        }
        //return true;
    }

    public void Draw(Main main) // for testing purposes
    {
        entityCollisionMap.Draw(main,"Entity");
        tileCollisionMap.Draw(main,"Entity");
    }
}