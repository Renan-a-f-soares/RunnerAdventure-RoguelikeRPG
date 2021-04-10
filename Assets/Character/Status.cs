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
    public int strengt;
    public int dexterity;
    public int constitution;
    public int inteligence;
    public int experience;
    public int magic;

    //modificadores

    public float strengtMod;
    public float dexteritymod;
    public float constitutionMod;
    public float inteligenceMod;
    public float experienceMod;
    public float magicMod;


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
    public int weaponAttack = 20;
    public int armorDefense;


    //calculo de dano basico de ataque

    public float damage;

    //Controladores
    public int hitChance;
    public int hit;
    public int armorQuality = 26;

    public float UpdateDamage()
    {
        strengtMod = strengt/50;
        experienceMod = experience / 50;
        magicMod = magic * (magic / 50);

        damage = (weaponAttack*(1+strengtMod))+(magicMod*(1+experienceMod));
        
        return damage;
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
