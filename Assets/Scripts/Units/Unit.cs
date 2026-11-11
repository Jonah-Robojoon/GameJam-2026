using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("Main")]
    public float MaxHealth;
    public UnitTag Tags;
    protected float currentHealth;
    [Header("Agression")]
    public float AggressionRange;
    [Range(0, 2)] public float AggressionCosCutoff;
    public UnitTag AggressionTags;
    public void Awake()
    {
        OnSpawn();
    }
    protected virtual void OnSpawn()
    {
        Debug.Log("Unit spawned");
        UnitManager.Instance.Units.Add(this);
        currentHealth = MaxHealth;
    }
    public bool CheckAggression(Unit targetUnit, Transform upAngleCheck)
    {
        if (targetUnit.HasTag(AggressionTags) == false)
            return false;
        Vector3 dir = targetUnit.transform.position - upAngleCheck.transform.position;
        if (dir.magnitude > AggressionRange)
            return false;


        dir.Normalize();
        float dot = upAngleCheck.up.x * dir.x + upAngleCheck.up.y * dir.y;
        if (dot + 1 <= AggressionCosCutoff)
            return false;
        return true;
    }
    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        UnitManager.Instance.Units.Remove(this);
        Destroy(gameObject);
    }
    public bool HasTag(UnitTag tags)
    {
        if (Tags == default) return true;
        if (tags == default) return true;

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