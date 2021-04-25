using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;

    public Slider HealthPoints;
    public Slider ShieldPoints;
    public Slider ArmorPoints;
    public Slider ManaPoints;

    public TMP_Text healthResource;
    public TMP_Text manaResource;

    public void SetStatus(Status unit)
    {

        //Define nome e level
        nameText.text = unit.unitName;
        levelText.text = "lv:" + unit.level;


        //Define os resursos
        HealthPoints.maxValue = unit.maxHP;
        HealthPoints.value = unit.currentHP;

        ShieldPoints.maxValue = unit.maxShield;
        ShieldPoints.value = unit.currentShield;

        ArmorPoints.maxValue = unit.maxArmor;
        ArmorPoints.value = unit.currentArmor;

        ManaPoints.maxValue = unit.maxMP;
        ManaPoints.value = unit.currentMP;

        //Define o texto de HP e mana
        healthResource.text = unit.currentHP + ":" + unit.maxHP + "+" + unit.currentShield;
        manaResource.text = unit.currentMP + ":" + unit.maxMP;
        
    }
    
    public void StatusUpdate(Status unit)
    {
        HealthPoints.value = unit.currentHP;
        ShieldPoints.value = unit.currentShield;
        ArmorPoints.value = unit.currentArmor;

        healthResource.text = unit.currentHP + ":" + unit.maxHP + unit.shieldText;
        manaResource.text = unit.currentMP + ":" + unit.maxMP;
    }
}
