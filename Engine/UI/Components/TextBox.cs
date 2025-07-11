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
        this.TextSize = Globals.Font.MeasureString(this.Text) * TextScale;
        base.IsWritable = isWritable;
        this.ParentComponent = parentComponent;
        if (IsWritable)
        {
            LoadFlashingTextLine();
        }
        SetPosition(Vector2.One);
    }

    public override void Draw(GameTime gameTime)
    {
        if (this.Text != null)
        {
            Globals.SpriteBatch.DrawString(Globals.Font, this.Text, base.Position, Color.Black, 0f, Vector2.Zero, TextScale, SpriteEffects.None, 0f);
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
        if(base.Position )
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

    public bool SetPosition(Vector2 position)
    {
        if (!this.ParentComponent.Equals(null))
        {
            Vector2 TextBoxPadding = Globals.TextureLibrary.GetTextBoxPosition(base.TextureHandler.CurrentTexture);
            base.Bounds = new Rectangle((int)this.ParentComponent.Position.X, (int)this.ParentComponent.Position.Y, (int)TextBoxPadding.X, (int)TextBoxPadding.Y);
            
            float xPoint = base.Bounds.X + (base.Bounds.Width - TextSize.X) / 2f;
            float yPoint = base.Bounds.Y + (base.Bounds.Height - TextSize.Y) / 2f;
            base.Position = new Vector2(xPoint, yPoint);

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
}
