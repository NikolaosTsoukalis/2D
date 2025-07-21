using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class Button : ComponentBase
{
    #region Fields
    public TextBox TextBox { get; private set; }

    #endregion

    public Button(GlobalEnumarations.ComponentType type, string name) : base(type)
    {
        if (name != null)
        {
            this.TextBox = new TextBox(Globals.Font, name, 0.75f, false, this);
        }
    }

    #region Methods

    public override void Draw(GameTime gameTime)
    {
        var colour = Color.White;
        Texture2D CurrentTexture = base.TextureHandler.CurrentTexture;

        if (IsHovering)
        {
            //colour = Color.Gray;
        }
        Globals.SpriteBatch.Draw(CurrentTexture, base.Bounds, colour);
        if (this.TextBox.Text != null)
        {
            TextBox.Draw(gameTime);
        }
    }

    public override void DebugDraw(GameTime gameTime)
    {
        Texture2D Pixel = new Texture2D(Globals.GraphicsDeviceManager.GraphicsDevice, 1, 1);
        Pixel.SetData(new[] { Color.White });
        Globals.SpriteBatch.Draw(base.TextureHandler.CurrentTexture, base.Bounds, Color.White);
        Globals.SpriteBatch.Draw(Pixel, base.Bounds, Color.Yellow * 0.3f);
        TextBox.DebugDraw(gameTime);
    }

    public override void Update(GameTime gameTime)
    {
        base.CurrentTime = gameTime;
        if (TextBox != null)
        {
            TextBox.Update(gameTime);
        }

        HandleStateChange();
        base.TextureHandler.SetCurrentTexture(base.State);
    }

    public override void HandleStateChange()
    {
        var mouseRectangle = new Rectangle(Globals.CurrentMouse.X, Globals.CurrentMouse.Y, 1, 1);

        if (mouseRectangle.Intersects(base.Bounds) && State != GlobalEnumarations.ComponentState.Disabled)
        {
            IsHovering = true;

            if (Globals.CurrentMouse.LeftButton == ButtonState.Pressed && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
            {
                base.State = GlobalEnumarations.ComponentState.Pressed;
            }
            else if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Released)
            {
                base.State = GlobalEnumarations.ComponentState.Free;
            }
            else if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
            {
                base.IsHovering = false;
                FunctionHandler.CallFunction();
                base.State = GlobalEnumarations.ComponentState.Free;
            }
        }
        else
        {
            base.IsHovering = false;
        }
    }

    
    #endregion


}