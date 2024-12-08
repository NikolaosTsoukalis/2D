using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tile;

public class Tile
{
    public int TileId { get; set; }
    public Texture2D Texture { get; set; }
    public Vector2 Position { get; set; }
    public Vector2 Size { get; set; }
    public double Walkability => tileProperties.ContainsKey(TileId) ? tileProperties[TileId].Walkability : 0.0;
    public double Fliability => tileProperties.ContainsKey(TileId) ? tileProperties[TileId].Fliability : 0.0;

    // Constructor for Tile
    public Tile(int tileId, Texture2D texture, Vector2 position, Vector2 size)
    {
        TileId = tileId;
        Position = position;
        Size = size;
        Texture = texture;

        // possibly add a way for the ground to crack but not change
    }

    // Derive the texture from the TileId (through the TileGeneration or some other manager)
    public Texture2D GetTexture(Dictionary<int, Texture2D> tileTextures)
    {
        if (tileTextures.ContainsKey(TileId))
        {
            return tileTextures[TileId];
        }
        else
        {
            throw new ArgumentException($"Texture for tile ID {TileId} not found.");
        }
    }

    public void Draw(SpriteBatch spriteBatch, Dictionary<int, Texture2D> tileTextures)
    {
        // Get the texture based on the TileId from the tileTextures dictionary
        Texture2D texture = GetTexture(tileTextures);

        // Draw the tile at the specified position with the given size
        spriteBatch.Draw(texture, new Rectangle(Position.ToPoint(), Size.ToPoint()), Color.White);
    }

    // Dictionary for walkability and fliability

    public static readonly Dictionary<int, (double Walkability, double Fliability)> tileProperties = new Dictionary<int, (double, double)>
        {
            { 0, (0.0, 1.0) }, // ID 0: Walkability = 0.0, Fliability = 1.0 // grass
            { 1, (1.0, 0.0) }, // ID 1: Walkability = 1.0, Fliability = 0.0 // gravel
            { 2, (0.5, 0.5) }  // ID 2: Walkability = 0.5, Fliability = 0.5 // water
        };


}

