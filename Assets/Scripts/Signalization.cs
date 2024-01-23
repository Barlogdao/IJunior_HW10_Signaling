using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private Light _alarmLight;
    [SerializeField] private float _maxLightIntensity = 7;

    private void Awake()
    {
        _alarmLight.intensity = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ThiefMover thief))
        {
            _alarmLight.intensity = _maxLightIntensity;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ThiefMover thief))
        {
            _alarmLight.intensity = 0f;
        }
    }
}
