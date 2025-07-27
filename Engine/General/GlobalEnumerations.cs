
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
        //Buttons

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


        //TextBox's
        Middle_TextBox_Small_Free,
        Middle_TextBox_Small_Disabled,

        Middle_TextBox_Big_Free,
        Middle_TextBox_Big_Disabled
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
        DebugButton,

        //FUNCTION
        TextBox,
        SliderVertical,
        SliderHorizontal,
        BackButton,
        QuitButton,
        NavigationButton,
        CreateAndLoadWorldButton,
        LoadWorldButton,
        SaveWorldButton,
        SaveWorldAndQuitButton,
    }

    public enum MenuNavigationPaths
    {
        //Main Menu
        None,
        MainMenu,
        MainMenuToStartGame,
        MainMenuToSettings,

        // Start Game Menu
        StartGameToCreateWorld,
        StartGameToLoadWorld,

        //Create World Menu
        CreateWorldToGameState,
        CreateWorldToMainMenu,


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
