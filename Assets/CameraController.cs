using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lookSpeed = 5f;

    private float _yaw = 0f;
    private float _pitch = 0f;

    private void Update()
    {
        // Get input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on input axes and camera's orientation
        Vector3 direction = transform.right * horizontal + transform.forward * vertical;

        // Move camera
        transform.position += direction * _speed * Time.deltaTime;

        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculate new yaw and pitch angles based on mouse movement
        _yaw += mouseX * _lookSpeed;
        _pitch -= mouseY * _lookSpeed;

        // Limit pitch angle to prevent camera from flipping upside down
        _pitch = Mathf.Clamp(_pitch, -90f, 90f);

        // Rotate camera based on new yaw and pitch angles
        transform.rotation = Quaternion.Euler(_pitch, _yaw, 0f);
    }
}