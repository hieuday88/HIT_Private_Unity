namespace FakeGame;

public class GridManager
{
    public int XWide { get; set; }
    public int YHigh { get; set; }
    public List<Enemy> Enemies { get; set; }
    public Player Player { get; set; }
    public Tile[,] Grid { get; set; }

    public GridManager(int xWide, int yHigh)
    {
        XWide = xWide;
        YHigh = yHigh;
        Grid = new Tile[XWide, YHigh];
        Enemies = new List<Enemy>();

        for (int x = 0; x < XWide; x++)
        {
            for (int y = 0; y < YHigh; y++)
            {
                Grid[x, y] = new Tile(x, y);
            }
        }
        UpdateGrid();
    }

    public void UpdateGrid()
    {
        // Xóa trạng thái cũ
        for (int x = 0; x < XWide; x++)
        {
            for (int y = 0; y < YHigh; y++)
            {
                if (Grid[x, y] != null)
                {
                    Grid[x, y].Character = null;
                }
            }
        }

        // Cập nhật trạng thái cho các Enemy
        foreach (var enemy in Enemies)
        {
            if (Grid[enemy.PosX, enemy.PosY] != null)
            {
                Grid[enemy.PosX, enemy.PosY].Character = enemy;
            }
        }

        // Cập nhật trạng thái cho Player
        if (Player != null && Grid[Player.PosX, Player.PosY] != null)
        {
            Grid[Player.PosX, Player.PosY].Character = Player;
        }


    }
}
