using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatOutputterTab : MonoBehaviour
{
    [SerializeField] protected Text speedModifierText;
    [SerializeField] protected Text strengthModifierText;
    [SerializeField] protected Text armourModifierText;
    [SerializeField] protected Text intelligenceModifierText;
    [SerializeField] protected Text healthModifierText;
    [SerializeField] protected Text agilityModifierText;
    [SerializeField] protected Text manaModifierText;

    protected AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public virtual void OpenTab()
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
    }
    public virtual void CloseTab()
    {
        if (gameObject.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }
    protected void UpdateText(string speed, string strength, string armour, string intelligence, string health, string agility, string mana) {
        speedModifierText.text = speed;
        strengthModifierText.text = strength;
        armourModifierText.text = armour;
        intelligenceModifierText.text = intelligence;
        healthModifierText.text = health;
        agilityModifierText.text = agility;
        manaModifierText.text = mana;
    }
    public void OnRemoveButton()
    {
        audioManager.PlaySound("Remove");
        CloseTab();
    }
}
