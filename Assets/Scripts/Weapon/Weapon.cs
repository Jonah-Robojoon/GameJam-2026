using UnityEngine;

public abstract class Weapon
{
    protected float range;
    protected float angle;
    protected float cooldown;

    protected UnitTag unitType;

    private float currentCooldown;

    public abstract void Shoot(Vector3 StartPos, Transform upAngleCheck);

    protected abstract void Hit(Unit unit);

    public void Init(float range, float angle, float cooldown, UnitTag unitType)
    {
        this.range = range;
        this.angle = angle;
        this.cooldown = cooldown;
        this.unitType = unitType;
    }

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
}
