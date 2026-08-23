using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _filling;

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
        float valueAsPercent = value / maxValue;
        _filling.fillAmount = valueAsPercent;
    }

    public void Construct(IValueChanger changer)
    {
        _changer = changer;
    }
}
