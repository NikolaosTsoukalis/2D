using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;

public class Debugger
{  
    private static SpriteFont dataTableFont = Globals.ContentManager.Load<SpriteFont>("MyFont");

    public Debugger(){}

    public static void Debug(GameState state, Main main)
    {
        DrawCollisionMap(state, main);
        DrawDataTable(state,main);
    }

    public static void DrawCollisionMap(GameState state, Main main)
    {
        Globals.TileMapHandler.DebugDraw(main, Globals.Camera.GetViewMatrix());
        Globals.CollisionHandler.DebugDraw(main);
    }

    public static void DrawDataTable(GameState state, Main main)
    {
        int percievedWidth = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
        int percievedHeight = Globals.GraphicsDeviceManager.GraphicsDevice.Viewport.Height;

        Vector2 playerPosition = new Vector2((int)state.player.Position.X, (int)state.player.Position.Y);
        Vector2 tablePlayerDataPosition = new Vector2(percievedWidth / 2 + playerPosition.X ,percievedHeight / 2 + playerPosition.Y);
        Vector2 tableTileDataPosition = new Vector2(percievedWidth / 2 + playerPosition.X ,percievedHeight / 2 + playerPosition.Y + 30);
        Globals.SpriteBatch.DrawString(dataTableFont, "Player Position : " + playerPosition.ToString(), tablePlayerDataPosition, Color.White);
        Globals.SpriteBatch.DrawString(dataTableFont, "Tile at Player Position : " + Globals.TileMapHandler.GetTileMap().GetTileTypeAt((int)playerPosition.X / 32 , (int)playerPosition.Y / 32).ToString(),tableTileDataPosition, Color.White);
    
    } 


}