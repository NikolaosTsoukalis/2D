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

    private ButtonFunctionHandler Function;

    private ButtonTextureHandler Texture;

    public ButtonType Type;

    public event EventHandler Click;

    #endregion

    public Button(ButtonType Type) : base(null, new Vector2(0, 0))
    {
        this.Type = Type;
        AssignFunction();
        AssignTexture();
    }

    #region Methods

    public void AssignFunction()
    {
        this.Function = new ButtonFunctionHandler(this.Type);
    }

    public void AssignTexture()
    {
        this.Texture = new ButtonTextureHandler(this.Type);
    }

    public override void Draw(GameTime gameTime)
    {
        var colour = Color.White;


        if (_isHovering)
        {
            colour = Color.Gray;
        }
        if (isClicked)
        {
            Globals.SpriteBatch.Draw(Texture.GetPressedTexture(), Rectangle, colour);
        }
        else
        {
            Globals.SpriteBatch.Draw(Texture.GetUnPressedTexture(), Rectangle, colour);
        }
        if (this.Text != null)
        {
            Vector2 textSize = Globals.ContentManager.Load<SpriteFont>("MyFont").MeasureString(this.Text);

            // Center the text within the button rectangle
            Vector2 textPosition = new Vector2(
                Rectangle.X + (Rectangle.Width / 2) - (textSize.X / 2),
                Rectangle.Y + (Rectangle.Height / 2) - (textSize.Y / 2)
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

        var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

        _isHovering = false;

        if (mouseRectangle.Intersects(Rectangle))
        {
            _isHovering = true;

            if (_currentMouse.LeftButton == ButtonState.Pressed && _previousMouse.LeftButton == ButtonState.Pressed && !Disabled)
            {
                _isHovering = false;
                isClicked = true;
            }

            if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed && !Disabled)
            {
                Function.Call();
            }
        }
    }
    #endregion
}