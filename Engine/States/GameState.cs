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
        Globals.EntityHandler = new();
        Globals.AnimationHandler = new();
        Globals.AnimationDataHandler = new();
        Globals.Inputhandler = new();
        Globals.CollisionHandler = new(main);
        Globals.ItemDataHandler = new();
        Globals.EntityHandler.AddEntityToList(player);
    }

    public override void Update(GameTime gameTime)
    {
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

        Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        Globals.AnimationHandler.DrawAnimations();

        if(Globals.enableDebugs)
        {
            Globals.CollisionHandler.DebugDraw(main);
        }
        if(Globals.drawInteraction)
        {
            Globals.SpriteBatch.DrawString(main.MyFont, "Fuck you!", new Vector2(200, 300), Color.White);
        }

        Globals.SpriteBatch.End();
    }

    public void UpdateHandlers()
    {
        Globals.CollisionHandler.Update();
        Globals.AnimationHandler.UpdateAnimationList();
        Globals.AnimationHandler.UpdateAnimations();
    }
}