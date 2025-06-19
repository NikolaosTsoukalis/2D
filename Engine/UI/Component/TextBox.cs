using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class TextBox : ComponentBase
{

    public SpriteFont Font { get; private set; }

    public string Text { get; private set; }

    private bool hasClicked { get; set;}

    public TextBox(SpriteFont font, string text, bool isWritable) : base(GlobalEnumarations.ComponentType.TextBox)
    {
        this.Font = font;
        this.Text = text;
        base.IsWritable = isWritable;
    }

    public override void Draw(GameTime gameTime)
    {
        if (this.Text != null)
        {
            float scale = 0.75f;
            Rectangle innerBounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, 108, 40);
            Vector2 textSize = Globals.ContentManager.Load<SpriteFont>("MyFont").MeasureString(this.Text) * scale;
            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                innerBounds.X + (innerBounds.Width - textSize.X) / 2f,
                innerBounds.Y + (innerBounds.Height - textSize.Y) / 2f
            );

            // Draw the text
            Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), this.Text, textPosition, Color.Black, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }

    public override void Update(GameTime gameTime) { }
    
    public override void HandleStateChange()
    {
        var mouseRectangle = new Rectangle(Globals.CurrentMouse.X, Globals.CurrentMouse.Y, 1, 1);

        if (mouseRectangle.Intersects(base.Bounds) && State != GlobalEnumarations.ComponentState.Disabled && IsWritable)
        {

            if (Globals.CurrentMouse.LeftButton == ButtonState.Pressed && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
            {
                State = GlobalEnumarations.ComponentState.Clicked;
                GlobalEnumarations.ComponentState.Clicked;
            }
            else if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Released)
            {
                State = GlobalEnumarations.ComponentState.Free;
            }
            else if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
            {
                State = GlobalEnumarations.ComponentState.Free;
                FunctionHandler.CallFunction();
            }
        }
        else
        {
            IsHovering = false;
        }
    }

}
