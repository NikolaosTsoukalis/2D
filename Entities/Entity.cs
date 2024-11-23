using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
public class Entity
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

    private string name;
    public string Name
    {
        get{return name;}
        set{name = value;}
    }

    #endregion Values

    #region Constructors
    public Entity(){}

    public Entity(string entityName, Texture2D texture, Vector2 position)
    {
        Name = entityName;
        Position = position;
        Texture = texture;
    }

    #endregion Constructors

    #region Functions

    public virtual void Update(GameTime gameTime){}

    public virtual void Move(string direction){}

    public virtual void Move(string direction, bool isRunning){}

    public virtual void Draw()
    {
        Globals.spriteBatch.Draw(Texture, Position, new Rectangle(0,0, Texture.Width,Texture.Height), Color.White, 0,Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
    }

    #endregion Functions
}