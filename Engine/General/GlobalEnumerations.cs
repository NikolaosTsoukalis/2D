
namespace _2D_RPG;

public class GlobalEnumarations
{

    #region Textures

    public enum TextureLibraryUI
    {
        None,

        //BUTTON\\
        //-----TYPE L--------\\
        Button_NULL_Type_L,
        Button_Free_Type_L,
        Button_Pressed_Type_L,
        Button_Disabled_Type_L,
        //-----TYPE L--------\\

        //-----TYPE S--------\\
        Button_Free_Type_S,
        Button_Pressed_Type_S,
        Button_Disabled_Type_S,
        //-----TYPE S--------\\

            //TEXTBOX\\
        //-----TYPE L--------\\
        TextBox_Free_Type_L,
        TextBox_Pressed_Type_L,
        //-----TYPE L--------\\

        //-----TYPE S--------\\
        TextBox_Free_Type_S,
        TextBox_Pressed_Type_S,
        //-----TYPE S--------\\

        //-----TYPE B--------\\
        TextBox_Free_Type_B,
        TextBox_Pressed_Type_B,
        //-----TYPE B--------\\

            //MENU\\
        //-----MAIN MENU STATE--------\\
        MainMenu,
        StartGameMenu,
        LoadWorldMenu,
        SettingsMenu,
        CreateWorldMenu,
        //-----MAIN MENU STATE--------\\
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
