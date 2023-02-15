using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth = 100f;

    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void SetHealthValue(float alterationHealth)
    {
        CurrentHealth = CurrentHealth - alterationHealth;
    }
}