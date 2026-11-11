using UnityEngine;

public class TestRayWeapon : MonoBehaviour
{
    InstaHitWeapon instaHitWeapon = new InstaHitWeapon();
    public Unit target;
    public float angle = 2;

    private void Update()
    {
        if (transform != null && instaHitWeapon.currentCooldown <= 0)
        {
            instaHitWeapon.currentCooldown = instaHitWeapon.cooldown;
            instaHitWeapon.Init(10, angle, 1, UnitTag.Enemy);
            //instaHitWeapon.Shoot(transform.position, transform);
        }

        if (instaHitWeapon.currentCooldown > 0)
        {
            instaHitWeapon.currentCooldown -= Time.deltaTime;
        }
    }
}
