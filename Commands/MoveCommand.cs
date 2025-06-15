namespace _2D_RPG;

class MoveCommand : Command 
{
    #region Values

    private GlobalEnumarations.Directions direction;

    private bool isRunning = false;

    #endregion Values

    #region Constructors

    public MoveCommand(GlobalEnumarations.Directions direction) : base(CommandTypes.MoveCommand)
    {
        this.direction = direction;
    }
    public MoveCommand(GlobalEnumarations.Directions direction, bool isRunning) : base(CommandTypes.MoveCommand)
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
            if(entity.Move(direction,true))
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Run;
            else 
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;
        }
        else
        {
            if(entity.Move(direction,false))
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Walk;
            else 
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;
        }
    }

    public override void Execute(Player entity)
    {
        entity.Direction = direction;
        if(isRunning)
        {
            if(entity.Move(direction,true))
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Run;
            else 
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;
        }
        else
        {
            if(entity.Move(direction,false))
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Walk;
            else 
                entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.Idle;
        }
    }

    #endregion Functions
}

