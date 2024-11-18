using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
class Entity
{
    #region Values

    private Vector2 position;
    public Vector2 Position 
    {
        get{return position;}
        set{position = value;}
    }
    private Texture2D texture;
    public Texture2D Texture 
    {
        get{return texture;}
        set{texture = value;}
    }

    #endregion Values

    #region Constructors
    public Entity(){}
    public Entity(Vector2 position)
    {
        Position = position;   
    }
    public Entity(Texture2D texture)
    {
        Texture = texture;
    }
    public Entity(Texture2D texture, Vector2 position)
    {
        Position = position;
        Texture = texture;
    }

    #endregion Constructors

    #region Functions

    public virtual void Update(GameTime gameTime){}

    public virtual void Move(string direction){}

    public virtual void Draw(){}

    #endregion Functions
}