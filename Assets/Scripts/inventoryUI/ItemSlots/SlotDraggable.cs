using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotDraggable : MonoBehaviour
{
    [SerializeField] private Image icon;
    public void SetIcon(Image itemIcon) {
        icon.sprite = itemIcon.sprite;
    }
    public void DestroySelf() {
        Destroy(gameObject);
    }
}
