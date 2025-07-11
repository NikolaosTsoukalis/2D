using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;

namespace _2D_RPG;

public class VerticalMainMenuLayoutBase : LayoutBase
{
    public VerticalMainMenuLayoutBase(Menu menu, Texture2D BoundingTexture) : base(menu, BoundingTexture)
    {
        AssignComponentPositions(false);
    }

    public override void AssignComponentPositions(bool resetFlag)
    {
        if (resetFlag)
        {
            base.SetBaseBounds(base.BoundingTexture);
        }
        for (int i = 0; i < base.Menu.Components.Count; i++)
        {
            int yPadding = 10 + base.Menu.Components[i].TextureHandler.CurrentTexture.Height;
            base.Menu.Components[i].Position = AlignComponentWithBoundCenter(base.Menu.Components[i].TextureHandler.CurrentTexture, base.BaseBounds.Width, base.BaseBounds.Height);
            base.Menu.Components[i].Position = new Vector2(base.Menu.Components[i].Position.X, base.Menu.Components[i].Position.Y + i * yPadding);
            base.SetComponentBounds(base.Menu.Components[i]);

            Type type = base.Menu.Components[i].GetType();
            FieldInfo field = type.GetField("TextBox", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (type.GetField("TextBox") != null)
            {
                (type)base.Menu.Components[i];
            }
        }
    }
   
}