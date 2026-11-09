using UnityEngine;
using UnityEngine.UIElements;

public abstract class RayWeapon : Weapon
{
    private Unit checkUnit;
    public override void Shoot(Vector3 StartPos, Transform upAngleCheck)
    {
        if (CheckInRange(checkUnit, upAngleCheck))
        {
            Hit(checkUnit);
        }
    }

    public bool CheckInRange(Unit targetUnit, Transform upAngleCheck)
    {
        Vector3 dir = targetUnit.transform.position - upAngleCheck.transform.position;
        if (dir.magnitude > range)
            return false;

        dir.Normalize();
        float dot = upAngleCheck.up.x * dir.x + upAngleCheck.up.y * dir.y;
        if (dot + 1 <= angle)
            return false;
        return true;
    }

    public void SetCheckUnit(Unit unit)
    {
        checkUnit = unit;
    }
}
