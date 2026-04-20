using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        HealthItem.OnHealthCollect += Heal;

        GameEvents.HealthChanged(currentHealth);
    }

    private void OnDestroy()
    {
        HealthItem.OnHealthCollect -= Heal;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.collider.name);

        Enemy enemy = collision.collider.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(enemy.damage);
        }
    }

    private void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        GameEvents.HealthChanged(currentHealth);
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        GameEvents.HealthChanged(currentHealth);

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            GameEvents.PlayerDied();
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}