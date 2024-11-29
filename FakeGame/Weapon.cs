namespace FakeGame;

public class Weapon
{
    public string Name { get; set; }
    public int Attack { get; set; }

    public int RangeAttack { get; set; }
    public Weapon(string name, int attack, int rangeAttack)
    {
        Name = name;
        Attack = attack;
        RangeAttack = rangeAttack;
    }
}
