using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSound : MonoBehaviour
{
    [SerializeField] private float _VolumeRate;

    private AudioSource _audiosource;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private bool _isWorking = false;

    private void Awake()
    {
        _audiosource = GetComponent<AudioSource>();
        _audiosource.volume = _minVolume;
    }

    private void Update()
    {
        float targetSoundVolume = _isWorking == true ? _maxVolume : _minVolume;

        _audiosource.volume = Mathf.MoveTowards(_audiosource.volume, targetSoundVolume, _VolumeRate * Time.deltaTime);
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
