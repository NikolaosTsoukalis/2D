using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class TextBox : ComponentBase
{

    public SpriteFont Font { get; private set; }

    public string Text { get; private set; }

    public Texture2D FlashingLineTexture { get; private set; }

    public Vector2 FlashingLinePosition { get; private set; }

    public TextBox(SpriteFont font, string text, bool isWritable) : base(GlobalEnumarations.ComponentType.TextBox)
    {
        this.Font = font;
        this.Text = text;
        base.IsWritable = isWritable;
        if (IsWritable)
        {
            LoadFlashingTextLine();
        }
    }

    public override void Draw(GameTime gameTime)
    {
        if (this.Text != null)
        {
            float scale = 0.75f;
            Rectangle innerBounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, 108, 40);
            Vector2 textSize = Globals.Font.MeasureString(this.Text) * scale;
            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                innerBounds.X + (innerBounds.Width - textSize.X) / 2f,
                innerBounds.Y + (innerBounds.Height - textSize.Y) / 2f
            );

            // Draw the text
            Globals.SpriteBatch.DrawString(Globals.Font, this.Text, textPosition, Color.Black, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            if (base.State != GlobalEnumarations.ComponentState.Disabled && base.IsWritable && HandleFlashingLine())
            {

                FlashingLinePosition = textPosition + new Vector2(textSize.X + 1, 0);

                Globals.SpriteBatch.Draw(FlashingLineTexture, new Rectangle((int)FlashingLinePosition.X, (int)FlashingLinePosition.Y, 2, Globals.Font.LineSpacing), Color.White);
            }

        }
    }

    public override void Update(GameTime gameTime)
    {
        base.CurrentTime = gameTime;
        HandleStateChange();
    }

    public override void HandleStateChange()
    {
        var mouseRectangle = new Rectangle(Globals.CurrentMouse.X, Globals.CurrentMouse.Y, 1, 1);

        if (IsWritable)
        {
            if (mouseRectangle.Intersects(base.Bounds))
            {
                if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
                {
                    if (this.State == GlobalEnumarations.ComponentState.Disabled)
                    {
                        if (base.HandleDoubleClick())
                        {
                            FunctionHandler.CallFunction();
                        }
                    }
                    else
                    {
                        FlashingLinePosition = new Vector2(Globals.CurrentMouse.Position.X + 1, 0);
                    }
                }
            }

        }
        if (!mouseRectangle.Intersects(base.Bounds) && base.State == GlobalEnumarations.ComponentState.Free && Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
        {
            FunctionHandler.CallFunction();
        }
    }

    public void LoadFlashingTextLine()
    {
        FlashingLineTexture = new Texture2D(Globals.GraphicsDeviceManager.GraphicsDevice, 1, 1);
        FlashingLineTexture.SetData(new[] { Color.White });
    }

    public bool HandleFlashingLine()
    {
        //This will make the white line flash every other second.
        if (CurrentTime.TotalGameTime.Seconds % 2 == 0)
        {
            return true;
        }
        return false;
    }

    public void HandleTextPosition()
    {
        float scale = 0.75f;
        Rectangle base.TextureHandler.GetTextBoxRectangle();
        Rectangle innerBounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, 108, 40);
        Vector2 textSize = Globals.Font.MeasureString(this.Text) * scale;
        // Center the text within the button rectangle
        Vector2 textPosition = new Vector2(
            innerBounds.X + (innerBounds.Width - textSize.X) / 2f,
            innerBounds.Y + (innerBounds.Height - textSize.Y) / 2f
        );
    }
}
