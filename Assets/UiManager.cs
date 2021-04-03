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

    public void SetStatus(Status unit)
    {

        //Define nome e level
        nameText.text = unit.name;
        levelText.text = "lv:" + unit.level;


        //Defeine os resursos
        HealthPoints.maxValue = unit.maxHP;
        HealthPoints.value = unit.currentHP;

        ShieldPoints.maxValue = unit.maxShield;
        ShieldPoints.value = unit.currentShield;

        ArmorPoints.maxValue = unit.maxArmor;
        ArmorPoints.value = unit.currentArmor;

        ManaPoints.maxValue = unit.maxMP;
        ManaPoints.value = unit.currentMP;

    }
}
