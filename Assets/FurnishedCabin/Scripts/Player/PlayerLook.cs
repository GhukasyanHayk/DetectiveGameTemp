using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerBody;

    [Header("Sensitivity")]
    [SerializeField] private float mouseSensitivity = 200f;

    [Header("Smoothing")]
    [SerializeField] private float smoothTime = 0.05f;

    private float xRotation;

    private float currentMouseX;
    private float currentMouseY;

    private float mouseXVelocity;
    private float mouseYVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!VoiceSystem.Instance.IsPaused)
        {
            Look();
        }
    }

    private void Look()
    {
        float targetMouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float targetMouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Плавное сглаживание через SmoothDamp (ощущается лучше чем Lerp)
        currentMouseX = Mathf.SmoothDamp(currentMouseX, targetMouseX, ref mouseXVelocity, smoothTime);
        currentMouseY = Mathf.SmoothDamp(currentMouseY, targetMouseY, ref mouseYVelocity, smoothTime);

        // Вертикальный поворот
        xRotation -= currentMouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Горизонтальный поворот
        playerBody.Rotate(Vector3.up * currentMouseX);
    }
}