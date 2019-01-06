using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humanoid : MonoBehaviour {

    public int health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        isDead();
	}

    private void isDead() {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getHealth() {

        return health;
    }

    public void setHealth(int newHealth)
    {
       health = newHealth;
    }

    public void increaseHealth(int addHealth)
    {
        health += addHealth;
    }

    public void decreaseHealth(int subHealth)
    {
        health -= subHealth;
    }
}
