class MoveCommand : Command 
{
    private string direction;

    private bool isRunning = false;

    public MoveCommand(string direction)
    {
        this.direction = direction;
    }
    public MoveCommand(string direction, bool isRunning)
    {
        this.direction = direction;
        this.isRunning = isRunning;
    }
    
    public override void Execute(MovingEntity entity)
    {
        entity.Direction = direction;
        if(isRunning)
        {
            entity.Move(direction,true);
        }
        else
            entity.Move(direction,false);
    }

    
}

