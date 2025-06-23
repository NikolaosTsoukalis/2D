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

    #region Values
    private static ContentManager contentManager;
    public static ContentManager ContentManager
    {
        get { return contentManager; }
        set
        {
            if (contentManager == null)
            {
                contentManager = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + contentManager.GetType().ToString() + ".");
            return;
        }
    }
    private static SpriteBatch spriteBatch;
    public static SpriteBatch SpriteBatch
    {
        get { return spriteBatch; }
        set
        {
            if (spriteBatch == null)
            {
                spriteBatch = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + spriteBatch.GetType().ToString() + ".");
            return;
        }
    }
    private static GraphicsDeviceManager graphicsDeviceManager;
    public static GraphicsDeviceManager GraphicsDeviceManager
    {
        get { return graphicsDeviceManager; }
        set
        {
            if (graphicsDeviceManager == null)
            {
                graphicsDeviceManager = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + graphicsDeviceManager.GetType().ToString() + ".");
            return;
        }
    }
    private static InputHandler inputHandler;
    public static InputHandler InputHandler
    {
        get { return inputHandler; }
        set
        {
            if (inputHandler == null)
            {
                inputHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + inputHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static AnimationHandler animationHandler;
    public static AnimationHandler AnimationHandler
    {
        get { return animationHandler; }
        set
        {
            if (animationHandler == null)
            {
                animationHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + animationHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static AnimationDataHandler animationDataHandler;
    public static AnimationDataHandler AnimationDataHandler
    {
        get { return animationDataHandler; }
        set
        {
            if (animationDataHandler == null)
            {
                animationDataHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + animationDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static EntityHandler entityHandler;
    public static EntityHandler EntityHandler
    {
        get { return entityHandler; }
        set
        {
            if (entityHandler == null)
            {
                entityHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + entityHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static ItemDataHandler itemDataHandler;
    public static ItemDataHandler ItemDataHandler
    {
        get { return itemDataHandler; }
        set
        {
            if (itemDataHandler == null)
            {
                itemDataHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + itemDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static EntityDataHandler entityDataHandler;
    public static EntityDataHandler EntityDataHandler
    {
        get { return entityDataHandler; }
        set
        {
            if (entityDataHandler == null)
            {
                entityDataHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + entityDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static CollisionHandler collisionHandler;
    public static CollisionHandler CollisionHandler
    {
        get { return collisionHandler; }
        set
        {
            if (collisionHandler == null)
            {
                collisionHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + collisionHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static TileDataHandler tileDataHandler;
    public static TileDataHandler TileDataHandler
    {
        get { return tileDataHandler; }
        set
        {
            if (tileDataHandler == null)
            {
                tileDataHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + tileDataHandler.GetType().ToString() + ".");
            return;
        }
    }
    private static TileMapHandler tileMapHandler;
    public static TileMapHandler TileMapHandler
    {
        get { return tileMapHandler; }
        set
        {
            if (tileMapHandler == null)
            {
                tileMapHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + tileMapHandler.GetType().ToString() + ".");
            return;
        }
    }

    private static MenuHandler menuHandler;
    public static MenuHandler MenuHandler
    {
        get { return menuHandler; }
        set
        {
            if (menuHandler == null)
            {
                menuHandler = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + menuHandler.GetType().ToString() + ".");
            return;
        }
    }

    private static Camera2D camera;
    public static Camera2D Camera
    {
        get { return camera; }
        set
        {
            if (camera == null)
            {
                camera = value;
                return;
            }
            Console.Out.WriteLine("WARNING : Can't create more than 1 instance of " + camera.GetType().ToString() + ".");
            return;
        }
    }

    /*
    private static Dictionary<Command.CommandTypes, Keys> keyBindings;

    public static Dictionary<Command.CommandTypes,Keys> KeyBindings
    {
        get{return keyBindings;}
        set{keyBindings = value;}
    }
    */

    public static MouseState PreviousMouse { get; set; }
    public static MouseState CurrentMouse { get; set; }
    public static float TotalSeconds { get; set; }

    public static float FPS = 60f;

    public static bool enableDebugs = false;

    public static bool ToggleInventory = false;

    public static bool drawInteraction = false;

    public static int seed = 10;

    public static int TileSize = 32;

    public static Vector2 WorldSize = new Vector2(3200, 3200);

    public static SpriteFont Font;

    public static int Volume;
    public static int Sensitivity;

    #endregion Values

    #region Functions

    public static void UpdateTimeForAnimations(GameTime gameTime, Game game)
    {
        TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public static void LoadFontTexture()
    {
        Font = ContentManager.Load<SpriteFont>("MyFont");
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