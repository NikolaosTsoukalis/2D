using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class VerticalMainMenuLayoutBase : LayoutBase
{
    public VerticalMainMenuLayoutBase(Menu menu, Texture2D BoundingTexture) : base(menu, BoundingTexture)
    {
        AssignComponentPositions(false);
    }

    public override void AssignComponentPositions(bool resetFlag)
    {
        int yPadding = 10;
        Vector2 currentButtonPosition = new Vector2(0,0);

        if (resetFlag)
        {
            base.SetBounds(base.BoundingTexture);    
        }
        for (int i = 0; i < base.Menu.Components.Count; i++)
        {
            if (i == 0)
            {
                base.Menu.Components[i].Position = AlignComponentWithBoundCenter(base.Menu.Components[i].TextureHandler.CurrentTexture, base.BaseBounds.Width, base.BaseBounds.Height);
                currentButtonPosition = base.Menu.Components[i].Position;
            }
            else
            {
                base.Menu.Components[i].Position = currentButtonPosition;
            }

            base.SetComponentBounds(base.Menu.Components[i]);
            currentButtonPosition.Y += base.Menu.Components[i].TextureHandler.CurrentTexture.Height + yPadding;
        }
    }    
}