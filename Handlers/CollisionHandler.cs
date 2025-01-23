using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class CollisionHandler
{
    private static EntityCollisionMap entityCollisionMap;
    public CollisionHandler()
    {
        entityCollisionMap = new();
    }

    public static void handleEntityCollisionMap()
    {
        foreach(Entity currentEntity in EntityHandler.EntityList)
        Texture2D currentEntityTexture = currentEntity.Texture;
        Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,currentEntity.Texture.Width,currentEntity.Texture.Height );


    }

    public static bool IsCollidingWithEntity(Entity currentEntity)
    {
        Texture2D currentEntityTexture = currentEntity.Texture;
        Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,currentEntity.Texture.Width,currentEntity.Texture.Height );

        foreach(Rectangle rect in entityCollisionMap.Map)
        {
            if(currentEntityRectangle.Intersects(rect))
            {
                return true;
            }
            return false;
        }

        // Map is empty
        return false;
    }



}