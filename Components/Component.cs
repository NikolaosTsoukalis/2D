using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public abstract class Component
{
    public abstract void Draw(GameTime gameTime);

    public abstract void Update(GameTime gameTime);
}