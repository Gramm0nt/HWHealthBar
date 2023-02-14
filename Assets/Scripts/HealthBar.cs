using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private float _forceSetHealthValue = 0.05f;
    private float _targetValue;
    private Coroutine _setHealthValue;

    public void SetHealth(float health)
    {
        _targetValue = _healthBar.value - health;

        if (_setHealthValue != null)
        {
            StopCoroutine(_setHealthValue);
        }

        _setHealthValue = StartCoroutine(SetTargetValueHealth());
    }

    private IEnumerator SetTargetValueHealth()
    {
        while (_healthBar.value != _targetValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue, _forceSetHealthValue);
            yield return null;
        }
    }
}