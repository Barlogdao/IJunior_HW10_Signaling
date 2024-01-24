using UnityEngine;

[RequireComponent(typeof(Light))]
public class AlarmLight : MonoBehaviour
{
    [SerializeField] private float _intesityRate;

    private Light _alarmLight;
    private float _minIntensity = 0f;
    private float _maxIntensity = 7;

    private bool _isWorking = false;

    private void Awake()
    {
        _alarmLight = GetComponent<Light>();
        _alarmLight.intensity = _minIntensity;
    }

    private void Update()
    {
        float targetLightIntensity = _isWorking == true ? _maxIntensity : _minIntensity;

        _alarmLight.intensity = Mathf.MoveTowards(_alarmLight.intensity, targetLightIntensity, _intesityRate * Time.deltaTime);
    }

    public void TurnOn()
    {
        _isWorking = true;
    }

    public void TurnOff()
    {
        _isWorking = false;
    }
}
