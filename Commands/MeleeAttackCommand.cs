namespace _2D_RPG;

class MeleeAttackCommand : Command 
{
    #region Values
    #endregion Values

    #region Constructors

    public MeleeAttackCommand() : base(CommandTypes.MeleeAttackCommand){}

    #endregion Constructors

    #region Functions
    
    public override void Execute(Player entity)
    {
        //entity.Direction = direction;
        entity.AnimationIdentifier = AnimationDataHandler.AnimationIdentifier.MeleeAttack;
        entity.MeleeAttack();
    }

    #endregion Functions
}

