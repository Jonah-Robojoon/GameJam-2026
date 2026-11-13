using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingTest : MonoBehaviour
{
    [SerializeField] private GameObject _buildingPrefab;

    void Update()
    {
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            Builder.instance.StartBuilding(_buildingPrefab);
        }
    }
}
