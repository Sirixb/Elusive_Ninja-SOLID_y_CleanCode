using System;
using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _initialSpeed = 1;

    private float _currentSpeed;

    private IMovable _regularMovable;
    private IMovable _drunkMovable;

    private IMovable _currentMovable;

    // Other components (sound, effects...) can react to these without this class knowing about them
    public event Action DrunkStarted;
    public event Action SpeedChanged;

    private void Awake()
    {
        Reset();
    }

    public void Configure(IMovable regularMovement ,IMovable drunkMovement)
    {
        _regularMovable = regularMovement;
        _regularMovable.Configure(_animator, _spriteRenderer, transform);
        _drunkMovable = drunkMovement;
        _drunkMovable.Configure(_animator, _spriteRenderer, transform);
    }

    private void FixedUpdate()
    {
        _currentMovable.DoMove(_currentSpeed);
    }

    public void Reset()
    {
        _currentMovable = _regularMovable;
        _currentSpeed = _initialSpeed;
        _animator.SetBool("IsDeath", false);
    }

    public void SetSpeed(float newSpeed)
    {
        _currentSpeed = newSpeed;
        SpeedChanged?.Invoke();
    }

    public void SetDrunk(float drunkDuration)
    {
        _currentMovable = _drunkMovable;
        DrunkStarted?.Invoke();
        StartCoroutine(DisableDrunk(drunkDuration));
    }

    private IEnumerator DisableDrunk(float drunkDuration)
    {
        yield return new WaitForSeconds(drunkDuration);
        _currentMovable = _regularMovable;
    }
}
