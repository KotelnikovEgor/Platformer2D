using TMPro;
using UnityEngine;

public class TextHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private IValueChanger _changer;

    private void Start()
    {
        _changer.Changed += ChangeValue;
    }

    private void OnDisable()
    {
        _changer.Changed -= ChangeValue;
    }

    private void ChangeValue(float value, float maxValue)
    {
        _text.text = $"{value} / {maxValue}";
    }

    public void Construct(IValueChanger changer)
    {
        _changer = changer;
    }
}
