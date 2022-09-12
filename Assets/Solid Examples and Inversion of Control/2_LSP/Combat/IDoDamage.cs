public interface IDoDamage
{
    void AddDamage(int damage);
}

//Solucion David
public interface IDoRangeAttack
{
    void DoRangeAttack(IDoDamage opponent);
}

public interface IDoMeleeAttack
{
    void DoMeleeAttack(IDoDamage opponent);
}