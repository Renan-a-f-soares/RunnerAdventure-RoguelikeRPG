using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{

    
    //Variaveis para os Status
    //Miscelanias
    public string unitName;
    public int level;
    public float currentXP;
    public float nextLevelXP;
    public int improvementPoints;

    //Status
    public int strength;
    public int dexterity;
    public int constitution;
    public int inteligence;
    public int experience;
    public int magic;

    //modificadores

    public float strengthMod;
    public float dexterityMod;
    public float constitutionMod;
    public float inteligenceMod;
    public float experienceMod;
    public float magicMod;

    //pesos para modificador
    float v1 = 1;
    float v2 = 2;
    float v10 = 10;
    float v50 = 50;
    float v100 = 100;
    float vChange;

    //Recursos
    public float currentHP;
    public float maxHP;

    public float currentMP;
    public float maxMP;

    public string shieldText;
    public float currentShield;
    public float maxShield;

    public int currentArmor;
    public int maxArmor;

    //equipamentos
    public float weaponAttack;
    public int armorDefense;


    //calculo de dano basico de ataque

    public float damage;
    public float physicalDamage;
    public float magicalDamage;


    //Controladores
    public int hitChance;
    public int hit;
    public int armorQuality = 26;
    public float physical;
    public float magical;

    public float UpdateDamage()
    {
        
        

        physicalDamage = UpPhysical(v10, v100);
        magicalDamage = UpMagical(v2, v50, v10, v100);
        Debug.Log("Fisico: " + physicalDamage);
        Debug.Log("Magico:" + magicalDamage);
        damage = physicalDamage + magicalDamage;
        
        return damage;
    }

    public float UpPhysical(float str, float dex)
    {
        experienceMod = experience / v50;
        dexterityMod = dexterity / dex;
        strengthMod = strength / str;
        physical = (weaponAttack * (v1 + ((strengthMod+dexterityMod)*(v1+experienceMod)))) + (strength*dexterityMod);
        return physical;
    }
    public float UpMagical(float mag, float exp, float intl, float dex)
    {
        experienceMod = experience / exp;
        magicMod = magic * (magic / mag);
        inteligenceMod = inteligence / intl;
        dexterityMod = dexterity / dex;

        magical = (magicMod * (v1 + experienceMod)) + (inteligenceMod*(v1+dexterityMod));
        return magical;
    }

    public void TakeDamage(float hurtDamage)
    {
        
        //armadura
        if (currentArmor > 0)
        {
            hitChance = Random.Range(1, 101);
            if (hitChance < armorQuality)
            {
                hurtDamage = 0;
                hit = 0;
            }
            else
            {
                hit = 1;
            }
            
            currentArmor -= 1;
        }
        //escudo magico
        if (currentShield != 0)
        {
            if (currentShield > hurtDamage)
            {
                currentShield -= hurtDamage;
                hurtDamage = 0;
                shieldText = "+" + currentShield;
            }
            else
            {
                hurtDamage = hurtDamage - currentShield;
                currentShield = 0;
                shieldText = "";


            }
        }
        currentHP -= hurtDamage;
        
 
    }
}
