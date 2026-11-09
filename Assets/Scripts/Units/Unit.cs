using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Main")]
    public float MaxHealth;
    public UnitTag Tags;
    protected float currentHealth;
    [Header("Agression")]
    public float AgressionRange;
    public void Awake()
    {
        OnSpawn();
    }
    protected virtual void OnSpawn()
    {

    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public bool HasTag(UnitTag tags)
    {
        return (Tags & tags) != 0;
    }
}

[Flags]
public enum UnitTag
{
    none = 0,
    Tower = 1 << 0,
    Enemy = 1 << 1,
    Projectile = 1 << 2,
}