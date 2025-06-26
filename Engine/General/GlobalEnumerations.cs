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
        SliderVertical,
        SliderHorizontal,
        BackButton,
        SettingsButton,
        QuitButton,
        StartGameButton,
        CreateWorldSettingsButton,
        LoadWorldListButton,
        LoadWorldButton,

    }

    public enum SliderComponentValues
    {
        None,
        Volume,
        Sensitivity,
    }

    public enum ComponentState
    {
        None,
        Free,
        Disabled,
        Pressed
    }
}
