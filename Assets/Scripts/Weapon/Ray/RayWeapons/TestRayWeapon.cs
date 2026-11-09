using UnityEngine;

public class TestRayWeapon : MonoBehaviour
{
    InstaHitWeapon instaHitWeapon = new InstaHitWeapon();
    public Unit target;
    public float angle = 2;

    private void Start()
    {
        instaHitWeapon.SetCheckUnit(target);
    }
    private void Update()
    {
        if (transform != null)
        {
            instaHitWeapon.Init(10, angle, 1, UnitTag.Enemy);
            instaHitWeapon.Shoot(transform.position, transform);
        }
    }
}
