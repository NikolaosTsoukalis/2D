using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class GameState : State
{
    private InputHandler inputhandler;
    private Command command;
    private AnimationHandler animationHandler;
    private AnimationDataHandler animationDataHandler;
    private EntityHandler entityHandler;
    private ItemDataHandler itemDataHandler;
    private CollisionHandler collisionHandler;
    readonly Player player = new Player(EntityDataHandler.GeneralEntityTypes.Player,null,Vector2.Zero);
    readonly CombatEntity slime = new CombatEntity(EntityDataHandler.HostileEntityTypes.Slime,null,new Vector2(300,400));

    public GameState(Main main) : base(main)
    {
        entityHandler = new();
        animationHandler = new();
        animationDataHandler = new();
        inputhandler = new();
        collisionHandler = new(main);
        itemDataHandler = new();
        EntityHandler.AddEntityToList(player);
    }

    public override void Update(GameTime gameTime)
    {
        Globals.UpdateTimeForAnimations(gameTime, main);
        command = inputhandler.HandleInput();
        if(command != null)
        {
            var temp = command.ToString();
            if(command.ToString() == "ExitCommand" || command.ToString() == "FullScreenCommand" || command.ToString() == "_2D_RPG.EnableDebugsCommand") 
            {
                command.Execute(main);
            }
            command.Execute(player);
        }
        else
            player.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;

        collisionHandler.Update();
        animationHandler.UpdateAnimationList(EntityHandler.EntityList);
        animationHandler.UpdateAnimations();

    }

    public override void PostUpdate(GameTime gameTime)
    {
        if(player.AnimationIdentifier == AnimationDataHandler.AnimationIdentifier.Run)
        {
            if(!EntityHandler.EntityList.Contains(slime))
            {
                //AnimationDataHandler.LoadSlimeAnimationDictionary();
                EntityHandler.AddEntityToList(slime);
            }
        }
    }

    public override void Draw(GameTime gameTime)
    { 

        Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        animationHandler.DrawAnimations();

        if(Globals.enableDebugs)
        {
            collisionHandler.Draw(main);
        }

        Globals.spriteBatch.End();
    }
}