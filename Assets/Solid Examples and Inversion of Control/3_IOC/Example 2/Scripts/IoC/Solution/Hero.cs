using UnityEngine;

namespace IoC.Solution
{
    public class Hero : MonoBehaviour, IHero
    {
        [SerializeField] private float _speed;
        [SerializeField] private Movement _movement;

        private void Awake()
        {
            _movement.SetConfiguration(this, _speed);
        }

        public void DoMove(float positionX)
        {
            transform.Translate(positionX, 0.0f, 0.0f);
        }
    }
}
