using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public HealthUI healthUI;

    
    void Start()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy) 
        {
            TakeDamage(enemy.damage);
        }

    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);
        if (currentHealth <= 0) 
        {
            //Player dies 
        }
    }

}
