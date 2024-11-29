using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace FakeGame;

public class GameManager
{
    public int XWide { get; set; }
    public int YHigh { get; set; }
    public List<Enemy> Enemies { get; set; }
    public Player Player { get; set; }
    public int Turn { get; private set; }
    public bool IsGameOver { get; private set; }

    private GridManager gridManager;


    public GameManager(int xWide, int yHigh)
    {
        XWide = xWide;
        YHigh = yHigh;
        gridManager = new GridManager(XWide, YHigh);
        Enemies = new List<Enemy>();
        IsGameOver = false;
    }

    public void StartBattle()
    {
        SpawnEntity();
        gridManager.Player = Player;
        gridManager.Enemies = Enemies; // Khởi tạo danh sách Enemies trong GridManager
        gridManager.UpdateGrid();

        while (!IsGameOver)
        {
            DisplayGrid();
            TurnPlayer();
            if (IsGameOver) break;

            DisplayGrid();
            TurnEnemy();
        }

        Console.ReadKey(); // Giữ màn hình console hiển thị kết quả
    }
    public void SpawnEntity()
    {
        Enemies = new List<Enemy>();
        Enemies.Add(new Enemy(5, 5, 20, 20, 1));
        Enemies.Add(new Enemy(4, 4, 20, 20, 1));
        Weapon[] wps = new Weapon[3];
        wps[0] = new Weapon("Sword", 5, 1);
        wps[1] = new Weapon("Gun", 10, 2);
        wps[2] = new Weapon("Spear", 5, 2);
        Player = new Player(1, 1, 20, wps);
    }

    public void TurnPlayer()
    {
        Console.WriteLine("Luot cua nguoi choi. Nhap huong di chuyen (W, A, S, D):");
        char input = Char.ToUpper(Console.ReadKey().KeyChar); // Tự động in hoa
        Console.WriteLine(); // Xuống dòng sau khi nhập
        Player.Move(input, gridManager.Grid);     
        Player.Attack(gridManager.Grid); // Player tấn công trong lượt của mình
        gridManager.UpdateGrid(); // Cập nhật lưới *trước* khi kiểm tra
        DisplayGrid();
        CheckWinOrLose(); // Kiểm tra ngay sau khi Player tấn công


    }
    public void TurnEnemy()
    {
        foreach (var enemy in Enemies.ToList())
        {
            enemy.MoveRandom(gridManager.Grid);
            enemy.Attack(gridManager.Grid); // Enemy tấn công Player
            gridManager.UpdateGrid();
            CheckWinOrLose(); // Kiểm tra sau mỗi Enemy tấn công
            if (IsGameOver)
                return;


            gridManager.UpdateGrid();


        }
        if (!IsGameOver)
        {

            DisplayGrid();

        }


    }

    public void CheckWinOrLose()
    {
        if (Player.Health <= 0)
        {
            IsGameOver = true;
            gridManager.UpdateGrid();
            DisplayGrid();  // Hiển thị lưới trước khi thông báo thua
            Console.WriteLine("Ban da thua!");
            return;
        }


        for (int i = Enemies.Count - 1; i >= 0; i--)
        {
            if (Enemies[i].Health <= 0)
            {
                gridManager.Grid[Enemies[i].PosX, Enemies[i].PosY].Character = null; // Xóa khỏi Grid
                Enemies.RemoveAt(i);
            }
        }

        if (Enemies.Count == 0)
        {
            IsGameOver = true;
            gridManager.UpdateGrid();
            DisplayGrid();
            Console.WriteLine("Ban da thang!");
        }

    }

    public void DisplayGrid()
    {
        Console.Clear();

        // Hiển thị máu và vũ khí của người chơi
        Console.WriteLine($"Nguoi choi (P): Mau - {Player.Health}, Vu khi - {Player.CurrentWeapon.Name}");

        for (int y = 0; y < gridManager.Grid.GetLength(1); y++)
        {
            for (int x = 0; x < gridManager.Grid.GetLength(0); x++)
            {
                if (gridManager.Grid[x, y].Character == Player)
                {
                    Console.Write("P ");
                }
                else if (gridManager.Grid[x, y].Character is Enemy)
                {
                    Console.Write("E ");
                }
                else
                {
                    Console.Write(". ");
                }
            }
            Console.WriteLine();
        }

        // Hiển thị máu của từng kẻ địch
        for (int i = 0; i < Enemies.Count; i++)
        {
            Console.WriteLine($"Ke dich {i + 1} (E): Mau - {Enemies[i].Health}");
        }
    }


}