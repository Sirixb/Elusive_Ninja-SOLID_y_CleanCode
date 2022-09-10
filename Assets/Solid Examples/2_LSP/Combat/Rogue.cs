
using UnityEngine;

namespace Combat
{
    public class Rogue : AbstractHero//, IDoRangeAttack, IDoMeleeAttack
    {
        //public override bool MeleeAttack => true;
        //public override bool RangeAttack => true; 
        
        private /*public*/ /*override*/ void DoMeleeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        private /*override*/ void DoRangeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
        }

        public override void AddDamage(int damage)
        {
            
        }

        public override void DoAttack(IDoDamage opponent)
        {
            if (Random.Range(1, 100) > 50)
            {
               DoMeleeAttack(opponent);
            }
            else
            {
               DoRangeAttack(opponent);
            }
        }
    }
}
