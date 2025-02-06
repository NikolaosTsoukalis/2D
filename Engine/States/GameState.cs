using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class GameState : State
{
    private Command command;
    readonly Player player = new Player(EntityDataHandler.GeneralEntityTypes.Player,null,Vector2.Zero);
    readonly HostileEntity slime = new HostileEntity(EntityDataHandler.HostileEntityTypes.Slime,null,new Vector2(300,400));

    public GameState(Main main) : base(main)
    {
        Globals.entityHandler = new();
        Globals.animationHandler = new();
        Globals.animationDataHandler = new();
        Globals.inputhandler = new();
        Globals.collisionHandler = new(main);
        Globals.itemDataHandler = new();
        Globals.entityHandler.AddEntityToList(player);
    }

    public override void Update(GameTime gameTime)
    {
        Globals.UpdateTimeForAnimations(gameTime, main);
        command = Globals.inputhandler.HandleInput();
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
            if(!Globals.entityHandler.GetEntityList().Contains(slime))
            {
                //AnimationDataHandler.LoadSlimeAnimationDictionary();
                Globals.entityHandler.AddEntityToList(slime);
            }
        }
    }

    public override void Draw(GameTime gameTime)
    { 

        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        Globals.AnimationHandler.DrawAnimations();

        if(Globals.enableDebugs)
        {
            Globals.CollisionHandler.Draw(main);
        }

        Globals.spriteBatch.End();
    }

    public void UpdateHandlers()
    {
        Globals.collisionHandler.Update();
        Globals.animationHandler.UpdateAnimationList();
        Globals.animationHandler.UpdateAnimations();
    }
}