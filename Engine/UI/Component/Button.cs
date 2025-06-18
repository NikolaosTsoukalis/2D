using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace _2D_RPG;

public class Button : ComponentBase
{
    #region Fields
    public string Text;
    public Rectangle TextBounds;
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
            //colour = Color.Gray;
        }
        Globals.SpriteBatch.Draw(CurrentTexture, base.Bounds, colour);
        if (this.Text != null)
        {
            float scale = 0.75f;
            Rectangle innerBounds = new Rectangle((int)this.Position.X + 20, (int)this.Position.Y + 20, 108, 40);
            Vector2 textSize = Globals.ContentManager.Load<SpriteFont>("MyFont").MeasureString(this.Text) * scale;
            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                innerBounds.X + (innerBounds.Width - textSize.X) / 2f,
                innerBounds.Y + (innerBounds.Height - textSize.Y) / 2f
            );

            // Draw the text
            //Globals.SpriteBatch.Draw(Texture, Rectangle, colour);
            Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), this.Text, textPosition, Color.Black, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            //Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), this.Text, textPosition, Color.Black);

        }
    }

    public override void Update(GameTime gameTime)
    {
        HandleStateChange();
        base.TextureHandler.SetCurrentTexture(base.State);
    }

    public void HandleStateChange()
    {
        var mouseRectangle = new Rectangle(Globals.CurrentMouse.X, Globals.CurrentMouse.Y, 1, 1);

        if (mouseRectangle.Intersects(base.Bounds) && State != GlobalEnumarations.ComponentState.Disabled)
        {
            _isHovering = true;

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
                State = GlobalEnumarations.ComponentState.Free;
                FunctionHandler.CallFunction();
            }
        }
        else
        {
            _isHovering = false;
        }
    }
    #endregion
    
    
}