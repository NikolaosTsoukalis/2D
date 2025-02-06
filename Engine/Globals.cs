using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

/// <summary>
/// Global class
/// </summary>
/// <remarks>
/// This class handles all Global variables.
/// </remarks>
public class Globals
{
    #region Enums

    public enum Directions
    {
        Up,
        UpRight,
        UpLeft,
        Right,
        Left,
        Down,
        DownRight,
        DownLeft
    }

    #endregion Enums

    #region Values
    public static ContentManager content
    {
        get{return content;}
        set
        {
            if(content == null)
            {
                content = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + content.GetType().ToString() + ".");
            return;
        }
    }
    public static SpriteBatch spriteBatch
    {
        get{return spriteBatch;}
        set
        {
            if(spriteBatch == null)
            {
                spriteBatch = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + spriteBatch.GetType().ToString() + ".");
            return;
        }
    }
    public static GraphicsDeviceManager _graphics 
    {
        get{return _graphics;}
        set
        {
            if(_graphics == null)
            {
                _graphics = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + _graphics.GetType().ToString() + ".");
            return;
        }
    }

    public static InputHandler inputhandler
    {
        get{return inputhandler;}
        set
        {
            if(inputhandler == null)
            {
                inputhandler = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + inputhandler.GetType().ToString() + ".");
            return;
        }
    }
    public static AnimationHandler animationHandler
    {
        get{return animationHandler;}
        set
        {
            if(animationHandler == null)
            {
                animationHandler = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + animationHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static AnimationDataHandler animationDataHandler
    {
        get{return animationDataHandler;}
        set
        {
            if(animationDataHandler == null)
            {
                animationDataHandler = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + animationDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static EntityHandler entityHandler
    {
        get{return entityHandler;}
        set
        {
            if(entityHandler == null)
            {
                entityHandler = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + entityHandler.GetType().ToString() + ".");
            return;
        }
    }    
    public static ItemDataHandler itemDataHandler
    {
        get{return itemDataHandler;}
        set
        {
            if(itemDataHandler == null)
            {
                itemDataHandler = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + itemDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static EntityDataHandler entityDataHandler
    {
        get{return entityDataHandler;}
        set
        {
            if(entityDataHandler == null)
            {
                entityDataHandler = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + entityDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static CollisionHandler collisionHandler
    {
        get{return collisionHandler;}
        set
        {
            if(collisionHandler == null)
            {
                collisionHandler = value;
                return;
            }
            Console.Out.WriteLine("Can't create a more than 1 instance of " + collisionHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static Dictionary<Command.CommandTypes,Keys> keyBindings;

    public static Dictionary<Command.CommandTypes,Keys> KeyBindings
    {
        get{return keyBindings;}
        set{keyBindings = value;}
    }

    public static float TotalSeconds { get; set; }

    public static bool enableDebugs = false;

    #endregion Values

    #region Functions

    public static void UpdateTimeForAnimations(GameTime gameTime, Game game)
    {
        TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

/*
    public static void LoadKeyBindingsDictionary()
    {
        keyBindings = new Dictionary<Command.CommandTypes, Keys>
        {
            { CommandTypes.MoveUp, Keys.W },
            { CommandTypes.MoveDown, Keys.S },
            { CommandTypes.MoveLeft, Keys.A },
            { CommandTypes.MoveRight, Keys.D },
            { CommandTypes.OpenGeneralMenu, Keys.Escape },
            { CommandTypes.SoftToggleRun, Keys.LeftShift },
            { CommandTypes.OpenInventory, Keys.E }
        };
    }
    */

    #endregion Functions
}