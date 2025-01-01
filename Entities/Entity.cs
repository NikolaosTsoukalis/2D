using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public abstract class Entity
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

    private string direction;
    public string Direction
    {
        get{return direction;}
        set{direction = value;}
    }

    private string actionIdentifier;
    public string ActionIdentifier
    {
        get{return actionIdentifier;}
        set{actionIdentifier = value;}
    }
    #endregion Values

    #region Constructors
    public Entity(){}
    public Entity(string entityName, Texture2D texture, Vector2 position)
    {
        Name = entityName;
        Position = position;
        Texture = texture;
        if((float)Globals.TotalSeconds <= 1.0)
        {
            ActionIdentifier = "Idle";
            Direction = "S";
        }

    }

    #endregion Constructors

    #region Functions

    public virtual void Update(GameTime gameTime){}

    public virtual void Draw(){}

    #endregion Functions
}