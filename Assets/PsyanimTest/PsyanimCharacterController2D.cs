using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyanimCharacterController2D : MonoBehaviour
{
    // from: https://www.youtube.com/watch?v=TfjL56tDAOc
    public float speed = 5.0f;

    public float rotationSpeed = 720.0f;

    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothedMovementInput;
    private Vector2 _movementInputSmoothVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        _movementInput = new Vector2(horizontalInput, verticalInput);
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateInDirectionOfInput();
    }

    private void SetPlayerVelocity()
    {
        _smoothedMovementInput = Vector2.SmoothDamp(
                    _smoothedMovementInput,
                    _movementInput,
                    ref _movementInputSmoothVelocity,
                    0.1f);

        _rigidbody.velocity = _smoothedMovementInput * speed;
    }

    private void RotateInDirectionOfInput()
    {
        if (_movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _smoothedMovementInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            _rigidbody.MoveRotation(rotation);
        }
    }
}
