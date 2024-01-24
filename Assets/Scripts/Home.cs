using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ThiefMover thief))
        {
            _signalization.TurnOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ThiefMover thief))
        {
            _signalization.TurnOff();
        }
    }
}
