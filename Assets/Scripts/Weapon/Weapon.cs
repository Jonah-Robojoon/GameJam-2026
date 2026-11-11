using UnityEngine;

public abstract class Weapon
{
    protected float range;
    protected float angle;
    public float cooldown;

    public UnitTag unitType;

    public float currentCooldown;

    public abstract void Shoot(Vector3 StartPos, Unit target, Transform upAngleCheck);

    protected abstract void Hit(Unit unit);

    public void Init(float range, float angle, float cooldown, UnitTag unitType)
    {
        this.range = range;
        this.angle = angle;
        this.cooldown = cooldown;
        this.unitType = unitType;
    }
}
