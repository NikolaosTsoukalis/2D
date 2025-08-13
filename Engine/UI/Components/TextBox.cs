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

    public Vector2 TextPosition { get; private set; }
    public bool IsWritable { get; private set; }
    public bool IsTextCentered { get; private set; }

    public Texture2D FlashingLineTexture { get; private set; }

    public Vector2 FlashingLinePosition { get; private set; }

    public ComponentBase ParentComponent { get; private set; }
    public TextBox(SpriteFont font, string text, float textScale, bool isWritable, bool isTextCentered, ComponentBase parentComponent) : base(GlobalEnumarations.ComponentType.TextBox)
    {
        this.Font = font;
        this.Text = text;
        this.TextScale = textScale;
        this.TextSize = font.MeasureString(text);
        //UpdateTextSize(0);
        this.IsWritable = isWritable;
        this.IsTextCentered = isTextCentered;
        this.ParentComponent = parentComponent;
        if (IsWritable)
        {
            LoadFlashingTextLine();
        }
    }

    public TextBox(GlobalEnumarations.TextureLibraryUI texture, SpriteFont font, string text, float textScale, bool isWritable, bool isTextCentered) : base(GlobalEnumarations.ComponentType.TextBox, texture, null)
    {
        this.Font = font;
        this.Text = text;
        this.TextScale = textScale;
        this.TextSize = font.MeasureString(text);
        //UpdateTextSize(0);
        this.IsTextCentered = isTextCentered;
        this.IsWritable = isWritable;
        
        if (IsWritable)
        {
            LoadFlashingTextLine();
        }
        //SetPosition(Vector2.One);
    }

    public override void Update(GameTime gameTime)
    {
        base.CurrentTime = gameTime;
        //UpdateTextSize(0);
        HandleStateChange();
    }

    public override void Draw(GameTime gameTime)
    {
        if (base.TextureType != GlobalEnumarations.TextureLibraryUI.None)
        {
            Globals.SpriteBatch.Draw(base.TextureHandler.CurrentTexture, base.Position, Color.White);
        }
        if(this.Text != null)
        {
            Globals.SpriteBatch.DrawString(this.Font, this.Text, this.TextPosition, Color.Black, 0f, this.TextSize, this.TextScale, SpriteEffects.None, 0f);
            if (base.State != GlobalEnumarations.ComponentState.Disabled && this.IsWritable && HandleFlashingLine())
            {
                FlashingLinePosition = this.TextPosition + new Vector2(TextSize.X + 1, 0);

                Globals.SpriteBatch.Draw(FlashingLineTexture, new Rectangle((int)FlashingLinePosition.X, (int)FlashingLinePosition.Y, 2, Globals.Font.LineSpacing), Color.White);
            }
        }
    }

    public override void DebugDraw(GameTime gameTime)
    {
        Texture2D Pixel = new Texture2D(Globals.GraphicsDeviceManager.GraphicsDevice, 1, 1);
        Pixel.SetData(new[] { Color.White });

        Globals.SpriteBatch.Draw(Pixel, base.Bounds, Color.Red * 0.3f);
        Globals.SpriteBatch.Draw(Pixel, new Rectangle((int)this.TextPosition.X, (int)this.TextPosition.Y, 3, 3), Color.Green);
        Globals.SpriteBatch.DrawString(this.Font, this.Text, this.TextPosition, Color.Black, 0f, this.TextSize, this.TextScale, SpriteEffects.None, 0f);
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

    public void SetPositionAsChild()
    {
        try
        {
            Int4 padding = Globals.TextureLibrary.GetTextBoxPadding(this.ParentComponent.TextureType);

            base.Position = new Vector2(this.ParentComponent.Position.X + padding.X, this.ParentComponent.Position.Y + padding.Y);

            base.Bounds = new Rectangle
            (
                (int)base.Position.X,
                (int)base.Position.Y,
                ParentComponent.TextureHandler.TextureWidth - padding.X - padding.Z,
                ParentComponent.TextureHandler.TextureHeight - padding.Y - padding.W
            );

            if (this.IsTextCentered)
            {
                float xCenterPoint = base.Bounds.X + base.Bounds.Width / 2f;
                float yCenterPoint = base.Bounds.Y + base.Bounds.Height / 2f;

                this.TextPosition = new Vector2(xCenterPoint, yCenterPoint);
                this.TextSize = this.TextSize / 2f;
                UpdateTextSize(false);
            }
            else
            {
                this.TextSize = Vector2.Zero;
            }
            

            //UpdateTextSize(0);
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR Setting TextBox Position: " + e);
        }
    }

    public void SetTextPositionAsParent()
    {
        if (this.IsTextCentered)
        {
            float xCenterPoint = base.Position.X + this.TextureHandler.TextureWidth / 2f;
            float yCenterPoint = base.Position.Y + this.TextureHandler.TextureHeight / 2f;

            this.TextPosition = new Vector2(xCenterPoint, yCenterPoint);
            this.TextSize = this.TextSize / 2f;
            UpdateTextSize(true);
        }
    }

    public void UpdateTextSize(bool isParent)
    {
        if (isParent)
        {
            while (this.TextPosition.X - this.TextSize.X < base.TextureHandler.CurrentTexture.Width / 2)
            {
                this.TextScale -= 0.01f;
            }
        }
        else
        {
            while (this.TextPosition.X - this.TextSize.X < base.Bounds.X)
            {
                this.TextScale -= 0.01f;
                
            }    
        }
    }
}
