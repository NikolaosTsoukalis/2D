using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
internal class Sprite
{
    public Texture2D texture;
    public Vector2 position;
    

    public Sprite(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        this.position = position;
    }

    public virtual void Update(string parameter)
    {

    }
}
