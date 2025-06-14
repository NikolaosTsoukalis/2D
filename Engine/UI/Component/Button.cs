using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2D_RPG;

public class Button : ComponentBase
{
    #region Fields
    public string Text;

    private MouseState _currentMouse;

    private bool _isHovering;

    private MouseState _previousMouse;

    #endregion

    public Button(ComponentType type) : base(type){}

    #region Methods

    public override void Draw(GameTime gameTime)
    {
        var colour = Color.White;
        Rectangle Bounds = base.TextureHandler.Bounds;
        Texture2D CurrentTexture = base.TextureHandler.CurrentTexture;

        if (_isHovering)
        {
            colour = Color.Gray;
        }
        Globals.SpriteBatch.Draw(CurrentTexture, Bounds, colour);
        if (this.Text != null)
        {
            Vector2 textSize = Globals.ContentManager.Load<SpriteFont>("MyFont").MeasureString(this.Text);
            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                Bounds.X + (Bounds.Width / 2) - (textSize.X / 2),
                Bounds.Y + (Bounds.Height / 2) - (textSize.Y / 2)
            );

            // Draw the text
            //Globals.SpriteBatch.Draw(Texture, Rectangle, colour);
            Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), this.Text, textPosition, Color.Black);

        }
    }

    public override void Update(GameTime gameTime)
    {

        _previousMouse = _currentMouse;
        _currentMouse = Mouse.GetState();
        Rectangle Bounds = base.TextureHandler.Bounds;

        var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

        _isHovering = false;

        if (mouseRectangle.Intersects(Bounds))
        {
            _isHovering = true;
            HandleStateChange();
        }
    }

    public void HandleStateChange()
    {
        if (State != ComponentState.Disabled)
        {
            if (_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Pressed)
            {
                State = ComponentState.Clicked;
            }
            else if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Released)
            {
                State = ComponentState.Free;
            }
            else if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
            {
                _isHovering = false;
                FunctionHandler.CallFunction();
            }
        }
    }
    #endregion
}