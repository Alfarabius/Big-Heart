using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] private float currentValue = 0f;
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private Slider progressBar;

    [SerializeField] private UnityEvent progressIsComplete;

    private void Awake()
    {
        progressBar = GetComponent<Slider>();
        progressBar.maxValue = maxValue;
        progressBar.value = currentValue;
        progressBar.wholeNumbers = false;
    }

    public void FillProgress(float amount, bool isIncrease)
    {
        if (isIncrease)
        {
            progressBar.value += amount;
            if (progressBar.value >= maxValue)
            {
                progressIsComplete.Invoke();
            }
        }
        else
        {
            progressBar.value -= amount;
            if (progressBar.value <= 0)
            {
                progressBar.value = 0;
            }
        }
    }
}
