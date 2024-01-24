using UnityEngine;

public class Signalization : MonoBehaviour
{
    [SerializeField] private AlarmLight _alarmLight;
    [SerializeField] private AlarmSound _alarmSound;

    public void TurnOn()
    {
        _alarmLight.TurnOn();
        _alarmSound.TurnOn();
    }

    public void TurnOff()
    {
        _alarmLight.TurnOff();
        _alarmSound.TurnOff();
    }
}
