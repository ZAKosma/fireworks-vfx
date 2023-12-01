using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

public class FollowMouse : MonoBehaviour
{
    private VisualEffect visualEffect;
    private Camera mainCamera;
    private Vector3 previousPosition;
    private Vector3 currentDirection;

    public float strength = 2;
    public float smoothingFactor = 0.1f;  // Between 0 and 1. Higher value results in quicker changes.

    void Start()
    {
        mainCamera = Camera.main;
        visualEffect = GetComponent<VisualEffect>();
        previousPosition = GetMouseWorldPosition();

        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();

        // Calculate the new direction based on the mouse's current and previous positions
        Vector3 newDirection = mouseWorldPosition - previousPosition;

        // Smooth out the direction vector
        currentDirection = Vector3.Lerp(currentDirection, newDirection, smoothingFactor);

        // Set the spawn position and initial velocity parameters in the Visual Effect
        visualEffect.SetVector3("Spawn Position", mouseWorldPosition);
        visualEffect.SetVector3("Initial Velocity", currentDirection * strength);

        // Update the previous mouse position
        previousPosition = mouseWorldPosition;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = -mainCamera.transform.position.z;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        return mouseWorldPosition;
    }
}