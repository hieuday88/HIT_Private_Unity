namespace FakeGame;

public class Player : Character
{
    public Weapon CurrentWeapon { get; private set; }

    private static Random random = new Random();
    public Player(int posX, int posY, int health, Weapon[] wps)
    {
        PosX = posX;
        PosY = posY;
        Health = health;
        CurrentWeapon = RandomizeWeapon(wps);
        Damage = CurrentWeapon.Attack;
        RangeAttack = CurrentWeapon.RangeAttack;

    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Console.WriteLine($"Player nhận {damage} sát thương!");
    }

    private Weapon RandomizeWeapon(Weapon[] wps)
    {
        int index = random.Next(0, wps.Length);
        return wps[index];
    }
    public override void Attack(Tile[,] grid)
    {
        Character target = CheckRangeAttack(grid);
        if (target != null)
        {
            target.TakeDamage(CurrentWeapon.Attack);
            Console.WriteLine($"Nguoi choi tan cong Ke dich tai ({target.PosX}, {target.PosY}) gay {CurrentWeapon.Attack} sat thuong!");
            if (target.IsDead())
            {
                Console.WriteLine($"Ke dich tai ({target.PosX}, {target.PosY}) da bi tieu diet!");
            }
        }
        else
        {
            Console.WriteLine("Khong tim thay muc tieu trong pham vi tan cong.");
        }
    }
}
