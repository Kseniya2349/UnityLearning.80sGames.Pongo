using UnityEngine;
using UnityEngine.InputSystem;

public class MouseFollower : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isRight;

    private PlayerInputActions _playerInputActions;
    private Camera _mainCamera;

    private Vector2 bottomLeft;
    private Vector2 topRight;

    private float halfWidth;
    
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _mainCamera = Camera.main; // Cache the main camera for performance
        
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        halfWidth = transform.localScale.y / 2;
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
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, _mainCamera.nearClipPlane));
        mouseWorldPosition.z = transform.position.z; // Keep the object at its original Z-depth
        mouseWorldPosition.x = transform.position.x;

        if (mouseWorldPosition.y < bottomLeft.y)
        {
            mouseWorldPosition.y = isRight ? topRight.y - halfWidth : bottomLeft.y + halfWidth;
        }
        else if(mouseWorldPosition.y > topRight.y)
        {
            mouseWorldPosition.y = isRight ? bottomLeft.y + halfWidth : topRight.y - halfWidth;
        }
        else
        {
            mouseWorldPosition.y = isRight ? -mouseWorldPosition.y : mouseWorldPosition.y;
        }
        
        // Move the object towards the mouse position
        transform.position = Vector2.Lerp(transform.position, mouseWorldPosition, moveSpeed * Time.deltaTime);
    }
}