using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

public class Slider : ComponentBase
{
    public int CurrentValue { get; private set; }
    private Vector2 CurrentThumbPosition;

    public int Scale;

    public GlobalEnumarations.SliderComponentValues ValueType { get; private set; }

    public Slider(GlobalEnumarations.ComponentType functionType,GlobalEnumarations.TextureLibraryUI textureType, GlobalEnumarations.SliderComponentValues valueType) : base(functionType, textureType)
    {
        this.ValueType = valueType;
        this.CurrentValue = GetGlobalValue(valueType);
        this.CurrentThumbPosition = SetThumbPosition(CurrentValue);
        if (CurrentThumbPosition == Vector2.Zero)
        {
            Console.WriteLine("ERROR on : '" + functionType.ToString() + "', Position could not be set!");
        }
    }

    private Vector2 SetThumbPosition(int variableValue)
    {
        Vector2 thumpPosition;
        switch (base.FunctionType)
        {
            case GlobalEnumarations.ComponentType.SliderHorizontal:
                thumpPosition.X = base.Position.X + variableValue * Scale;
                thumpPosition.Y = base.Position.Y;
                break;
            case GlobalEnumarations.ComponentType.SliderVertical:
                thumpPosition.Y = this.Position.Y - variableValue * Scale;
                thumpPosition.X = this.Position.X;
                break;
            default:
                thumpPosition = Vector2.Zero;
                break;
        }

        return thumpPosition;
    }

    public override void Update(GameTime gameTime)
    {
        HandleStateChange();
    }

    public override void Draw(GameTime gameTime)
    {
        var colour = Color.White;

        Globals.SpriteBatch.Draw(base.TextureHandler.CurrentTexture, base.Bounds, colour);
        //Globals.SpriteBatch.Draw(base.TextureHandler) // DRAW THUMB
    }

    public override void DebugDraw(GameTime gameTime)
    {
        var colour = Color.White;

        Globals.SpriteBatch.Draw(base.TextureHandler.CurrentTexture, base.Bounds, colour);
        //Globals.SpriteBatch.Draw(base.TextureHandler) // DRAW THUMB
    }

    public override void HandleStateChange()
    {
        if (base.State == GlobalEnumarations.ComponentState.Free)
        {
            if (Globals.CurrentMouse.LeftButton == ButtonState.Pressed && Globals.PreviousMouse.LeftButton == ButtonState.Pressed)
            {
                HandleValueChange();
            }
        }
    }

    private int GetGlobalValue(GlobalEnumarations.SliderComponentValues valueType)
    {
        switch (valueType)
        {
            case GlobalEnumarations.SliderComponentValues.Volume:
                return this.CurrentValue = Globals.Volume;
            case GlobalEnumarations.SliderComponentValues.Sensitivity:
                return this.CurrentValue = Globals.Sensitivity;
            default:
                return 0;
        }
    }

    public bool HandleValueChange()
    {
        try
        {
            int whole;
            if (Globals.CurrentMouse.Position.X > Globals.PreviousMouse.Position.X)
            {
                if (Globals.CurrentMouse.LeftButton == ButtonState.Released && Globals.PreviousMouse.LeftButton == ButtonState.Released)
                {
                    switch (base.FunctionType)
                    {
                        case GlobalEnumarations.ComponentType.SliderHorizontal:
                            whole = (int)this.Position.X + this.TextureHandler.CurrentTexture.Width;
                            CurrentValue = Globals.CurrentMouse.Position.X * 100 / whole;
                            SetThumbPosition(CurrentValue);
                            base.FunctionHandler.CallFunction();
                            return true;
                        case GlobalEnumarations.ComponentType.SliderVertical:
                            whole = (int)this.Position.Y + this.TextureHandler.CurrentTexture.Height;
                            CurrentValue = Globals.CurrentMouse.Position.Y * 100 / whole;
                            SetThumbPosition(CurrentValue);
                            base.FunctionHandler.CallFunction();
                            return true;
                    }
                }

            }
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

}