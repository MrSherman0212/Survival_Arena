using UnityEngine;
using UnityEngine.InputSystem;

public class EssenceInput : MonoBehaviour, IInitializable
{
    private Vector2 _movementDirection;
    [SerializeField] private RectTransform _joystickTransform;
    private PlayerInput _playerInput;

    public Vector2 MovementDirection { get { return _movementDirection; } }

    public void Init()
    {
        _playerInput = new PlayerInput();
        _playerInput.PlayerControlls.Movement.performed += MoveInput;
        _playerInput.PlayerControlls.Movement.canceled += MoveInput;
        _playerInput.PlayerControlls.Touch.started += TouchInput;
        _playerInput.PlayerControlls.Touch.performed += TouchInput;
        _playerInput.PlayerControlls.Touch.canceled += TouchInput;
    }

    private void Update()
    {
        Debug.Log(_movementDirection);
    }

    private void MoveInput(InputAction.CallbackContext context) => _movementDirection = context.ReadValue<Vector2>();
    private void TouchInput(InputAction.CallbackContext context) => _joystickTransform.position = context.ReadValue<Vector2>();

    private void OnEnable()
    {
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
