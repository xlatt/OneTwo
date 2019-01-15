using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {

    [SerializeField]
    private string unitName = "undefinedName";

    [SerializeField]
    private int maxHealth = 1;
    [SerializeField]
    private int maxShield = 1;

    [HideInInspector]
    private int health;
    [HideInInspector]
    private int shield;
    [HideInInspector]
    private int armor;
    [HideInInspector]
    private int walkingSpeed;
    [HideInInspector]
    private int agility;
    [HideInInspector]
    private int atkDmg;
    
    [SerializeField]
    private GameObject unit;
    
    // Use this for initialization
    void Start () {

    health = maxHealth;
    shield = maxShield;
    unitName = unit.GetComponent<Transform>().name;
    armor = 0;
    walkingSpeed = 0;
    agility = 0;
    atkDmg = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (health.Equals(0))
            Destroy(unit);
    }

    //------------------GET------------------//
    public int getMaxHealth()  {
        return maxHealth;
    }
    public int getMaxShield() {
        return maxShield;
    }
    public int getHealth() {
        return health;
    }
    public int getShield () {
        return shield;
    }
    public int getArmor() {
        return armor;
    }
    public int getWalkingSpeed() {
        return walkingSpeed;
    }
    public int getAgility() {
        return agility;
    }
    public int getAtkDmg() {
        return atkDmg;
    }
    public string getUnitName() {
        return unitName;
    }
    //------------------SET------------------//
    public void setHealth(int newHealth) {
        if (newHealth <= 0) {
            health = 0;
            Destroy(unit);
        }
        else {
            health = newHealth;
        }
        
    }
    public void setShield(int newShield) {
        if (newShield <= 0) {
            shield = 0;
        }
        else {
            shield = newShield;
        }
           
    }
    public void setArmor(int newArmor) {
        if (newArmor < 0) {
            armor = 0;
        }
        else {
            armor = newArmor;
        }
    }
    public void setWalkingSpeed(int newWalkingSpeed) {
        if (walkingSpeed < 0) {
            walkingSpeed = 0;
        }
        else {
            walkingSpeed = newWalkingSpeed;
        }
    }
    public void setAgility(int newAgility) {
        if (newAgility < 0) {
            agility = 0;
        }
        else {
            agility = newAgility;
        }
           
    }
    public void setAtkDmg(int newAtkDmg) {
        if (newAtkDmg < 0) {
            atkDmg = 0;
        }
        else {
            atkDmg = newAtkDmg;
        }
    }
    public void setUnitName(string newUnitName) {
            unitName = newUnitName;
    }

    //------------------Action------------------//
    public void UnitKilled() {
        //animationTime
        //MusicTime
        Destroy(unit);
    }

    public void UnitWalking()
    {
        //animationTime
        //MusicTime
    }

    public void UnitIdle()
    {
        //animationTime
    }

    public void UnitClicked()
    {
        //animationTime
        //MusicTime
    }

    public void UnitAction()
    {
        //animationTime
        //MusicTime
    }

    public void UnitGotHit(int dealtDmg)
    {
        setHealth(getHealth()-dealtDmg); 
        //MusicTime
    }


}
