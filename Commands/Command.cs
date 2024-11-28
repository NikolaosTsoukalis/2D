using Microsoft.Xna.Framework;

class Command
{
    public Command(){}

    public virtual void Execute(Entity entity){}
    public virtual void Execute(Entity entity, string x){}

    public virtual void Execute(MovingEntity entity){}
    public virtual void Execute(MovingEntity entity,string x){}

    public virtual void Execute(Game game){}
    
}