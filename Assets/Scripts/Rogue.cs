
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 6f;
    [SerializeField] private float _rotationAngle = 180f;

    private float _currentSpeed;
    private bool _isFacingRight = true;

    private void Start()
    {
        _currentSpeed = _walkSpeed;
    }

    private void Update()
    {
        Move();
    }

    public void ChangeDirection()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, _rotationAngle, 0);
        _currentSpeed = _runSpeed;
    }

    public void ToggleMovement()
    {
        _currentSpeed = Mathf.Approximately(_currentSpeed, 0f) ? (_isFacingRight ? _walkSpeed : _runSpeed) : 0f;
    }

    private void Move()
    {
        transform.Translate(_currentSpeed * Time.deltaTime, 0, 0);
    }
}
