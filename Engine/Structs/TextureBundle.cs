using Microsoft.Xna.Framework.Graphics;

namespace _2D_RPG;
public struct TextureBundle
{
    public Texture2D TextureFree { get; private set;}
    public Texture2D TexturePressed { get; private set;}
    public Texture2D TextureDisabled { get; private set;}

    public TextureBundle(Texture2D textureFree,Texture2D texturePressed, Texture2D textureDisabled)
    {
        TextureFree = textureFree; TexturePressed = texturePressed; TextureDisabled = textureDisabled;
    }
}