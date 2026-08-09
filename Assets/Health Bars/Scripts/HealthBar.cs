using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _filling;
 
    private void Start()
    {
        _health.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeValue;
    }

    private void ChangeValue()
    {
        float valueAsPercent = _health.Value / _health.MaxValue;
        _filling.fillAmount = valueAsPercent;
    }
}
