using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace _2D_RPG;

public class MainMenuLayout : LayoutBase
{
    private Dictionary<int, Int2> ComponentPaddingMap;
    public MainMenuLayout(Menu menu, Texture2D texture) : base(menu, texture)
    {
        SetComponentPaddingMap();
        AssignComponentPositions();
    }

    public override void Update(GameTime gameTime)
    {
        if (!base.ScreenDimensions.Equals(Globals.ScreenResolution))
        {
            base.UpdateScreenDimensions();
            base.SetBaseBoundsToScreen();
            base.Position = base.AlignComponentWithBoundCenter(base.Texture, base.BaseBounds.X, base.BaseBounds.Y);
            AssignComponentPositions();
        }
    }

    public override void Draw(GameTime gameTime)
    {
        Globals.SpriteBatch.Draw(base.Texture, base.Position, Color.White);
    }

    public override void DebugDraw(GameTime gameTime)
    {
        Globals.SpriteBatch.Draw(base.Texture, base.Position, Color.White);

        Texture2D Pixel = new Texture2D(Globals.GraphicsDeviceManager.GraphicsDevice, 1, 1);
        Pixel.SetData(new[] { Color.White });
        Globals.SpriteBatch.Draw(base.Texture, base.Position, Color.White);
        Globals.SpriteBatch.Draw(Pixel, new Rectangle((int)base.Position.X,(int)base.Position.Y,base.Texture.Width,base.Texture.Height), Color.SkyBlue * 0.3f);
    }

    public override void SetComponentPaddingMap()
    {
        ComponentPaddingMap = new Dictionary<int, Int2>()
        {
            {0,new Int2(39,9)},
            {1,new Int2(43,107)},
            {2,new Int2(43,187)},
            {3,new Int2(43,267)},
        };
    }

    public override void AssignComponentPositions()
    {
        for (int i = 0; i < base.Menu.Components.Count; i++)
        {
            var currentComponent = base.Menu.Components[i];
            if (currentComponent.FunctionType == GlobalEnumarations.ComponentType.DebugButton)
            {
                base.SetDebugButtonPosition(currentComponent);
                base.ManageTextBoxPosition(currentComponent);
                //i--;
                continue;
            }

            int xPadding = ComponentPaddingMap.GetValueOrDefault(i).X;
            int yPadding = ComponentPaddingMap.GetValueOrDefault(i).Y;
            int xPosition = (int)base.Position.X + xPadding;
            int yPosition = (int)base.Position.Y + yPadding;
            currentComponent.Position = new Vector2(xPosition, yPosition);
            base.SetComponentBounds(currentComponent);
            base.ManageTextBoxPosition(currentComponent);
        }
    }
   
}