using System;
using Microsoft.Xna.Framework;

namespace _2D_RPG;

public abstract class ComponentBase
{

    public ComponentFunctionHandler FunctionHandler { get; private set; }
    public ComponentTextureHandler TextureHandler { get; private set; }
    public Vector2 Position { get; set; }

    public Rectangle Bounds { get; set; }

    public ComponentState State { get; private set; }

    public ComponentType Type { get; protected set; }

    public ComponentBase(ComponentType type)
    {
        this.State = ComponentState.Free;        
        this.Type = type;
        InitiallizeHandlers(this.Type);
    }

    public abstract void Draw(GameTime gameTime);

    public abstract void Update(GameTime gameTime);

    public bool Disable()
    {
        try
        {
            this.State = ComponentState.Disabled;
            return true;
        }
        catch (Exception e)
        {
            this.State = ComponentState.Free;
            return false;
        }
    }

    public bool Enable()
    {
        try
        {
            this.State = ComponentState.Free;
            return true;
        }
        catch (Exception e)
        {
            this.State = ComponentState.Disabled;
            return false;
        }
    }

    private void InitiallizeHandlers(ComponentType type)
    {
        if (FunctionHandler != null)
        {
            this.FunctionHandler = new ComponentFunctionHandler(type);
        }
        if (FunctionHandler != null)
        {
            this.TextureHandler = new ComponentTextureHandler(type);
        }
    }
}