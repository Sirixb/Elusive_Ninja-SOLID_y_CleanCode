using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private float _initialSpeed = 1;

    private float _currentSpeed;

    //private bool _isDrunk;

    private IMovable _regularMovable;
    private IMovable _drunkMovable;

    private IMovable _currentMovable;

    private void Awake()
    {
        //_regularMovement = new RegularMovement(_animator, _spriteRenderer, transform);
        //_drunkMovement = new DrunkMovement(_animator, _spriteRenderer, transform);
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
        _currentMovable.DoMove(_currentSpeed);/*_regularMovement*/

        //// Check input
        //var horizontal = Input.GetAxis("Horizontal");
        //_animator.SetFloat("Horizontal", math.abs(horizontal));
        //_spriteRenderer.flipX = horizontal < 0;
        //var x = horizontal * _currentSpeed * Time.deltaTime;
        //if (_isDrunk)
        //    x *= -1;

        //// Move according the input
        //transform.Translate(x, 0.0f, 0.0f);
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
    }
    //Adicion
    public void SetDrunk(float drunkDuration)
    {
        _currentMovable = _drunkMovable;
        //_isDrunk = true;
        StartCoroutine(DisableDrunk(drunkDuration));
    }

    private IEnumerator DisableDrunk(float drunkDuration)
    {
        yield return new WaitForSeconds(drunkDuration);
        //_isDrunk = false;
        _currentMovable = _regularMovable;
    }
}
