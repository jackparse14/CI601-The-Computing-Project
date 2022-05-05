using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationImageSpawner : MonoBehaviour
{
    private RaycastHit currRaycastHit;
    public GameObject destinationImage;
    private GameObject cloneImage;
    public void HandleDestinationImage(RaycastHit rh)
    {
        currRaycastHit = rh;
        if (cloneImage != null)
        {
            DestroyImage();
            SpawnDestinationImage();
        }
        else
        {
            SpawnDestinationImage();
        }
    }
    private void SpawnDestinationImage()
    {
        Vector3 destinationImagePos = new Vector3(currRaycastHit.point.x, currRaycastHit.point.y + 0.1f, currRaycastHit.point.z);
        cloneImage = Instantiate(destinationImage, destinationImagePos, Quaternion.Euler(90f, 0, 0));
    }

    public void DestroyImage()
    {
        Destroy(cloneImage);
    }
}
