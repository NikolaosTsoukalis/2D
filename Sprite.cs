using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class Sprite
{
    public Texture2D texture;
    public Vector2 position;
    
    public Sprite(){}
    public Sprite(Vector2 vector){}
    public Sprite(Texture2D texture)
    {
        this.texture = texture;
    }
    public Sprite(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        this.position = position;
    }

    public virtual void Update(string parameter)
    {

    }
}
