using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public int damageAmount;

    public static PlayerHealth instance;
    public HealthBar healthBar;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <=0)
        {
            gameObject.SetActive(false);
        }

    }
}
