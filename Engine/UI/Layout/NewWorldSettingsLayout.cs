using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;

namespace _2D_RPG;

public class NewWorldSettingsLayout : LayoutBase
{
    public NewWorldSettingsLayout(Menu menu, Texture2D BoundingTexture) : base(menu, BoundingTexture)
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
            var currentComponent = base.Menu.Components[i];
            if (currentComponent.Type == GlobalEnumarations.ComponentType.Debug)
            {
                base.SetDebugButtonPosition(currentComponent);
                base.SetTextBoxPosition(currentComponent);
                continue;    
            }
            if (currentComponent.Type == GlobalEnumarations.ComponentType.CreateWorldButton || currentComponent.Type == GlobalEnumarations.ComponentType.BackButton)
            {
                base.SetDebugButtonPosition(currentComponent);
                base.SetTextBoxPosition(currentComponent);
                continue;    
            }
            int yPadding = 80;
            currentComponent.Position = AlignComponentWithBoundCenter(currentComponent.TextureHandler.CurrentTexture, base.BaseBounds.Width, base.BaseBounds.Height);
            currentComponent.Position = new Vector2(currentComponent.Position.X, currentComponent.Position.Y + i * yPadding);
            base.SetComponentBounds(currentComponent);
            base.SetTextBoxPosition(currentComponent);
        }
    }
   
}