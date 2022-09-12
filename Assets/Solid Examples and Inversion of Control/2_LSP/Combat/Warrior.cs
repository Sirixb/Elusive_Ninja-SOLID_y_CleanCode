namespace Combat
{
    public class Warrior : AbstractHero //, IDoMeleeAttack // David Solution
    {
        public override bool MeleeAttack => true;
        public override bool RangeAttack => false;

        public override void DoMeleeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        //Sintoma de incumplimiento de Liskov por metodos vacios
        public override void DoRangeAttack(IDoDamage opponent)
        {
            throw new System.NotImplementedException();
        }

        public override void AddDamage(int damage)
        {
            
        }
    }
}
