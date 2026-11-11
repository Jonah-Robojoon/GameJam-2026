using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class RayWeapon : Weapon
{
    protected int damage = 1;
    public override void Shoot(Vector3 StartPos, Unit target, Transform upAngleCheck)
    {
        target.TakeDamage(damage);

        // currently not used because of otherwise bouble checking enemy

        //UnitManager unitManager = UnitManager.Instance;

        //for (int i = 0; i < unitManager.Units.Count; i++)
        //{
        //    Unit currentUnit = unitManager.Units[i];
        //    if (currentUnit.HasTag(this.unitType) == false) return;
        //    if (CheckInRange(currentUnit, upAngleCheck))
        //    {
        //        Debug.Log("Hit with dammage given:" + damage);
        //        Debug.DrawLine(StartPos, currentUnit.transform.position, Color.red, 1f);
        //        currentUnit.TakeDamage(damage);
        //    }
        //}
    }

    public bool CheckInRange(Unit targetUnit, Transform upAngleCheck, UnitTag aggressionTags)
    {
        if (!targetUnit.HasTag(this.unitType))
            return false;

        Vector3 dir = targetUnit.transform.position - upAngleCheck.transform.position;
        if (dir.magnitude > range)
            return false;

        dir.Normalize();
        float dot = upAngleCheck.up.x * dir.x + upAngleCheck.up.y * dir.y;
        if (dot + 1 <= angle)
            return false;
        return true;
    }
}
