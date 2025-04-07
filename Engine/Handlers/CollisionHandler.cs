using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace _2D_RPG;

public class CollisionHandler
{
    private static CollisionMap entityCollisionMap {get;set;}
    private static CollisionMap tileCollisionMap {get;set;}
    public CollisionHandler(Main main)
    {
        tileCollisionMap = new();
        entityCollisionMap = new();
    }

    public static void handleEntityCollisionMap()
    {
        Tuple<Texture2D,string[]> data;
        foreach(Entity currentEntity in Globals.EntityHandler.GetEntityList())
        {
            data = Globals.AnimationDataHandler.GetAnimationData(currentEntity.Name.ToString(),currentEntity.AnimationIdentifier);
            var entityTextureWidth = currentEntity.Texture.Width / Convert.ToInt32(data.Item2[0]);
            Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,entityTextureWidth,currentEntity.Texture.Height );
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

    public static void handleTileCollisionMap(Vector2 playerPosition)
    {
        //MIGHT NOT BE NEEDED
        //tileCollisionMap.AddToCollisionMap(tile)
    }

    public bool IsCollidingWithEntity(Entity currentEntity)
    {
        Tuple<Texture2D, string[]> data = Globals.AnimationDataHandler.GetAnimationData(currentEntity.Name.ToString(),currentEntity.AnimationIdentifier);
        var entityTextureWidth = currentEntity.Texture.Width / Convert.ToInt32(data.Item2[0]);
        Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,entityTextureWidth,currentEntity.Texture.Height );
        string entityName = currentEntity.Name;
        Tuple<string,Rectangle> currentEntityTuple = new Tuple<string,Rectangle> (entityName,currentEntityRectangle);
        foreach(Tuple<string,Rectangle> tempTuple in entityCollisionMap.Map)
        {
            if(currentEntityTuple.Item2.Intersects(tempTuple.Item2) && currentEntityTuple.Item1 != tempTuple.Item1)
            {
                return true;
            }
            return false;
        }

        // Map is empty
        return false;
    }

    public static bool IsHitboxCollidingWithEntity(string entityName,Rectangle hitbox)
    {
        foreach(Tuple<string,Rectangle> tempTuple in entityCollisionMap.Map)
        {
            if(hitbox.Intersects(tempTuple.Item2) && entityName != tempTuple.Item1)
            {
                return true;
            }
            return false;
        }
        // Map is empty
        return false;
    }

    public bool IsCollidingWithTile(Entity currentEntity)
    {
        try
        {
            bool? isTileCollidable = Globals.TileDataHandler.GetTileCollidability(Globals.TileMapHandler.GetTileMap().GetTileTypeAt((int)currentEntity.Position.X,(int)currentEntity.Position.Y));
            if(isTileCollidable == true)
            {
                return true;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
        
        // Map is empty
        return false;
    }

    public Entity getCollidingEntity(string entityName,Rectangle hitbox)  //Mainly use for interact/attack and not collision
    {
        foreach(Tuple<string,Rectangle> tempTuple in entityCollisionMap.Map)
        {
            Rectangle actualCollidingHitbox = tempTuple.Item2;
            
            int newX = actualCollidingHitbox.X + actualCollidingHitbox.Width/3;
            int newY = actualCollidingHitbox.Y + actualCollidingHitbox.Height/6;
            int newWidth = actualCollidingHitbox.Width - 2*actualCollidingHitbox.Width/3;
            int newHeight = actualCollidingHitbox.Height - 2*actualCollidingHitbox.Height/6;

            actualCollidingHitbox = new Rectangle(newX,newY, newWidth,newHeight);
            if(hitbox.Intersects(actualCollidingHitbox) && entityName != tempTuple.Item1)
            {
                foreach(Entity entity in Globals.EntityHandler.GetEntityList())
                {
                    if(tempTuple.Item1 == entity.Name)
                    {
                        return entity;
                    }
                }
            }
        }
        // Entity doesnt exist in the entity list.
        return null;
    }

    public void Update()
    {
        try
        {
            //handleTileCollisionMap();
            handleEntityCollisionMap();
        }
        catch(Exception e)
        {
            MessageBox.Show("Error",e.ToString(),new List<string> {"OK"});
        }
        //return true;
    }

    public void DebugDraw(Main main) // for testing purposes
    {
        entityCollisionMap.DebugDraw(main,"Entity");
        //tileCollisionMap.DebugDraw(main,"Entity");
    }
}