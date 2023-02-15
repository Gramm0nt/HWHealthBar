using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth = 100f;
    private float _damage = 10f;
    private float _heal = 10f;
    private float _currentHealth = 100f;

    public delegate void ReviseHealth(float currentHealth);

    public event ReviseHealth Revised;

    private void Start()
    {
        Revised?.Invoke(_currentHealth);
    }

    public void TakeDamage()
    {
        if (_currentHealth > 0)
        {
            _currentHealth = _currentHealth - _damage;
            Revised?.Invoke(_currentHealth);
        }
    }

    public void TakeHeal()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth = _currentHealth + _heal;
            Revised?.Invoke(_currentHealth);
        }
    }
}