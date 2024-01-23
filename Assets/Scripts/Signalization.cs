using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    [SerializeField] private Light _alarmLight;
    [SerializeField] private float _lightIntesityRate;
    [SerializeField] private float _soundVolumeRate;

    private AudioSource _audiosource;
    private float _minSoundVolume = 0f;
    private float _maxSoundVolume = 1f;

    private float _minLightIntensity = 0f;
    private float _maxLightIntensity = 7;

    private bool _isThiefInHouse = false;

    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
        _audiosource.volume = _minSoundVolume;
        _alarmLight.intensity = _minLightIntensity;
    }

    private void Update()
    {
        UpdateAlarmLight();
        UpdateAlarmSound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThiefMover thief))
        {
            _isThiefInHouse = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ThiefMover thief))
        {
            _isThiefInHouse = false;
        }
    }

    private void UpdateAlarmLight()
    {
        float targetLightIntensity = _isThiefInHouse == true ? _maxLightIntensity : _minLightIntensity;

        _alarmLight.intensity = Mathf.MoveTowards(_alarmLight.intensity, targetLightIntensity, _lightIntesityRate * Time.deltaTime);
    }
    private void UpdateAlarmSound()
    {
        float targetSoundVolume = _isThiefInHouse == true ? _maxSoundVolume: _minSoundVolume;

        _audiosource.volume = Mathf.MoveTowards(_audiosource.volume, targetSoundVolume, _soundVolumeRate * Time.deltaTime);
    }
}
