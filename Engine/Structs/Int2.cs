namespace _2D_RPG;

public struct Int2
{
    public int X, Y;

    public Int2(int x, int y)
    {
        X = x; Y = y;
    }
    
    public static Int2 operator -(Int2 left, Int2 right)
    {
        return new Int2(left.X - right.X, left.Y - right.Y);
    }
}