using UnityEngine;

public class TestEnemy : Entity
{
    private UnitManager unitManager;
    private Unit target;
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        unitManager = UnitManager.Instance;
    }
    private void Update()
    {
        //Unit closestUnit = null;
        //float closestDistance = float.MaxValue;
        //for (int i = 0; i < unitManager.Units.Count; i++)
        //{
        //    Unit target = unitManager.Units[i];
        //    if (CheckAggression(target, transform))
        //    {
        //        float currentDistance = Vector3.Distance(transform.position, target.transform.position);
        //        if (currentDistance < closestDistance)
        //        {
        //            closestDistance = currentDistance;
        //            closestUnit = target;
        //        }
        //    }
        //}

        //if (closestUnit != null)
        //{
        //    target = closestUnit;
        //}
        //if (target != null)
        //{
        //    Vector3 from = transform.position;
        //    Vector3 to = target.transform.position;
        //    Vector3 direction = (to - from).normalized;
        //    Rb.AddForce(direction * 0.1f);
        //}
        //else
        //{
        //    Rb.AddForce(new Vector2(1f, 0) * 0.1f);
        //}

        //if (Rb.linearVelocity.x <= 0.2f)
        //{
        //    Rb.linearVelocityX = 0.2f;
        //}
        //if (Rb.linearVelocity.y <= 0.2f)
        //{
        //    Rb.linearVelocityY = 0.2f;
        //}

        Rb.AddForce(new Vector2(1f, 0) * 0.1f);
    }
}
