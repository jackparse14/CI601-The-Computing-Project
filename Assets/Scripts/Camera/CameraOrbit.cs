using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    [SerializeField] private Transform player;
    private bool hasRotationFinished = true;
    private float minRotSpeed = -0.5f;
    private float maxRotSpeed = 0.5f;
    private Vector2 previousMousePos;

    void LateUpdate()
    {
        transform.position = player.position;
    }
    public void StartCameraRotation(PlayerInputActions pia)
    {
        hasRotationFinished = false;
        previousMousePos = pia.Mouse.MousePos.ReadValue<Vector2>();
        StartCoroutine(CameraRotationUpdate(pia));
    }
    public void EndCameraRotation()
    {
        hasRotationFinished = true;
    }
    private IEnumerator CameraRotationUpdate(PlayerInputActions pia)
    {
        // Creates a mini update function loop
        while (hasRotationFinished == false)
        {
            Vector2 rotationDirection = previousMousePos - pia.Mouse.MousePos.ReadValue<Vector2>();
            float clampedX = Mathf.Clamp(-rotationDirection.x * 0.001f,minRotSpeed,maxRotSpeed);
            transform.Rotate(new Vector3(0, 1, 0), clampedX);
            yield return null;
        }
    }
}
