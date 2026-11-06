using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [SerializeField] private HealtController _healtController;
    [SerializeField] private MovementController _movementController;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _damageClip;
    [SerializeField] private AudioClip _healClip;
    [SerializeField] private AudioClip _drunkClip;
    [SerializeField] private AudioClip _speedUpClip;

    private void OnEnable()
    {
        _healtController.Damaged += OnDamaged;
        _healtController.Healed += OnHealed;
        _movementController.DrunkStarted += OnDrunkStarted;
        _movementController.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable()
    {
        _healtController.Damaged -= OnDamaged;
        _healtController.Healed -= OnHealed;
        _movementController.DrunkStarted -= OnDrunkStarted;
        _movementController.SpeedChanged -= OnSpeedChanged;
    }

    private void OnDamaged()
    {
        Play(_damageClip);
    }

    private void OnHealed()
    {
        Play(_healClip);
    }

    private void OnDrunkStarted()
    {
        Play(_drunkClip);
    }

    private void OnSpeedChanged()
    {
        Play(_speedUpClip);
    }

    private void Play(AudioClip clip)
    {
        if (clip != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
