using Microsoft.Xna.Framework;

namespace _2D_RPG;

public abstract class Command
{
    public enum CommandTypes
    {
        MoveCommand,
        EnableDebugsCommand,
        ExitCommand,
        FullScreenCommand,
        MeleeAttackCommand,
        ToggleInventoryCommand,
        InteractCommand
    }

    public CommandTypes commandType;

    public Command(CommandTypes commandType)
    {
        this.commandType = commandType;
    }

    public virtual void Execute(Entity entity) { }
    public virtual void Execute(Entity entity, string x) { }

    public virtual void Execute(MovingEntity entity) { }
    public virtual void Execute(MovingEntity entity, string x) { }

    public virtual void Execute(Player entity) { }
    public virtual void Execute(Game game) { }

    public virtual void Execute(Main main) { }
    public virtual void Execute(){}
    
}