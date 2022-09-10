namespace Combat
{
    public class Archer : AbstractHero/*, IDoRangeAttack*/
    {
        //public override bool MeleeAttack => false;
        //public override bool RangeAttack => true;

        //public override void DoMeleeAttack(IDoDamage opponent)
        //{
        //    throw new System.NotImplementedException();
        //}

        public /*public*/ /*override*/ void DoRangeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        public override void AddDamage(int damage)
        {
        }
        
        public override void DoAttack(IDoDamage opponent)
        {
            DoRangeAttack(opponent);
        }

    }
}
