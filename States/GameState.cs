using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class GameState : State
{
    private InputHandler inputhandler;
    private Command command;
    private AnimationHandler animationHandler;
    private EntityHandler entityHandler;
    readonly Player player = new Player(Globals.EntityTypes.Player,null,Vector2.Zero);
    readonly MovingEntity slime = new MovingEntity(Globals.EntityTypes.Slime,null,new Vector2(300,400));

    public GameState(Main main) : base(main)
    {
        entityHandler = new();
        animationHandler = new();
        inputhandler = new();
        EntityHandler.AddEntityToList(player);
        AnimationDataHandler.LoadPlayerAnimationDictionary();
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
            player.ActionIdentifier = AnimationDataHandler.ActionIdentifier.Idle;

        animationHandler.UpdateAnimationList(EntityHandler.EntityList);
        animationHandler.UpdateAnimations();

    }

    public override void PostUpdate(GameTime gameTime)
    {
        if(player.ActionIdentifier == AnimationDataHandler.ActionIdentifier.Run)
        {
            if(!EntityHandler.EntityList.Contains(slime))
            {
                AnimationDataHandler.LoadSlimeAnimationDictionary();
                EntityHandler.AddEntityToList(slime);
            }
                

        }
    }

    public override void Draw(GameTime gameTime)
    { 

        Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        animationHandler.DrawAnimations();

        Globals.spriteBatch.End();
    }
}