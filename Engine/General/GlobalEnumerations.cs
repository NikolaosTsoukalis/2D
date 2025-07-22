
namespace _2D_RPG;

public class GlobalEnumarations
{

    #region Textures

    public enum TextureLibrary
    {
        //CHARACTER
        Character_Idle,
        Character_Walk,
        Character_MeleeAttack,
    }

    public enum TextureLibraryUI
    {
        None,
        Bottom_Button_Free,
        Bottom_Button_Pressed,
        Bottom_Button_Disabled,
        Middle_Button_Free,
        Middle_Button_Pressed,
        Middle_Button_Disabled,
        Top_Button_Free,
        Top_Button_Pressed,
        Top_Button_Disabled,

    }

    public enum TextureLibraryTiles
    {
        Grass,
        Grass1,
        Grass2,
        Grass3,
        Sand,
        Stone,
        Wall,
        Water,
        Wood,
    }

    #endregion

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
        Debug,

        //FUNCTION
        TextBox,
        SliderVertical,
        SliderHorizontal,
        BackButton,
        QuitButton,
        CreateWorldButton,
        LoadWorldFromWorldListButton,

        //      MENU NAVIGATION

        //      -MAIN MENU-
        NavigateStartGameMenuButton,
        NavigateMainMenuSettingsMenuButton,

        //      -START GAME MENU-

        NavigateWorldListMenuButton,
        NavigateNewWorldSettingsMenuButton,

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
