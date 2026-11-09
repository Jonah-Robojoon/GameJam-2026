using UnityEngine;

public class TestTower : Building
{
    public Unit target;
    public Transform Turret;

    public float RotationSpeed = 5;
    private void Update()
    {
        if (CheckAggression(target, transform))
        {
            var dir = target.transform.position - Turret.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * RotationSpeed);
        }
    }
}
