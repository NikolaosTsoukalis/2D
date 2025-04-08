using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class GameState : State
{

    public bool DebugMode = false;
    private Command command;
    readonly Player player;
    readonly HostileEntity slime;


    private Inventory Inventory;

    //HELLO
    public GameState(Main main) : base(main)
    {
        //Handler Initiallization 
        Globals.EntityHandler = new();
        Globals.AnimationHandler = new();
        Globals.Inputhandler = new();
        Globals.CollisionHandler = new(main);
        
        Globals.TileMapHandler = new();

        //Data Handler Initiallization
        Globals.AnimationDataHandler = new();
        Globals.ItemDataHandler = new();
        Globals.EntityDataHandler = new();

        Globals.TileDataHandler = new();
        
        //Game State specific
        Inventory = new();
        Globals.Camera = new();
        Globals.Camera.LookAt(Vector2.Zero);
        
        player = new Player(EntityDataHandler.NonHostileEntityTypes.Player,null,new Vector2(400, 320));
        slime = new HostileEntity(EntityDataHandler.HostileEntityTypes.Slime,null,new Vector2(300,400));
        Globals.EntityHandler.AddEntityToList(player);

    }

    public override void Update(GameTime gameTime)
    {
        Globals.Camera.LookAt(player.Position);
        Globals.UpdateTimeForAnimations(gameTime, main);
        command = Globals.Inputhandler.HandleInput();
        if(command != null)
        {
            if(command.commandType == Command.CommandTypes.ExitCommand || command.commandType == Command.CommandTypes.FullScreenCommand || command.commandType == Command.CommandTypes.EnableDebugsCommand) 
            {
                command.Execute(main);
            }
            command.Execute(player);
        }
        else
            player.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;

        UpdateHandlers();
    }

    public override void PostUpdate(GameTime gameTime)
    {
        if(player.AnimationIdentifier == AnimationDataHandler.AnimationIdentifier.Run)
        {
            if(!Globals.EntityHandler.GetEntityList().Contains(slime))
            {
                //AnimationDataHandler.LoadSlimeAnimationDictionary();
                Globals.EntityHandler.AddEntityToList(slime);
            }
        }
    }

    public override void Draw(GameTime gameTime)
    { 

        Globals.SpriteBatch.Begin(transformMatrix: Globals.Camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
        Globals.TileMapHandler.Draw();
        Globals.AnimationHandler.DrawAnimations();

        if(Globals.enableDebugs)
        {
            Globals.CollisionHandler.DebugDraw(main);
        }
        if(Globals.drawInteraction)
        {
            Globals.SpriteBatch.DrawString(main.MyFont, "FUCK OFF!", new Vector2(200, 300), Color.White);
        }

        Globals.SpriteBatch.End();
    }

    public void UpdateHandlers()
    {
        Globals.TileMapHandler.Update();
        Globals.CollisionHandler.Update();
        Globals.AnimationHandler.UpdateAnimationList();
        Globals.AnimationHandler.UpdateAnimations();
    }
}