using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class TextBox : ComponentBase
{

    public SpriteFont Font { get; private set; }

    public string Text { get; private set; }

    public float TextScale { get; private set; }

    public Vector2 TextSize { get; private set; }

    public Texture2D FlashingLineTexture { get; private set; }

    public Vector2 FlashingLinePosition { get; private set; }

    public ComponentBase ParentComponent { get; private set; }
    public TextBox(SpriteFont font, string text, float textScale, bool isWritable, ComponentBase parentComponent) : base(GlobalEnumarations.ComponentType.TextBox)
    {
        this.Font = font;
        this.Text = text;
        this.TextScale = textScale;
        UpdateTextSize();
        base.IsWritable = isWritable;
        this.ParentComponent = parentComponent;
        if (IsWritable)
        {
            LoadFlashingTextLine();
        }
        //SetPosition(Vector2.One);
    }

    public override void Draw(GameTime gameTime)
    {
        if (this.Text != null)
        {
            Globals.SpriteBatch.DrawString(this.Font, this.Text, base.Position, Color.Black, 0f, Vector2.Zero, this.TextScale, SpriteEffects.None, 0f);
            if (base.State != GlobalEnumarations.ComponentState.Disabled && base.IsWritable && HandleFlashingLine())
            {

                FlashingLinePosition = base.Position + new Vector2(TextSize.X + 1, 0);

                Globals.SpriteBatch.Draw(FlashingLineTexture, new Rectangle((int)FlashingLinePosition.X, (int)FlashingLinePosition.Y, 2, Globals.Font.LineSpacing), Color.White);
            }

        }
    }

    public override void Update(GameTime gameTime)
    {
        base.CurrentTime = gameTime;
        UpdateTextSize();
        HandleStateChange();
    }

    public override void HandleStateChange() //REDO **************
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

    public bool SetPosition(Vector2 position)
    {
        UpdateTextSize();
        if (this.ParentComponent != null)
        {
            // Padding into the textbox area from the outer image
            Int4 padding = Globals.TextureLibrary.GetTextBoxPadding(this.ParentComponent.TextureHandler.CurrentTexture);

            // Full image size
            int imageWidth = this.ParentComponent.TextureHandler.CurrentTexture.Width;
            int imageHeight = this.ParentComponent.TextureHandler.CurrentTexture.Height;

            // Textbox area size = full size minus left/right and top/bottom padding
            int textboxWidth = imageWidth - padding.X - padding.W;
            int textboxHeight = imageHeight - padding.Y - padding.Z;

            // Define the inner bounds of the textbox
            base.Bounds = new Rectangle(
                (int)this.ParentComponent.Position.X + padding.X,
                (int)this.ParentComponent.Position.Y + padding.Z,
                textboxWidth,
                textboxHeight
            );

            // Center the text within the textbox area
            float xCenterPoint = base.Bounds.X + (textboxWidth - TextSize.X) / 2f;
            float yCenterPoint = base.Bounds.Y + (textboxHeight - TextSize.Y) / 2f;

            if (this.IsWritable)
            {
                base.Position = new Vector2(base.Bounds.X, base.Bounds.Y);
            }
            else
            {
                base.Position = new Vector2(xCenterPoint, yCenterPoint);
            }

            return true;
        }
        else if (position != Vector2.Zero)
        {
            base.Position = position;
            return true;
        }
        else
        {
            base.Position = Vector2.Zero;
            Console.WriteLine("TextBox Position was not set properly!");
            return false;
        }
    }

    public bool UpdateTextSize()
    {
        if (this.Font != null && !string.IsNullOrWhiteSpace(this.Text))
        {
            this.TextSize = Font.MeasureString(this.Text) * this.TextScale;
        }
        else
        {
            TextSize = Vector2.Zero;
            return false;
        }
        return true;
    }

    public override void DebugDraw(GameTime gameTime)
    {
        Texture2D Pixel = new Texture2D(Globals.GraphicsDeviceManager.GraphicsDevice, 1, 1);
        Pixel.SetData(new[] { Color.White });

        Globals.SpriteBatch.Draw(Pixel, base.Bounds, Color.Red * 0.3f);
        Globals.SpriteBatch.Draw(Pixel, new Rectangle((int)base.Position.X, (int)base.Position.Y, 3, 3), Color.Green);
        Globals.SpriteBatch.DrawString(this.Font, this.Text, base.Position, Color.Black, 0f, Vector2.Zero, this.TextScale, SpriteEffects.None, 0f);
    }
}
