using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IInitializable, IMovable
{
    [SerializeField] private float _movementSpeed = 1;
    private Vector2 _movementDirection;
    [SerializeField] private RectTransform _joystickTransform;
    private MeleeWeapon _meleeWeapon;
    private HealthSystem _healthSystem;

    private Rigidbody2D _rigidbody2D;
    private PlayerInput _inputActions;
    private ShootingWeapon _gun;

    public Vector2 MoveDirection { get { return _movementDirection; } }

    public void Initialize()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputActions = new PlayerInput();
        _meleeWeapon = GetComponentInChildren<MeleeWeapon>();
        _meleeWeapon?.Initialize();
        _healthSystem = GetComponent<HealthSystem>();
        _healthSystem?.Initialize();
        _gun = GetComponentInChildren<ShootingWeapon>();
        _gun?.Initialize();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _rigidbody2D.velocity = _movementDirection * _movementSpeed;
    }

    private void MoveInput(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector2>();
        if (_movementDirection.x != 0 || _movementDirection.y != 0)
        {
            _gun.SetDirection(_movementDirection);
        }
    }

    private void TouchInput(InputAction.CallbackContext context) => _joystickTransform.position = context.ReadValue<Vector2>();

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.PlayerControlls.Movement.performed += ctx => MoveInput(ctx);
        _inputActions.PlayerControlls.Movement.canceled += ctx => MoveInput(ctx);
        _inputActions.PlayerControlls.Touch.performed += ctx => TouchInput(ctx);
        _inputActions.PlayerControlls.Touch.canceled += ctx => TouchInput(ctx);
    }

    private void OnDisable()
    {
        _inputActions.PlayerControlls.Movement.performed -= ctx => MoveInput(ctx);
        _inputActions.PlayerControlls.Movement.canceled -= ctx => MoveInput(ctx);
        _inputActions.PlayerControlls.Touch.performed -= ctx => TouchInput(ctx);
        _inputActions.PlayerControlls.Touch.canceled -= ctx => TouchInput(ctx);
        _inputActions.Disable();
    }
}
