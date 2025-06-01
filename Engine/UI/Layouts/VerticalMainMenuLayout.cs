using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class VerticalMainMenuLayoutStrategy : ILayoutStrategy
{
    private Rectangle Bounds;

    private Texture2D BoundingTexture;

    public VerticalMainMenuLayoutStrategy(List<Component> components, Texture2D BoundingTexture)
    {
        this.BoundingTexture = BoundingTexture;
        AssignBoundingTextureVariables(BoundingTexture);
        AssignComponentPositions(components,this.Bounds);
    }

    public void AssignComponentPositions(List<Component> components, Rectangle Bounds)
    {
        if (Bounds.IsEmpty )
        {
            Vector2 firstButtonPosition = new Vector2(Bounds.X / 2 + (Bounds.X / 4), Bounds.Y / 2 - (Bounds.Y / 4));
            Vector2 nextButtonPosition = firstButtonPosition;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Position = nextButtonPosition;
                nextButtonPosition.Y +=
            }
        }    
    }

    public void AssignBoundingTextureVariables(Texture2D BoundingTexture)
    {
        if (BoundingTexture != null)
        {
            this.BoundingTexture = BoundingTexture;

            float screenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
            float screenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

            int textureWidth = BoundingTexture.Bounds.Y;
            int textureHeight = BoundingTexture.Bounds.X;

            Vector2 BoundsStartingPoint = new Vector2(screenWidth / 2 + (screenWidth / 4), screenHeight / 2 - (screenHeight / 4));
            //Set position of bounding texture and the bounds themselves.
            //this is for the middle of the screen.
            this.Bounds = new Rectangle((int)BoundsStartingPoint.X, (int)BoundsStartingPoint.Y, textureWidth, textureHeight);
        }
        else
        {
            this.Bounds = new();
            return;

        }
    }




}