namespace FakeGame;

public class Enemy : Character
{
    private static Random random = new Random();

    public Enemy(int posX, int posY, int health, int damage, int rangeAttack)
    {
        PosX = posX;
        PosY = posY;
        Health = health;
        Damage = damage;
        RangeAttack = rangeAttack;
    }
    public void MoveRandom(Tile[,] grid)
    {
        char[] directions = { 'W', 'S', 'A', 'D' };
        char direction;
        int newX, newY;
        do
        {
            direction = directions[random.Next(directions.Length)];
            newX = PosX;
            newY = PosY;

            switch (direction)
            {
                case 'W': newY--; break;
                case 'S': newY++; break;
                case 'A': newX--; break;
                case 'D': newX++; break;
            }

        } while (newX < 0 || newX >= grid.GetLength(0) || newY < 0 || newY >= grid.GetLength(1) ||
                (grid[newX, newY].IsOccupied() && grid[newX, newY].Character is Enemy));

        grid[PosX, PosY].Character = null; // Xóa vị trí cũ
        PosX = newX;
        PosY = newY;
        grid[PosX, PosY].Character = this; // Cập nhật vị trí mới

    }
    public override void Attack(Tile[,] grid)
    {
        Character target = CheckRangeAttack(grid);
        if (target != null && target is Player) // Chỉ tấn công Player
        {
            target.TakeDamage(Damage);
            Console.WriteLine($"Ke dich tai ({PosX}, {PosY}) tan cong Nguoi choi gay {Damage} sat thuong!");
            if (target.IsDead())
            {
                Console.WriteLine($"Nguoi choi da bi tieu diet!");
            }
        }
        else if (target == null)
        {

            Console.WriteLine($"Ke dich tai ({PosX},{PosY}): Khong tim thay muc tieu trong pham vi tan cong.");
        }


    }
    public override void TakeDamage(int damage)
    {

        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            Console.WriteLine($"Ke dich tai ({PosX}, {PosY}) da bi tieu diet!");
        }
        else
        {
            Console.WriteLine($"Ke dich tai ({PosX}, {PosY}) nhan {damage} sat thuong!");

        }

    }
}
