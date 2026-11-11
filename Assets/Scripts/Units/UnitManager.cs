using UnityEngine;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance { get; private set; }
    public List<Unit> Units = new List<Unit>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
