using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay;
    [SerializeField] private float _stepValue;

    private Coroutine _coroutine;
    private bool _isCourutineWork;
    private int _currentCount;

    public void OnMouseDown()
    {
        if (_isCourutineWork)
        {
            _isCourutineWork = false;
            StopCoroutine(_coroutine);
        }
        else
        {
            Restart();
        }
    }

    private void Start()
    {
        _text.text = "";
        _currentCount = 0;
        Restart();
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(Countdown(_delay));
        _isCourutineWork = true;
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            DisplayCountdown(_currentCount);
            _currentCount++;
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }
}
