namespace Combat
{
    public class Archer : AbstractHero//, IDoRangeAttack // David Solution
    {
        public override bool MeleeAttack => false;
        public override bool RangeAttack => true;

        //Sintoma de incumplimiento de Liskov por metodos vacios
        public override void DoMeleeAttack(IDoDamage opponent)
        {
            throw new System.NotImplementedException();
        }

        public override void DoRangeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        public override void AddDamage(int damage)
        {
        }
        
    }
}
