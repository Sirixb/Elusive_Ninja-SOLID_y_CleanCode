namespace Combat
{
    public abstract class AbstractHero : IDoDamage
    {
        public abstract bool MeleeAttack { get; }
        public abstract bool RangeAttack { get; }

        public abstract void AddDamage(int damage);

        public abstract void DoMeleeAttack(IDoDamage opponent);
        public abstract void DoRangeAttack(IDoDamage opponent);

    }
}
