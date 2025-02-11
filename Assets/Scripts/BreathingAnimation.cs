using UnityEngine;

public class BreathingAnimation : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.1f;
    [SerializeField] private float speed = 1.0f;
    
    private Vector3 _initialScale;
    private float _timeCounter;
    
    private void Start()
    {
        _initialScale = transform.localScale;
    }

    private void Update()
    {
        _timeCounter += Time.deltaTime;
        
        float scaleChange = Mathf.Sin(_timeCounter * speed) * amplitude;
        transform.localScale = _initialScale + new Vector3(scaleChange, scaleChange, scaleChange);
    }
}
