using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int _maxHealth = 100;

    private int _curHealthCache;
    private int _curHealth
    {
        get => _curHealthCache;
        set
        {
            _curHealthCache = Mathf.Clamp(value, 0, _maxHealth);

            // check death
            if (_curHealthCache <= 0)
                Die();
        }
    }

    public event Action OnDeath;

    private void Start()
    {
        _curHealth = _maxHealth;
    }

    public void TakeDamage(int damage) => _curHealth -= damage;

    public void Heal(int amount) => _curHealth += amount;

    void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

}
