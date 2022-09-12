using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace DefaultNamespace
{
    public class MovementController : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private float _initialSpeed = 1;

        private float _currentSpeed;

        private IMovable _drunkMovable;
        private IMovable _regularMovable;

        private IMovable _currentMovable;

        private void Awake()
        {
            SetMovements();
        }

        private void SetMovements()
        {
            _currentMovable = _regularMovable;
            _drunkMovable = new DrunkMovable(_animator, _spriteRenderer, transform);
            _regularMovable = new RegularMovable(_animator, _spriteRenderer, transform);
        }

        private void FixedUpdate()
        {
            _currentMovable.DoMove(_currentSpeed);
        }

        public void Reset()
        {
            _currentSpeed = _initialSpeed;
            _currentMovable = _regularMovable;
        }

        public void SetSpeed(float newSpeed)
        {
            _currentSpeed = newSpeed;
        }

        public void SetDrunk(float drunkDuration)
        {
            _currentMovable = _drunkMovable;
            StartCoroutine(DisableDrunk(drunkDuration));
        }

        private IEnumerator DisableDrunk(float drunkDuration)
        {
            yield return new WaitForSeconds(drunkDuration);
            _currentMovable = _regularMovable;
        }
    }
}