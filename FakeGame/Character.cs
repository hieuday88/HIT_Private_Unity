using System.Security.Cryptography;

namespace FakeGame;

public abstract class Character
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public int Damage { get; set; }
    public int RangeAttack { get; set; }

    public int Health { get; set; }
    public void Move(char direction, Tile[,] grid)
    {
        int newX = PosX, newY = PosY;
        switch (direction)
        {
            case 'W': newY--; break;
            case 'S': newY++; break;
            case 'A': newX--; break;
            case 'D': newX++; break;
        }

        if (newX >= 0 && newX < grid.GetLength(0) &&
                newY >= 0 && newY < grid.GetLength(1) &&
                !grid[newX, newY].IsOccupied())
        {
            grid[PosX, PosY].Character = null; // Xóa vị trí cũ
            PosX = newX;
            PosY = newY;
            grid[PosX, PosY].Character = this; // Cập nhật vị trí mới
        }

    }

    public virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
        }

    }

    public bool IsDead() => Health <= 0;

    public abstract void Attack(Tile[,] grid);

    public Character CheckRangeAttack(Tile[,] grid)
    {
        return grid.Cast<Tile>().Where(tile => tile.Character != null && tile.Character != this && Math.Abs(tile.PosX - PosX) <= RangeAttack && Math.Abs(tile.PosY - PosY) <= RangeAttack).Select(tile => tile.Character).FirstOrDefault();
    }
}
