﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq.Expressions;

namespace _2D_RPG;

public class Button : Component
{
    #region Fields
    public string Text;

    private MouseState _currentMouse;

    private SpriteFont _font;

    private bool _isHovering;

    private MouseState _previousMouse;

    private Texture2D _texture;

    public Texture2D Texture
    {
        get { return _texture; }
        set { _texture = value; }
    }

    public event EventHandler Click;

    public bool Clicked { get; private set; }

    public Vector2 Position { get; set; }

    public Rectangle Rectangle
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
        }
    }

    private bool Disabled;
    private bool Enabled;
    #endregion

    #region Methods

    public Button(Texture2D texture)
    {
        _texture = texture;
    }

    public override void Draw(GameTime gameTime)
    {
        var colour = Color.White;


        if (_isHovering)
        {
            colour = Color.Gray;
        }

        Globals.SpriteBatch.Draw(_texture, Rectangle, colour);
        if (this.Text != null)
        {
            Vector2 textSize = Globals.ContentManager.Load<SpriteFont>("MyFont").MeasureString(this.Text);

            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                Rectangle.X + (Rectangle.Width / 2) - (textSize.X / 2),
                Rectangle.Y + (Rectangle.Height / 2) - (textSize.Y / 2)
            );

            // Draw the text
            Globals.SpriteBatch.Draw(_texture, Rectangle, colour);
            Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), this.Text, textPosition, Color.Black);
            
        }
    }

    public override void DrawWithText(GameTime gameTime, string text)
    {
        var colour = Color.Blue;
        if (Disabled)
        {
            colour = Color.White;
        }
        else
        {
            colour = Color.Red;
        }


        if (_isHovering && !Disabled)
            colour = Color.Gray;

        if (!string.IsNullOrEmpty(text) && Globals.ContentManager.Load<SpriteFont>("MyFont") != null)
        {
            // Measure the size of the text
            Vector2 textSize = Globals.ContentManager.Load<SpriteFont>("MyFont").MeasureString(text);

            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                Rectangle.X + (Rectangle.Width / 2) - (textSize.X / 2),
                Rectangle.Y + (Rectangle.Height / 2) - (textSize.Y / 2)
            );

            // Draw the text
            Globals.SpriteBatch.Draw(_texture, Rectangle, colour);
            Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), text, textPosition, Color.Black);
        }
        else
        {
            Globals.SpriteBatch.Draw(_texture, Rectangle, colour);
        }
    }

    public override void Update(GameTime gameTime)
    {

        _previousMouse = _currentMouse;
        _currentMouse = Mouse.GetState();

        var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

        _isHovering = false;

        if (mouseRectangle.Intersects(Rectangle))
        {
            _isHovering = true;

            if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed && !Disabled)
            {
                Click?.Invoke(this, new EventArgs());
            }
        }
    }

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
    #endregion
}