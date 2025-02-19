using UnityEngine;

public class ProgressEffect : MonoBehaviour, IEffect
{
    [SerializeField] private Progress targetProgress;
    [SerializeField] private float baseValue;
    [SerializeField] private float timeInterval;
    [SerializeField] public float currentValue;
    [SerializeField] private bool isIncrease;

    private float _currentBuffValue = 1f;

    public float GetTimeInterval() => timeInterval;

    private void Awake()
    {
        currentValue = baseValue;
        _currentBuffValue = 1f;
    }

    public void ApplyBuff(float buffValue)
    {
        currentValue = buffValue * _currentBuffValue;
    }

    public void ApplyEffect()
    {
        targetProgress.FillProgress(currentValue * _currentBuffValue, isIncrease);
    }
}
