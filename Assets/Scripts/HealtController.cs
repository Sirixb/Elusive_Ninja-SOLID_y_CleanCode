using System;
using Unity.Mathematics;
using UnityEngine;

public class HealtController : MonoBehaviour ,IHealReceiver, IDamageReceiver
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerHud _playerHud;
    [SerializeField] private int _initialHealth = 100;

    private int _currentHealth;

    // Other components (sound, effects...) can react to these without this class knowing about them
    public event Action Damaged;
    public event Action Healed;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        _currentHealth = _initialHealth;
        _playerHud.SetHealth(_currentHealth.ToString());
    }

    public void ReceiveDamage(int damage)
    {
        _currentHealth -= damage;
        _playerHud.SetHealth(_currentHealth.ToString());
        Damaged?.Invoke();

        if (_currentHealth <= 0)
        {
            /* Is not a good idea to use singletons patter to do that because this makes it difficult to test,
             but for the purpose of this course will be enough. In future courses we will see how to improve it using MVVM pattern */
            GameEventListener.Instance.OnPlayerDeath();
            _animator.SetBool("IsDeath", true);
        }
    }

    public void Heal(int quantityToHeal)
    {
        _currentHealth = math.min(_currentHealth + quantityToHeal, _initialHealth);
        _playerHud.SetHealth(_currentHealth.ToString());
        Healed?.Invoke();
    }

}
