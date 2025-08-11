using System;
using System.Diagnostics.Tracing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public abstract class ComponentBase
{
    public ComponentFunctionHandler FunctionHandler { get; private set; }
    public ComponentTextureHandler TextureHandler { get; private set; }
    public bool IsHovering { get; protected set; }
    public bool IsWritable { get; protected set; }

    public Vector2 Position { get; set; }
    public Rectangle Bounds { get; set; }

    protected bool HasClicked { get; set; }

    public GlobalEnumarations.ComponentState State { get; set; }

    public GlobalEnumarations.ComponentType FunctionType { get; private set; }
    public GlobalEnumarations.TextureLibraryUI TextureType { get; private set; }

    public GameTime CurrentTime { get; protected set; }

    public float TimeSinceClick { get; protected set; }
    
    public Enum SpecialAttribute { get; protected set; }

    public ComponentBase(GlobalEnumarations.ComponentType functionType, GlobalEnumarations.TextureLibraryUI textureType, Enum specialAttribute)
    {
        this.State = GlobalEnumarations.ComponentState.Free;
        this.FunctionType = functionType;
        this.TextureType = textureType;
        this.SpecialAttribute = specialAttribute;
        this.InitiallizeHandlers();
    }

    public ComponentBase(GlobalEnumarations.ComponentType functionType, GlobalEnumarations.TextureLibraryUI textureType)
    {
        this.State = GlobalEnumarations.ComponentState.Free;
        this.FunctionType = functionType;
        this.TextureType = textureType;
        this.InitiallizeHandlers();
    }

    public ComponentBase(GlobalEnumarations.ComponentType functionType)
    {
        this.State = GlobalEnumarations.ComponentState.Free;
        this.FunctionType = functionType;
        this.InitiallizeHandlers();
    }

    public abstract void Draw(GameTime gameTime);

    public abstract void Update(GameTime gameTime);

    public abstract void HandleStateChange();

    public abstract void DebugDraw(GameTime gameTime);

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

    public bool HandleDoubleClick() // MOVE TO  GLOBAL?
    {
        if (HasClicked && TimeSinceClick < 1)
        {
            HasClicked = false;
            return true;
        }
        if (HasClicked && TimeSinceClick > 1.5)
        {
            HasClicked = false;
            TimeSinceClick = 0;
            return false;
        }
        HasClicked = true;
        TimeSinceClick += (float)CurrentTime.ElapsedGameTime.TotalSeconds;
        return false;
    }

    private void InitiallizeHandlers()
    {
        if (FunctionHandler == null)
        {
            this.FunctionHandler = new ComponentFunctionHandler(this.FunctionType, this);
        }
        if (TextureHandler == null && this.TextureType != GlobalEnumarations.TextureLibraryUI.None)
        {
            this.TextureHandler = new ComponentTextureHandler(this.TextureType, this);
        }
    }

    public void SanitizeHandlers()
    {
        try
        {
            if (this.FunctionHandler == null || this.FunctionHandler.FunctionCall == null)
            {
                this.FunctionHandler = new ComponentFunctionHandler(this.FunctionType, this);

                if (FunctionHandler == null)
                {
                    throw new Exception("Function Handler for Type: '" + this.FunctionType.ToString() + "' did not Sanitize correctly.");
                }
            }
            if ((this.TextureHandler == null || this.TextureHandler.CurrentTexture == null) && this.TextureType != GlobalEnumarations.TextureLibraryUI.None)
            {
                this.TextureHandler = new ComponentTextureHandler(this.TextureType, this);

                if (TextureHandler == null)
                {
                    throw new Exception("Texture Handler for Type: '" + TextureType.ToString() + "' did not Sanitize correctly.");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("WARNING: " + e);
        }

    }
}