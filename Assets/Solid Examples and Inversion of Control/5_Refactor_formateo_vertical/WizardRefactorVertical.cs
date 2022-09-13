using UnityEngine;


namespace DefaultNamespace
{
    public class WizardRefactorVertical: AbstractHero
    {
        #region Fields
        private float _baseDamage;
        
        private float _fireDamageMultiplier;
        private float _fireAttackProbability;

        private float _iceDamageMultiplier;
        private float _iceAttackProbability;

        private float _waterDamageMultiplier;
        private float _waterAttackProbability;
        #endregion
     
        #region DoAttack
        public override void DoAttack(IDamageReceiver opponent)
        {
            DoMagicAttack(opponent, MagicAttackType.Fire, _fireDamageMultiplier);
        }

        private void DoMagicAttack(IDamageReceiver opponent, MagicAttackType magicType, float damageMultiplier)
        {
            //logic to select magic type

            // DoSomething1();
            // DoSomething2();
            // DoSomething3();
            // DoSomething4();
            // DoSomething5();

            var damage = Mathf.RoundToInt(_baseDamage * damageMultiplier);
            opponent.ReceiveDamage(quantity: damage);
        }
        #endregion

        #region IDamageReceiver

        public override void ReceiveDamage(int quantity)
        {
            // TODO: update health
            throw new System.NotImplementedException();
        }


        #endregion

        #region Types
        private enum MagicAttackType
        {
            Fire,
            Ice,
            Water
        }
        #endregion

    }
}
