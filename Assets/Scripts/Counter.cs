using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class Counter : MonoBehaviour
{
    [SerializeField] private CountShower _shower;

    private Button _button;
    private int _count = 0;
    private float _delay = 0.5f;
    private Coroutine _coroutine;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HandlerButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandlerButtonClick);
    }

    public void StopCoroutine()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private void HandlerButtonClick()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(CountWork());
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine();
            }
        }
    }

    private IEnumerator CountWork()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _count++;
            _shower.ChangeCount(_count);
            yield return wait;
        }
    }
}
