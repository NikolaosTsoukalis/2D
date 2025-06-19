namespace _2D_RPG;

public class GlobalEnumarations
{
    public enum Directions
    {
        None,
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
        None,
        Speed,
        RunningSpeed,
        HP,
        AttackPower,
        Defence,
        Intellect
    }

    public enum ComponentType
    {
        None,
        TextBox,
        BackButton,
        SettingsButton,
        QuitButton,
        StartGameButton,

    }

    public enum ComponentState
    {
        None,
        Free,
        Disabled,
        Clicked
    }
}
