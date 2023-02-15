using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    private float _forceSetHealthValue = 50f;
    private Coroutine _setHealthValue;

    private void Awake()
    {
        _health.Revised += ShowHealthValue;
    }

    public void ShowHealthValue(float targetHealth)
    {
        if (_setHealthValue != null)
        {
            StopCoroutine(_setHealthValue);
        }

        _setHealthValue = StartCoroutine(SetTargetValueHealth(targetHealth));
    }

    private IEnumerator SetTargetValueHealth(float targetHealth)
    {
        while (_healthBar.value != targetHealth)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetHealth, _forceSetHealthValue * Time.deltaTime);
            yield return null;
        }
    }
}