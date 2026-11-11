using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TestTower : Building
{
    InstaHitWeapon instaHitWeapon = new InstaHitWeapon();
    public Transform Turret;

    public float RotationSpeed = 5;
    public float Angle = 2;
    public GameObject LinerenederPrefab;

    private void Update()
    {
        instaHitWeapon.Init(10, Angle, 5, UnitTag.Enemy);
        UnitManager unitManager = UnitManager.Instance;

        Unit closestUnit = null;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < unitManager.Units.Count; i++)
        {
            Unit target = unitManager.Units[i];
            if (instaHitWeapon.CheckInRange(target, transform, AggressionTags))
            {
                float currentDistance = Vector3.Distance(transform.position, target.transform.position);
                if (currentDistance < closestDistance)
                {
                    closestDistance = currentDistance;
                    closestUnit = target;
                }
            }
        }

        var dir = closestUnit.transform.position - Turret.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * RotationSpeed);

        if (instaHitWeapon.currentCooldown <= 0)
        {
            Debug.Log("Shooting at: " + closestUnit.name);
            instaHitWeapon.currentCooldown = instaHitWeapon.cooldown;
            instaHitWeapon.Shoot(transform.position, closestUnit, transform);

            GameObject linerendererObject = GameObject.Instantiate(LinerenederPrefab);
            LineRenderer lineRenderer = linerendererObject.GetComponent<LineRenderer>();

            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, closestUnit.transform.position);

            Destroy(linerendererObject, 0.1f);
        }

        //if (transform != null && instaHitWeapon.currentCooldown <= 0)
        //{
        //    instaHitWeapon.currentCooldown = instaHitWeapon.cooldown;
        //    instaHitWeapon.Init(10, Angle, 1, UnitTag.Enemy);
        //    instaHitWeapon.Shoot(transform.position, transform);
        //}

        if (instaHitWeapon.currentCooldown > 0)
        {
            instaHitWeapon.currentCooldown -= Time.deltaTime;
        }
    }
}
