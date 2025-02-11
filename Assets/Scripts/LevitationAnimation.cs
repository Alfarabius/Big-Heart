using UnityEngine;

public class LevitationAnimation : MonoBehaviour
{
    [SerializeField] private float amplitudeX = 0.5f;
    [SerializeField] private float amplitudeY = 0.5f;
    [SerializeField] private float speedX = 0.5f;
    [SerializeField] private float speedY = 0.5f;

    private Vector3 _initialPosition;
    private float _timeCounterX;
    private float _timeCounterY;

    private void Start()
    {
        _initialPosition = transform.position;
        _timeCounterX = Random.Range(0f, 100f);
        _timeCounterY = Random.Range(0f, 100f);
    }

    private void Update()
    {
        _timeCounterX += Time.deltaTime * speedX;
        _timeCounterY += Time.deltaTime * speedY;

        float offsetX = Mathf.PerlinNoise(_timeCounterX, 0) * 2 - 1;
        float offsetY = Mathf.PerlinNoise(0, _timeCounterY) * 2 - 1;

        transform.position = _initialPosition + new Vector3(offsetX * amplitudeX, offsetY * amplitudeY, 0);
    }
}

