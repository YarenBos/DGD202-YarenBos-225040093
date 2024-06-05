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

    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);
        sr = GetComponent<SpriteRenderer>(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.6f);
        StartCoroutine(ResetAfterDelay());

        if(currentHealth <=0)
        {
            gameObject.SetActive(false);
        }

    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(1);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);

    }


}
