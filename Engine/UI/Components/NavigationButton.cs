using Microsoft.Xna.Framework;

namespace _2D_RPG;

public class NavigationButton : Button
{

    public GlobalEnumarations.MenuNavigationPaths Path { get; private set; }

    public NavigationButton(GlobalEnumarations.MenuNavigationPaths path,GlobalEnumarations.TextureLibraryUI textureType, string name) : base(GlobalEnumarations.ComponentType.NavigationButton,textureType, name)
    {
        this.Path = path;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
    }

    public override void DebugDraw(GameTime gameTime)
    {
        base.DebugDraw(gameTime);
    }

    public override void HandleStateChange()
    {
        base.HandleStateChange();
    }
    
}