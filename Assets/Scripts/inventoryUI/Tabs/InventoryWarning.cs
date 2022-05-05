using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWarning : MonoBehaviour
{
    public Text playerText;
    private Image background;
    private void Start()
    {
        background = GetComponentInChildren<Image>();
        UIEvents.uIEvents.onInventoryIsFull += OpenTab;
        CloseTab();
    }
    private void CloseTab()
    {
        gameObject.SetActive(false);
    }
    public void OpenTab(string player)
    {
        playerText.text = player;
        gameObject.SetActive(true);
        StartCoroutine(HandleWarningFade());
    }
    IEnumerator HandleWarningFade() {
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            background.color = new Color(1,1,1,alpha);
            yield return new WaitForSeconds(0.3f);
        }
        CloseTab();
    }
}
