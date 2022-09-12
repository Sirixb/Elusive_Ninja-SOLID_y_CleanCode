using System;
using UnityEngine;

namespace IoC.Solution
{
    public class Movement : MonoBehaviour
    {
        private IHero _hero;
        private float _speed;

        public void SetConfiguration(Hero hero, float speed)
        {
            _hero = hero;
            _speed = speed;
        }

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var x = horizontal * _speed * Time.deltaTime;
            _hero.DoMove(x);
        }
    }
}
