using Microsoft.Xna.Framework;
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

    private bool _isHovering;

    private MouseState _previousMouse;

    public event EventHandler Click;

    public Rectangle Rectangle
    {
        get
        {
            return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }
    }

    #endregion

    #region Methods

    public Button(Texture2D texture, Vector2 position) : base(texture, position)
    {
        
    }

    public override void Draw(GameTime gameTime)
    {
        var colour = Color.White;


        if (_isHovering)
        {
            colour = Color.Gray;
        }

        Globals.SpriteBatch.Draw(Texture, Rectangle, colour);
        if (this.Text != null)
        {
            Vector2 textSize = Globals.ContentManager.Load<SpriteFont>("MyFont").MeasureString(this.Text);

            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                Rectangle.X + (Rectangle.Width / 2) - (textSize.X / 2),
                Rectangle.Y + (Rectangle.Height / 2) - (textSize.Y / 2)
            );

            // Draw the text
            Globals.SpriteBatch.Draw(Texture, Rectangle, colour);
            Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), this.Text, textPosition, Color.Black);
            
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

            if (_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Pressed && !Disabled)
            {
                _isHovering = false;
                Texture = Globals.ContentManager.Load<Texture2D>("Top_Button_Pressed");
            }

            if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed && !Disabled)
            {
                Click?.Invoke(this, new EventArgs());
            }
        }
    }
    #endregion
}