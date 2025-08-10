/* using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class CreateWorldSettingsLayout : LayoutBase
{
    public CreateWorldSettingsLayout(Menu menu, Texture2D BoundingTexture) : base(menu, BoundingTexture)
    {
        AssignComponentPositions(false);
    }

    public override void AssignComponentPositions(bool resetFlag)
    {
        int rowComponentCount = 0;
        
        if (resetFlag)
        {
            base.SetBaseBounds(base.BoundingTexture);
        }
        
        Vector2 firstBottomRowPosition = new Vector2(base.BoundCenter.X - (base.BoundCenter.X - base.BoundCenter.X / 3f), base.BaseBounds.Height - base.BaseBounds.Height / 6);

        for (int i = 0; i < base.Menu.Components.Count; i++)
        {
            var currentComponent = base.Menu.Components[i];
            if (currentComponent.Type == GlobalEnumarations.ComponentType.DebugButton)
            {
                base.SetDebugButtonPosition(currentComponent);
                base.SetTextBoxPosition(currentComponent);
                continue;
            }
            if (currentComponent.Type == GlobalEnumarations.ComponentType.CreateAndLoadWorldButton || currentComponent.Type == GlobalEnumarations.ComponentType.SaveWorldAndQuitButton || currentComponent.Type == GlobalEnumarations.ComponentType.BackButton)
            {
                int xPadding = 60 + currentComponent.TextureHandler.CurrentTexture.Width;
                currentComponent.Position = firstBottomRowPosition;
                currentComponent.Position = new Vector2(currentComponent.Position.X + rowComponentCount * xPadding, currentComponent.Position.Y);
                base.SetComponentBounds(currentComponent);
                base.SetTextBoxPosition(currentComponent);
                rowComponentCount++;
                continue;
            }
            /* int yPadding = 80;
            currentComponent.Position = AlignComponentWithBoundCenter(currentComponent.TextureHandler.CurrentTexture, base.BaseBounds.Width, base.BaseBounds.Height);
            currentComponent.Position = new Vector2(currentComponent.Position.X, currentComponent.Position.Y + i * yPadding);
            base.SetComponentBounds(currentComponent);
            base.SetTextBoxPosition(currentComponent); 
        }
    }
   
} */