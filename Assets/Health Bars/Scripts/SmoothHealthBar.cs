using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Image _filling;
    [SerializeField] private float _speed = 0.5f;

    private IValueChanger _changer;
    private Coroutine _coroutine;

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

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeSmoothly(valueAsPercent));
    }

    private IEnumerator ChangeSmoothly(float targetPercent)
    {
        while (!Mathf.Approximately(_filling.fillAmount, targetPercent))
        {
            _filling.fillAmount = Mathf.MoveTowards(_filling.fillAmount, targetPercent, _speed * Time.deltaTime);
            yield return null;
        }

        _filling.fillAmount = targetPercent;
    }

    public void Construct(IValueChanger changer)
    {
        _changer = changer;
    }
}
