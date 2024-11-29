namespace FakeGame;

class Program
{
    static void Main(string[] args)
    {
        // Khởi tạo kích thước lưới
        int gridWidth = 8;
        int gridHeight = 8;

        // Tạo GameManager
        GameManager gameManager = new GameManager(gridWidth, gridHeight);

        // Bắt đầu game
        gameManager.StartBattle();

        // Vòng lặp chính của game
        while (!gameManager.IsGameOver)
        {
            gameManager.DisplayGrid(); // Hiển thị bản đồ
            gameManager.TurnPlayer(); // Lượt người chơi
            if (gameManager.IsGameOver) break;

            gameManager.TurnEnemy(); // Lượt quái vật
            gameManager.CheckWinOrLose(); // Kiểm tra kết quả
        }

        // Hiển thị kết quả cuối cùng       
        Console.ReadKey();
    }
}