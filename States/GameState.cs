using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class GameState : State
{
    private InputHandler inputhandler;
    private Command command;
    private AnimationHandler animationHandler;
    private EntityHandler entityHandler;
    readonly MovingEntity player = new MovingEntity("Player",null,Vector2.Zero);

    public GameState(Main main) : base(main)
    {
        entityHandler = new();
        animationHandler = new();
        inputhandler = new();
        EntityHandler.AddEntityToList(player);
    }

    public override void Update(GameTime gameTime)
    {
        Globals.UpdateTimeForAnimations(gameTime, main);
        command = inputhandler.HandleInput();
        if(command != null)
        {
            if(command.ToString() == "ExitCommand" || command.ToString() == "FullScreenCommand")
            {
                command.Execute(main);
            } 
            command.Execute(player);
        }
        else
            player.ActionIdentifier = "Idle";

        animationHandler.Update(EntityHandler.EntityList);
        animationHandler.AnimationsUpdate();
    }

    public override void PostUpdate(GameTime gameTime)
    {

    }

    public override void Draw(GameTime gameTime)
    { 
        Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        animationHandler.AnimationsDraw();

        Globals.spriteBatch.End();
    }
}