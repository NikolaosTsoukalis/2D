using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Debugger
{  
    #region Fields

    private static SpriteFont dataTableFont = Globals.ContentManager.Load<SpriteFont>("MyFont");

    #endregion Fields

    #region Constructors

    public Debugger(){}

    #endregion Constructors

    #region DrawFunctions

    public static void Draw(GameState state, Main main, Player player)
    {
        DrawCollisionMap(state, main);
        DrawDataTable(state, main, player);
    }

    public static void DrawCollisionMap(GameState state, Main main)
    {
        Globals.TileMapHandler.DebugDraw(main, Globals.Camera.GetViewMatrix());
        Globals.CollisionHandler.DebugDraw(main);
    }

    public static void DrawDataTable(GameState state, Main main,Player player)
    {
        // Screen Size
        int ScreenWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        int ScreenHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

        // Data
        Vector2 playerPosition = new Vector2((int)player.Position.X, (int)player.Position.Y);
        Vector2 tablePlayerDataPosition = new Vector2(playerPosition.X - ScreenWidth / 2 + 10, playerPosition.Y - ScreenHeight / 2);
        Vector2 tableTileDataPosition = new Vector2(playerPosition.X - ScreenWidth / 2 + 10, playerPosition.Y - ScreenHeight / 2 + 30);

        // Conditions
        bool isAtLimitX = player.Position.X - ScreenWidth / 2 - 64 < 0 || player.Position.X + ScreenWidth / 2 + 64 > Globals.WorldSize.X;
        bool isAtLimitY = player.Position.Y - ScreenHeight / 2 - 64 < 0 || player.Position.Y + ScreenHeight / 2 + 64 > Globals.WorldSize.X;
        
        // Draw
        if(isAtLimitX && !isAtLimitY)
        {
            tablePlayerDataPosition.X =  10;
            tableTileDataPosition.X =  10;
        }
        else if(!isAtLimitX && isAtLimitY)
        {
            tablePlayerDataPosition.Y = ScreenHeight - 30;
            tableTileDataPosition.Y = 10;
        }
        else if(isAtLimitX && isAtLimitY)
        {
            tablePlayerDataPosition.X = 10;
            tableTileDataPosition.X = 10;
            
            tablePlayerDataPosition.Y = 20;
            tableTileDataPosition.Y = 10;
        }
        Globals.SpriteBatch.DrawString(dataTableFont, "Player Position : " + playerPosition.ToString(), tablePlayerDataPosition, Color.White);
        Globals.SpriteBatch.DrawString(dataTableFont, "Tile at Player Position : " + Globals.TileMapHandler.GetTileMap().GetTileTypeAt((int)playerPosition.X / 32 , (int)playerPosition.Y / 32).ToString(),tableTileDataPosition, Color.White);
        
    } 

    #endregion DrawFunctions

    #region LogicFuctions

    #endregion LogicFunctions
}