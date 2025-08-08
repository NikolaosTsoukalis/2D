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
    public MainMenuLayout(Menu menu) : base(menu, null)
    {
        base.LayoutTexture = null; //layout of menu
        base.LayoutPosition = AlignComponentWithBoundCenter(LayoutTexture, base.BaseBounds.X, base.BaseBounds.Y);
        SetComponentPaddingMap();
        AssignComponentPositions(false);
    }

    public override void SetComponentPaddingMap()
    {
        ComponentPaddingMap = new Dictionary<int, Int2>()
        {
            {1,new Int2(40,10)},
            {2,new Int2(44,108)},
            {3,new Int2(44,188)},
            {4,new Int2(44,268)},
        };
    }

    public override void AssignComponentPositions(bool resetFlag)
    {
        if (resetFlag)
        {
            base.SetBaseBoundsToScreen();
            base.LayoutPosition = AlignComponentWithBoundCenter(LayoutTexture, base.BaseBounds.X, base.BaseBounds.Y);
        }
        for (int i = 0; i < base.Menu.Components.Count; i++)
        {
            var currentComponent = base.Menu.Components[i];
            if (currentComponent.FunctionType == GlobalEnumarations.ComponentType.DebugButton)
            {
                base.SetDebugButtonPosition(currentComponent);
                base.SetTextBoxPosition(currentComponent);
                i--;
                continue;
            }

            int xPadding = ComponentPaddingMap.GetValueOrDefault(i).X;
            int yPadding = ComponentPaddingMap.GetValueOrDefault(i).Y;
            int xPosition = (int)base.LayoutPosition.X + xPadding;
            int yPosition = (int)base.LayoutPosition.Y + yPadding;
            //currentComponent.Position = new Vector2(xPosition, yPosition);
            base.SetComponentBounds(currentComponent);
            base.SetTextBoxPosition(currentComponent);
        }
    }
   
}