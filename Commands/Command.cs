using System.Reflection.Emit;

class Command
{
    public Command(){}

    public virtual void Execute(Entity entity){}
    public virtual void Execute(Entity entity, string x){}
    
}