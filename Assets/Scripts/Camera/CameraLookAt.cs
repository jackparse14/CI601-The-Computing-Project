using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.LookAt(transform.parent);
    }

    public void OnDisable()
    {
        this.enabled = false;
    }
}