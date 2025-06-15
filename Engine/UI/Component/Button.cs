using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2D_RPG;

public class Button : ComponentBase
{
    #region Fields
    public string Text;
    private bool _isHovering;
    
    #endregion

    public Button(GlobalEnumarations.ComponentType type) : base(type) { }

    #region Methods

    public override void Draw(GameTime gameTime)
    {
        var colour = Color.White;
        Texture2D CurrentTexture = base.TextureHandler.CurrentTexture;

        if (_isHovering)
        {
            colour = Color.Gray;
        }
        Globals.SpriteBatch.Draw(CurrentTexture, base.Bounds, colour);
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
        var mouseRectangle = new Rectangle(Globals.CurrentMouse.X, Globals.CurrentMouse.Y, 1, 1);

        _isHovering = false;

        if (mouseRectangle.Intersects(base.Bounds))
        {
            _isHovering = true;
            HandleStateChange();
        }
    }

    public void HandleStateChange()
    {
        if (State != GlobalEnumarations.ComponentState.Disabled)
        {
            if (Globals.CurrentMouse.LeftButton == ButtonState.Pressed && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
            {
                State = GlobalEnumarations.ComponentState.Clicked;
            }
            else if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Released)
            {
                State = GlobalEnumarations.ComponentState.Free;
            }
            else if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
            {
                _isHovering = false;
                FunctionHandler.CallFunction();
            }
        }
    }
    #endregion
}