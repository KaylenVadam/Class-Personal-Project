using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerHealth : MonoBehaviour
{
    public Image healthbar;
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.fillAmount = currentHealth / 200f;

        //play hurt animation
        //animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("player died!");
        SceneManager.LoadScene("SampleScene");

        //die animation
        //animator.SetBool("isDead, true");

        //disable the enemy
        //turn off enemy ai and gravity
        
    }

    public void Heal()
    {
        int healingAmount = 200;
        currentHealth = healingAmount;
        healingAmount = Mathf.Clamp(healingAmount, 0, 200);
    
        healthbar.fillAmount = currentHealth / 200;
    }
}
