using System;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class CollisionHandler
{
    public CollisionHandler(){}

    public static bool IsColliding(Entity currentEntity)
    {
        Texture2D currentEntityTexture = currentEntity.Texture;
        Rectangle currentEntityRectangle = new Rectangle((int)currentEntity.Position.X,(int)currentEntity.Position.Y,currentEntity.Texture.Width,currentEntity.Texture.Height);
        Color[] currentEntityColourData = new Color[currentEntityTexture.Width * currentEntityTexture.Height];
        currentEntityTexture.GetData(currentEntityColourData);
        foreach(Entity temporaryEntity in EntityHandler.EntityList)
        {
            Texture2D temporaryEntityTexture = temporaryEntity.Texture;
            Rectangle temporaryEntityRectangle = new Rectangle((int)temporaryEntity.Position.X,(int)temporaryEntity.Position.Y,temporaryEntity.Texture.Width,temporaryEntity.Texture.Height);
            Color[] temporaryEntityColourData = new Color[temporaryEntityTexture.Width * temporaryEntityTexture.Height];
            temporaryEntityTexture.GetData(temporaryEntityColourData);

            int top = Math.Max(currentEntityRectangle.Top, temporaryEntityRectangle.Top);
            int bottom = Math.Min(currentEntityRectangle.Bottom, temporaryEntityRectangle.Bottom);
            int left = Math.Max(currentEntityRectangle.Left, temporaryEntityRectangle.Left);
            int right = Math.Min(currentEntityRectangle.Right, temporaryEntityRectangle.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    // Calculate the positions within each texture
                    int index1 = (x - currentEntityRectangle.Left) + (y - currentEntityRectangle.Top) * currentEntityTexture.Width;
                    int index2 = (x - temporaryEntityRectangle.Left) + (y - temporaryEntityRectangle.Top) * temporaryEntityTexture.Width;

                    // Check if both pixels are not transparent
                    if (currentEntityColourData[index1].A > 0 && temporaryEntityColourData[index2].A > 0)
                    {
                        // Collision detected
                        return true;
                    }
                }
            }
        }

        // No collision detected
        return false;
    }

}