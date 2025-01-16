namespace _2D_RPG;

class MeleeAttackCommand : Command 
{
    #region Values

    private string direction;

    #endregion Values

    #region Constructors

    public MeleeAttackCommand(string direction)
    {
        //this.direction = direction;
    }

    #endregion Constructors

    #region Functions
    
    public override void Execute(MovingEntity entity)
    {
        //entity.Direction = direction;
        entity.ActionIdentifier = AnimationDataHandler.ActionIdentifier.MeleeAttack;
        entity.MeleeAttack();
    }

    #endregion Functions
}

