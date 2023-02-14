using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;

    private float _heal = -10f;
    private float _damage = 10f;

    public void OnButtonPlusClick()
    {
        _healthBar.SetHealth(_heal);
    }

    public void OnButtonMinusClick()
    {
        _healthBar.SetHealth(_damage);
    }
}