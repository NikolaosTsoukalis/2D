using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2D_RPG;

public class Button : Component
{
    #region Fields

    private MouseState _currentMouse;

    private SpriteFont _font;

    private bool _isHovering;

    private MouseState _previousMouse;

    private Texture2D _texture;

    #endregion

    #region Properties

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
            colour = Color.Gray;

        Globals.spriteBatch.Draw(_texture, Rectangle, colour);
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

            if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(this, new EventArgs());
            }
        }
    }

    #endregion
}