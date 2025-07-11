using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

///<Summary>
/// State where the gameplay unfolds
///</Summary>
public class GameState : State
{
    #region Fields
    ///<Summary>
    /// testing debug mode
    ///</Summary>
    public bool DebugMode = false;
    public TileMap TileMap;
    private Command command;
    readonly Player player;
    readonly HostileEntity slime;


    private Inventory Inventory;

    #endregion Fields

    #region Constructors

    ///<Summary>
    /// initialize all handlers in constructor
    ///</Summary>
    public GameState(Main main, TileMap tilemap) : base(main)
    {
        this.TileMap = tilemap;
        InitializeHandlers(main);


        //Game State specific
        Inventory = new();
        Globals.Camera = new();

        //Temporary Entity Initiallization
        player = new Player(EntityDataHandler.NonHostileEntityTypes.Player, null, new Vector2(500, 500));
        slime = new HostileEntity(EntityDataHandler.HostileEntityTypes.Slime, null, new Vector2(300, 400));
        Globals.EntityHandler.AddEntityToList(player);

    }

    #endregion Constructors

    #region GameLoopFunctions

    ///<Summary>
    /// Update
    ///</Summary>
    public override void Update(GameTime gameTime)
    {
        Globals.Camera.LookAt(player.Position);

        Globals.UpdateTimeForAnimations(gameTime, main);

        HandlePlayerInput();

        UpdateHandlers();
    }

    ///<Summary>
    /// post update processing
    ///</Summary>
    public override void PostUpdate(GameTime gameTime)
    {
        if (player.AnimationIdentifier == AnimationDataHandler.AnimationIdentifier.Run)
        {
            if (!Globals.EntityHandler.GetEntityList().Contains(slime))
            {
                //AnimationDataHandler.LoadSlimeAnimationDictionary();
                Globals.EntityHandler.AddEntityToList(slime);
            }
        }
    }

    ///<Summary>
    /// get camera -> draw map around camera and inside -> draw animations
    ///</Summary>
    public override void Draw(GameTime gameTime)
    {

        Globals.SpriteBatch.Begin(transformMatrix: Globals.Camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
        try
        {
            if (CallDrawFuctions()) { } // conditionals in case a Draw function doesnt get called correctly.
            Texture2D tileDebugTexture = new Texture2D(main.GraphicsDevice, 1, 1);
            tileDebugTexture.SetData(new[] { Color.Black });

            Globals.SpriteBatch.Draw(tileDebugTexture, new Vector2(0, 0), Color.Black); // top-left with no offset
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR :" + e);
        }

        Globals.SpriteBatch.End();
    }

    #endregion GameLoopFunctions

    #region GeneralPurposeFunctions
    
    public override bool ManageTextureLibrary()
    {
        try
        {
            if (Globals.TextureLibrary.LoadUITextures() && Globals.TextureLibrary.LoadTextBoxPositionMap())
            {
                return true;
            }
            else
            {
                Console.WriteLine("Texture Library Load failed");
            }
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR ON Loading TextureLibrary: " + e);
            return false;
        }
    }

    public override bool InitializeHandlers(Main main)
    {
        try
        {
            //Handler Initiallization 
            Globals.EntityHandler = new();
            Globals.AnimationHandler = new();
            Globals.InputHandler = new();
            Globals.CollisionHandler = new(main);

            Globals.TileMapHandler = new(TileMap);

            //Data Handler Initiallization
            Globals.AnimationDataHandler = new();
            Globals.ItemDataHandler = new();
            Globals.EntityDataHandler = new();

            Globals.TileDataHandler = new();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR ON INITIALLIZING HANDLERS: " + e);
            return false;
        }
    }

    ///<Summary>
    /// Call Handler Update Functions
    ///</Summary>
    public void UpdateHandlers()
    {
        Globals.TileMapHandler.Update();
        Globals.CollisionHandler.Update();
        Globals.AnimationHandler.UpdateAnimationList();
        Globals.AnimationHandler.UpdateAnimations();
    }
    
    

    ///<Summary>
    /// Call Draw Functions
    ///</Summary>
    public bool CallDrawFuctions()
    {
        try
        {
            if (Globals.enableDebugs)
            {
                Debugger.Draw(this, main, player);
            }
            else
            {
                Globals.TileMapHandler.DrawTileMap(Globals.Camera.GetViewMatrix());
                Globals.AnimationHandler.DrawAnimations();
            }

            if (Globals.drawInteraction)
            {
                Globals.SpriteBatch.DrawString(Globals.ContentManager.Load<SpriteFont>("MyFont"), "FUCK OFF!", new Vector2(200, 300), Color.White);
            }
            return true;

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR : " + e);
            return false;
        }
    }

    public void HandlePlayerInput()
    {
        command = Globals.InputHandler.HandleInput();
        if (command != null)
        {
            if (command.commandType == Command.CommandTypes.ExitCommand || command.commandType == Command.CommandTypes.FullScreenCommand || command.commandType == Command.CommandTypes.EnableDebugsCommand)
            {
                command.Execute(main);
            }
            command.Execute(player);
        }
        else
            player.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;
    }
    
    

    #endregion GeneralPurposeFunctions
}