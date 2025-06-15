using System;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

public abstract class ComponentBase
{

    public ComponentFunctionHandler FunctionHandler { get; private set; }
    public ComponentTextureHandler TextureHandler { get; private set; }
    public Vector2 Position { get; set; }

    public Rectangle Bounds { get; set; }

    public GlobalEnumarations.ComponentState State { get; set; }

    public GlobalEnumarations.ComponentType Type { get; set; }

    public ComponentBase(GlobalEnumarations.ComponentType type)
    {
        this.State = GlobalEnumarations.ComponentState.Free;        
        this.Type = type;
        InitiallizeHandlers(this.Type);
    }

    public abstract void Draw(GameTime gameTime);

    public abstract void Update(GameTime gameTime);

    public bool Disable()
    {
        try
        {
            this.State = GlobalEnumarations.ComponentState.Disabled;
            return true;
        }
        catch (Exception e)
        {
            this.State = GlobalEnumarations.ComponentState.Free;
            return false;
        }
    }

    public bool Enable()
    {
        try
        {
            this.State = GlobalEnumarations.ComponentState.Free;
            return true;
        }
        catch (Exception e)
        {
            this.State = GlobalEnumarations.ComponentState.Disabled;
            return false;
        }
    }

    private void InitiallizeHandlers(GlobalEnumarations.ComponentType type)
    {
        if (FunctionHandler == null)
        {
            this.FunctionHandler = new ComponentFunctionHandler(type);
        }
        if (TextureHandler == null)
        {
            this.TextureHandler = new ComponentTextureHandler(type);
        }
    }
}