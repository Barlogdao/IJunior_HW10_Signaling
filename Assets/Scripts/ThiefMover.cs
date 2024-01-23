using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThiefMover : MonoBehaviour
{
    private const string Vertical = "Vertical";
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody _rigidbody;
    private float _movementVelocity;
    private Vector3 _rotationVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        UpdateRotation();
        UpdateMovement();
    }

    private void HandleInput()
    {
        _movementVelocity = Input.GetAxis(Vertical) * _moveSpeed;
        _rotationVelocity = new Vector3(0f, Input.GetAxis(Horizontal) * _rotationSpeed, 0f);
    }

    private void UpdateRotation()
    {
        if (_rotationVelocity == Vector3.zero)
            return;

        Quaternion deltaRotation = Quaternion.Euler(_rotationVelocity * Time.fixedDeltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }

    private void UpdateMovement()
    {
        if (_movementVelocity == 0f)
            return;

        _rigidbody.velocity = transform.forward * _moveSpeed * _movementVelocity;
    }
}
