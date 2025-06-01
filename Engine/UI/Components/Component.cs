using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public abstract class Component
{

    public Vector2 Position { get; set; }
    public Texture2D Texture { get; set; }

    public bool isClicked { get; set; }
    public bool Disabled { get; set; }
    public bool Enabled { get; set; }

    public Rectangle Rectangle
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }
    }

    public Component(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        Position = position;
    }

    public abstract void Draw(GameTime gameTime);

    public abstract void Update(GameTime gameTime);

    public bool Disable()
    {
        try
        {
            this.Disabled = true;
            return true;
        }
        catch (Exception e)
        {
            this.Disabled = false;
            return false;
        }
    }

    public bool Enable()
    {
        try
        {
            this.Enabled = true;
            this.Disabled = false;
            return true;
        }
        catch (Exception e)
        {
            this.Enabled = false;
            this.Disabled = true;
            return false;
        }
    }

    public bool isEnabled()
    {
        if (Enabled || !Disabled)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}