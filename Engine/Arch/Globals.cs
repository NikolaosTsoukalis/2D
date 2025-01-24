using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2D_RPG;

/// <summary>
/// Global class
/// </summary>
/// <remarks>
/// This class handles all Global variables.
/// </remarks>
public class Globals
{
    #region Enums
    public enum CommandTypes
    {
        MoveUp,
        MoveDown,
        MoveRight,
        MoveLeft,
        OpenGeneralMenu,
        SoftToggleRun,
        MeleeAttack,
        OpenInventory

    }

    public enum EntityTypes
    {
        Player,
        Tree,
        Rock,
        House,
        Door,
        Deer,
        Slime

    }
    #endregion Enums

    #region Values
    public static ContentManager content { get; set; }
    public static SpriteBatch spriteBatch { get; set; }
    public static GraphicsDeviceManager _graphics { get; set; }

    private static Dictionary<CommandTypes,Keys> keyBindings;

    public static Dictionary<CommandTypes,Keys> KeyBindings
    {
        get{return keyBindings;}
        set{keyBindings = value;}
    }

    public static float TotalSeconds { get; set; }

    #endregion Values

    #region Functions

    /// <summary>
    /// Tracks the TotalSeconds passed for each Update and Draw call, and used for Animation
    /// </summary>
    /// <param name="gameTime">
    /// Provides a snapshot of timing values, such as the time elapsed since the last update.
    /// </param>
    /// <param name="game">
    /// This object resembles the base Game class.
    /// </param>
    /// <remarks>
    /// This method updates the <see cref="TotalSeconds"/> value, which tracks the time passed for at the start of each <see cref="Main.Update"/> call.
    /// It is used for the <see cref="Animation"/> class, to Update the Animation frame of each animation. 
    /// </remarks>
    public static void UpdateTimeForAnimations(GameTime gameTime, Game game)
    {
        TotalSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public static void LoadKeyBindingsDictionary()
    {
        keyBindings = new Dictionary<CommandTypes, Keys>
        {
            { CommandTypes.MoveUp, Keys.W },
            { CommandTypes.MoveDown, Keys.S },
            { CommandTypes.MoveLeft, Keys.A },
            { CommandTypes.MoveRight, Keys.D },
            { CommandTypes.OpenGeneralMenu, Keys.Escape },
            { CommandTypes.SoftToggleRun, Keys.LeftShift },
            { CommandTypes.OpenInventory, Keys.E }
        };
    }

    #endregion Functions
}