using UnityEngine;

public class TestTower : Building
{
    public Unit target;
    private void Update()
    {
        if (CheckAggression(target, transform))
            transform.position += new Vector3(0, Time.deltaTime);
    }
}
