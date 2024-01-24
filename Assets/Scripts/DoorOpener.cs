using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorOpener : MonoBehaviour
{
    private const string OpenDoor = "OpenDoor";
    
    private Animator _animator;
    private bool _isOpened = false;

    private void Awake()
    {
       _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isOpened == true)
            return;

        if (other.TryGetComponent(out ThiefMover thief))
        {
            _animator.SetTrigger(OpenDoor);
            _isOpened = true;
        }
    }
}
