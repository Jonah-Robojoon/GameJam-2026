using UnityEngine;

public class Entity : Unit
{
    public Rigidbody2D Rb;

    public override void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        Rb.AddForce(new Vector2(Random.Range(0f, -1f), Random.Range(-1f, 1f)) * 1f, ForceMode2D.Impulse);
    }
}
