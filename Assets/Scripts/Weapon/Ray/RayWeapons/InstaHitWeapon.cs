using UnityEngine;

public class InstaHitWeapon : RayWeapon
{
    protected override void Hit(Unit unit)
    {
        unit.transform.position += new Vector3(0, 0.5f, 0);
    }
}
