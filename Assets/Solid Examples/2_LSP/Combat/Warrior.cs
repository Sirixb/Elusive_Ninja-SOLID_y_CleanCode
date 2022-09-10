namespace Combat
{
    public class Warrior : AbstractHero /*, IDoMeleeAttack// David*/
    {
        //public override bool MeleeAttack => true;
        //public override bool RangeAttack => false;

        private/*public*/ /*override*/ void DoMeleeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        //public override void DoRangeAttack(IDoDamage opponent)
        //{
        //    throw new System.NotImplementedException();
        //}

        public override void AddDamage(int damage)
        {
            
        }

        public override void DoAttack(IDoDamage opponent)
        {
            DoMeleeAttack(opponent);
        }
        
    }
}
