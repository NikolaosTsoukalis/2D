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

    private FieldInfo FieldInfo;

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
        this.AssignAttributes();
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
        FieldInfo = GetType().GetField(type.ToString(), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
        return FieldInfo != null ? (int)FieldInfo.GetValue(this) : 0;
    }

    public void ModifyAttribute(Globals.AttributeTypes type, int amount)
    {
        FieldInfo = this.GetType().GetField(type.ToString(), BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
        if (FieldInfo != null)
        {
            int currentValue = (int)FieldInfo.GetValue(this);
            FieldInfo.SetValue(this, currentValue + amount);
        }
        else
            Console.WriteLine("The object '" + this.Name +"' doe not have a field '" + FieldInfo.ToString() +"'.");
    }

    #endregion Functions
}