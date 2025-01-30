using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _countText;
    private float _count;
    private float _delay = 0.5f;
    private Coroutine _coroutine;

    public void StartCoroutine()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(CountWork());
        else
            StopCoroutine();
    }

    public void StopCoroutine()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator CountWork()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _count++;
            _countText.text = _count.ToString();
            yield return wait;
        }
    }
}
