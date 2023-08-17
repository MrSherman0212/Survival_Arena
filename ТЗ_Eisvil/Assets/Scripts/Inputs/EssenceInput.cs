using UnityEngine;
using UnityEngine.InputSystem;

public class EssenceInput : MonoBehaviour
{
    private Vector2 _movementDirection;
    private PlayerInput _playerInput;
    [SerializeField] private RectTransform _joystickTransform;

    public Vector2 MovementDirection { get { return _movementDirection; } }

    private void Awake() => _playerInput = new PlayerInput();

    private void MoveInput(InputAction.CallbackContext context) => _movementDirection = context.ReadValue<Vector2>();
    private void TouchInput(InputAction.CallbackContext context) => _joystickTransform.position = context.ReadValue<Vector2>();

    private void OnEnable()
    {
        _playerInput.PlayerControlls.Movement.performed += MoveInput;
        _playerInput.PlayerControlls.Movement.canceled += MoveInput;
        _playerInput.PlayerControlls.Touch.started += TouchInput;
        _playerInput.PlayerControlls.Touch.performed += TouchInput;
        _playerInput.PlayerControlls.Touch.canceled += TouchInput;
        _playerInput.PlayerControlls.Enable();
    }

    private void OnDisable()
    {
        _playerInput.PlayerControlls.Movement.performed -= MoveInput;
        _playerInput.PlayerControlls.Movement.canceled -= MoveInput;
        _playerInput.PlayerControlls.Touch.started -= TouchInput;
        _playerInput.PlayerControlls.Touch.performed -= TouchInput;
        _playerInput.PlayerControlls.Touch.canceled -= TouchInput;
        _playerInput.PlayerControlls.Disable();
    }
}
