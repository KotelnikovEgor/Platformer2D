using TMPro;
using UnityEngine;

public class TextHealth : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = _health.MaxValue.ToString();
        _health.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeValue;
    }

    private void ChangeValue()
    {
        _text.text = $"{_health.Value} / {_health.MaxValue}";
    }
}
