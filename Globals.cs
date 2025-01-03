using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

/// <summary>
/// Global class
/// </summary>
/// <remarks>
/// This class handles all Global variables.
/// </remarks>
public class Globals
{
    #region Values
    public static ContentManager content { get; set; }
    public static SpriteBatch spriteBatch { get; set; }
    public static GraphicsDeviceManager _graphics { get; set; }

    private static Dictionary<string,Tuple<Texture2D,string[]>> playerAnimationData;

    public static Dictionary<string,Tuple<Texture2D,string[]>> PlayerAnimationData
    {
        get{return playerAnimationData;}
        set{playerAnimationData = value;}
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

    /// <summary>
    /// Initiallizes a Dictionary for Player animations.
    /// </summary>
    /// <remarks>
    /// This method initiallizes the <see cref="PlayerAnimationData"/> Dictionary, 
    /// which is used as a storage structure for Player entity animations.
    /// The format of the data structure is : {animation name},Tuple({Texture2D},string[totalFrames, timePerFrame]).
    /// This dictionary is used in the <see cref="Animation"/> class.
    /// </remarks>
    public static void LoadPlayerAnimationDictionary()
    {
        //Format : {Texture2D},string[{"entityName","totalFrames","timeOfEachFrame"}]
        PlayerAnimationData = new Dictionary<string,Tuple<Texture2D,string[]>>
        {
            { "Walk",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("Character_Walk_strip80"),["80","0.1"])},
            { "Idle",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("Character_Idle_strip32"),["32","0.3"])},
            { "Run",new Tuple<Texture2D,string[]>(content.Load<Texture2D>("testSpriteWalk_strip32"),["32","0.3"])}
        };
    }

    #endregion Functions
}