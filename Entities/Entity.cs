using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
class Entity
{
    private Vector2 lposition;
    public Vector2 position 
    {
        get{ return lposition;}
        set{ lposition = position;}
    }
    private Texture2D ltexture;

    public Texture2D texture 
    {
        get{ return ltexture;}
        set{ ltexture = texture;}
    }
    public Entity(){}
    public Entity(Vector2 position)
    {
        this.position = position;   
    }
    public Entity(Texture2D texture)
    {
        this.texture = texture;
    }
    public Entity(Texture2D texture, Vector2 position)
    {
        this.position = position;
        this.texture = texture;
    }

    public virtual void Update(string parameter){}

    public virtual void Move(string direction){}

    public virtual void Draw(){}

}