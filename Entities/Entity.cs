using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public abstract class Entity
{
    #region Values

    private Dictionary<Globals.AttributeTypes,int> attributes;
    public Dictionary<Globals.AttributeTypes,int> Attributes
    {
        get{return attributes;}
        set{attributes = value;}
    }
    private bool isInteractable;
    public bool IsInteractable 
    {
        get{return isInteractable;}
        set{isInteractable = value;}
    }

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

    private Globals.Directions direction;
    public Globals.Directions Direction
    {
        get{return direction;}
        set{direction = value;}
    }

    private AnimationDataHandler.AnimationIdentifier animationIdentifier;
    public AnimationDataHandler.AnimationIdentifier AnimationIdentifier
    {
        get{return animationIdentifier;}
        set{animationIdentifier = value;}
    }

    #endregion Values

    #region Constructors
    public Entity(){}
    public Entity(string entityName, Texture2D texture, Vector2 position)
    {
        Name = entityName;
        Position = position;
        Texture = texture;
        Attributes = new();
        InitiallizeGraphicalValues();
        IsInteractable = (Enum.TryParse(entityName, true, out EntityDataHandler.HostileEntityTypes entity)); // THIS HAS TO CHANGE TO FIND AN INTERACTABLE SIGNATURE ON THE ENTITY.
    }

    #endregion Constructors

    #region Functions

    public virtual void Update(GameTime gameTime){}

    public virtual void Draw(){}

    public void InitiallizeGraphicalValues()
    {
        if((float)Globals.TotalSeconds <= 1.0)
        {
            AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;
            Direction = Globals.Directions.Down;
        }
    }

    public virtual void Interact(){}

    public virtual void getInteractedWith(){}

    public virtual void AssignAttributes(){}

    public int GetAttribute(Globals.AttributeTypes type)
    {
        PropertyInfo prop = GetType().GetProperty(type.ToString());
        return prop != null ? (int)prop.GetValue(this) : 0;
    }

    public void ModifyAttribute(Globals.AttributeTypes type, int amount)
    {
        PropertyInfo prop = GetType().GetProperty(type.ToString());
        if (prop != null && prop.CanWrite)
        {
            int currentValue = (int)prop.GetValue(this);
            prop.SetValue(this, currentValue + amount);
        }
    }

    #endregion Functions
}