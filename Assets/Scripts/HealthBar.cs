using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    private float _forceSetHealthValue = 0.64f;
    private Coroutine _setHealthValue;

    private void Awake()
    {
        ShowHealthValue();
    }

    public void ShowHealthValue()
    {
        if (_setHealthValue != null)
        {
            StopCoroutine(_setHealthValue);
        }

        _setHealthValue = StartCoroutine(SetTargetValueHealth(_health.CurrentHealth));
    }

    private IEnumerator SetTargetValueHealth(float targetValue)
    {
        while (_healthBar.value != targetValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, _forceSetHealthValue);
            yield return null;
        }
    }
}