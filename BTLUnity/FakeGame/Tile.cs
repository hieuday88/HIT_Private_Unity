namespace FakeGame;

public class Tile
{
    public Character Character { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }

    public Tile(int posX, int posY)
    {
        PosX = posX;
        PosY = posY;
    }
    public bool IsOccupied()
    {
        return Character != null;
    }
}
