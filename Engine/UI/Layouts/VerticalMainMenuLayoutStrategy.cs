using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Numerics;
using System.Runtime.ExceptionServices;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class VerticalMainMenuLayoutStrategy : ILayoutStrategy
{

    private float xSpace;
    private float ySpace;

    private Rectangle Bounds;

    private Texture2D BoundingTexture;

    public VerticalMainMenuLayoutStrategy(float xSpace, float ySpace)
    {
        this.xSpace = xSpace;
        this.ySpace = ySpace;
    }

    public void AssignComponentPositions(List<Component> components, Rectangle Bounds)
    {
        Vector2 firstButtonPosition = new Vector2(screenWidth / 2, screenHeight / 2);
    }

    public void AssignBoundingTextureVariables(Texture2D BoundingTexture)
    {

        this.BoundingTexture = BoundingTexture;

        int screenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        int screenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

        int textureWidth = BoundingTexture.Bounds.Y;
        int textureHeight = BoundingTexture.Bounds.X;
        
        Vector2 BoundsStartingPoint = new Vector2(screenWidth / 2 + (screenWidth / 4),screenHeight/2 );
        //Set position of bounding texture and the bounds themselves.
        //this is for the middle of the screen.
        this.Bounds = new Rectangle(,)
    }




}