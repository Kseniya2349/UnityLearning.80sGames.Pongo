using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isRight;

    private PlayerInputActions _playerInputActions;
    private Camera _mainCamera;

    private float _halfWidth;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _mainCamera = Camera.main;

        _halfWidth = transform.localScale.y / 2;
    }

    private void OnEnable()
    {
        _playerInputActions.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Disable();
    }

    private void Update()
    {
        // Read the mouse position from the Input Actions asset
        Vector2 mouseScreenPosition = _playerInputActions.Player.MousePosition.ReadValue<Vector2>();

        // Convert screen coordinates to world coordinates
        // For 2D, we typically use the Z value of the object's current position
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x,
            mouseScreenPosition.y, _mainCamera.nearClipPlane));
        mouseWorldPosition.z = transform.position.z; // Keep the object at its original Z-depth
        mouseWorldPosition.x = transform.position.x;

        if (mouseWorldPosition.y < GameManager.Instance.GameField.MinY)
        {
            mouseWorldPosition.y =
                isRight ? GameManager.Instance.GameField.MaxY - _halfWidth : GameManager.Instance.GameField.MinY + _halfWidth;
        }
        else if (mouseWorldPosition.y > GameManager.Instance.GameField.MaxY)
        {
            mouseWorldPosition.y =
                isRight ? GameManager.Instance.GameField.MinY + _halfWidth : GameManager.Instance.GameField.MaxY - _halfWidth;
        }
        else
        {
            mouseWorldPosition.y = isRight ? -mouseWorldPosition.y : mouseWorldPosition.y;
        }

        // Move the object towards the mouse position
        transform.position = Vector2.Lerp(transform.position, mouseWorldPosition, moveSpeed * Time.deltaTime);
    }
}