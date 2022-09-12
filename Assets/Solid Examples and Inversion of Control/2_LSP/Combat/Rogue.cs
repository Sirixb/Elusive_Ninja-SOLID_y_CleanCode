using UnityEngine;

namespace Combat
{
    public class Rogue : AbstractHero//, IDoRangeAttack, IDoMeleeAttack   // David Solution
    {
        public override bool MeleeAttack => true;
        public override bool RangeAttack => true;

        public override void DoMeleeAttack(IDoDamage opponent)
        {
            opponent.AddDamage(10);
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
