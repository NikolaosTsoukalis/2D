namespace _2D_RPG;

public class GlobalEnumarations
{
    public enum Directions
    {
        Up,
        UpRight,
        UpLeft,
        Right,
        Left,
        Down,
        DownRight,
        DownLeft
    }

    public enum AttributeTypes
    {
        Speed,
        RunningSpeed,
        HP,
        AttackPower,
        Defence,
        Intellect
    }

    public enum ComponentType
    {
        BackButton,
        SettingsButton,
        QuitButton,
        StartGameButton,

    }

    public enum ComponentState
    {
        Free,
        Disabled,
        Clicked
    }
}
