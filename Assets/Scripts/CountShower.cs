using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class CountShower : MonoBehaviour
{
    private Text _countText;

    private void Awake()
    {
        _countText = GetComponent<Text>();
    }

    public void ChangeCount(int count)
    {
        _countText.text = count.ToString();
    }
}
