namespace _2D_RPG;

class MoveCommand : Command 
{
    #region Values

    private string direction;

    private bool isRunning = false;

    #endregion Values

    #region Constructors

    public MoveCommand(string direction)
    {
        this.direction = direction;
    }
    public MoveCommand(string direction, bool isRunning)
    {
        this.direction = direction;
        this.isRunning = isRunning;
    }

    #endregion Constructors

    #region Functions
    
    public override void Execute(MovingEntity entity)
    {
        entity.Direction = direction;
        if(isRunning)
        {
            entity.ActionIdentifier = AnimationDataHandler.AnimationTypes.Run;
            entity.Move(direction,true);
        }
        else
            entity.ActionIdentifier = AnimationDataHandler.AnimationTypes.Walk;
            entity.Move(direction,false);
    }

    #endregion Functions
}

