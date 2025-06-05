using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class VerticalMainMenuLayoutBase : LayoutBase
{
    private List<ComponentBase> Buttons;

    public VerticalMainMenuLayoutBase(List<ComponentBase> components, Texture2D BoundingTexture) : base(components, BoundingTexture)
    {
        AssignComponentPositions(components, Bounds);
    }

    public override void AssignComponentPositions(List<ComponentBase> components, Rectangle Bounds)
    {
        int yPadding = 50;

        float screenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        float screenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

        if (!Bounds.IsEmpty)
        {
            Vector2 firstButtonPosition = new Vector2(Bounds.X / 2 + (Bounds.X / 4), Bounds.Y / 2 - (Bounds.Y / 4));
            Vector2 nextButtonPosition = firstButtonPosition;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Position = nextButtonPosition;
                nextButtonPosition.Y += components[i].Texture.Height + yPadding;
            }
        }
        else
        {
            Vector2 firstButtonPosition = new Vector2(screenWidth / 2 + (screenWidth / 4), screenHeight / 2 - (screenHeight / 4));
            Vector2 nextButtonPosition = firstButtonPosition;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Position = nextButtonPosition;
                nextButtonPosition.Y += components[i].Texture.Height + yPadding;
            }
        }
    }
}