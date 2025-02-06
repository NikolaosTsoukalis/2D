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
    public static ContentManager ContentManager
    {
        get{return ContentManager;}
        set
        {
            if(ContentManager == null)
            {
                ContentManager = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + ContentManager.GetType().ToString() + ".");
            return;
        }
    }
    public static SpriteBatch SpriteBatch
    {
        get{return SpriteBatch;}
        set
        {
            if(SpriteBatch == null)
            {
                SpriteBatch = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + SpriteBatch.GetType().ToString() + ".");
            return;
        }
    }
    public static GraphicsDeviceManager GraphicsDeviceManager 
    {
        get{return GraphicsDeviceManager;}
        set
        {
            if(GraphicsDeviceManager == null)
            {
                GraphicsDeviceManager = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + GraphicsDeviceManager.GetType().ToString() + ".");
            return;
        }
    }

    public static InputHandler Inputhandler
    {
        get{return Inputhandler;}
        set
        {
            if(Inputhandler == null)
            {
                Inputhandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + Inputhandler.GetType().ToString() + ".");
            return;
        }
    }
    public static AnimationHandler AnimationHandler
    {
        get{return AnimationHandler;}
        set
        {
            if(AnimationHandler == null)
            {
                AnimationHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + AnimationHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static AnimationDataHandler AnimationDataHandler
    {
        get{return AnimationDataHandler;}
        set
        {
            if(AnimationDataHandler == null)
            {
                AnimationDataHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + AnimationDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static EntityHandler EntityHandler
    {
        get{return EntityHandler;}
        set
        {
            if(EntityHandler == null)
            {
                EntityHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + EntityHandler.GetType().ToString() + ".");
            return;
        }
    }    
    public static ItemDataHandler ItemDataHandler
    {
        get{return ItemDataHandler;}
        set
        {
            if(ItemDataHandler == null)
            {
                ItemDataHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + ItemDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static EntityDataHandler EntityDataHandler
    {
        get{return EntityDataHandler;}
        set
        {
            if(EntityDataHandler == null)
            {
                EntityDataHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + EntityDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    public static CollisionHandler CollisionHandler
    {
        get{return CollisionHandler;}
        set
        {
            if(CollisionHandler == null)
            {
                CollisionHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + CollisionHandler.GetType().ToString() + ".");
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