using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Builder : MonoBehaviour
{
    public static Builder instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<Vector3Int, GameObject> Buildings = new Dictionary<Vector3Int, GameObject>();

    private bool isBuilding = false;

    [SerializeField] private GameObject _buildingBlueprint;

    private GameObject BluePrint;
    private GameObject PlacingBuilidng;

    private void Start()
    {
        BluePrint = Instantiate(_buildingBlueprint, Vector3.zero, Quaternion.identity);
        BluePrint.SetActive(false);
    }

    private void Blueprint(GameObject Prefab, Quaternion Rotation, Vector3 Position)
    {
        BluePrint.GetComponent<SpriteRenderer>().sprite = Prefab.GetComponent<SpriteRenderer>().sprite;
        BluePrint.transform.position = Position;
        BluePrint.transform.rotation = Rotation;
    }
    private void BuildMode(GameObject Placing)
    {
        Vector2 Mouseworldpos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        Vector3Int gridPos = GridManager.instance.grid.WorldToCell(Mouseworldpos);
        Vector2 placementPos = GridManager.instance.grid.GetCellCenterWorld(gridPos);

        Blueprint(Placing, Quaternion.identity, placementPos);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (GridManager.instance.GridDataMap[gridPos].isOccupied == false)
            {
                Instantiate(Placing, placementPos, Quaternion.identity);
                GridManager.instance.GridDataMap[gridPos].isOccupied = true;
                Buildings[gridPos] = Placing;

                isBuilding = false;
                PlacingBuilidng = null;
                BluePrint.SetActive(false);
            }
        }
    }
    public void StartBuilding(GameObject BuildingPrefab)
    {
        isBuilding = true;
        PlacingBuilidng = BuildingPrefab;
        BluePrint.SetActive(true);
    }
    void Update()
    {
        if (isBuilding)
        {
            BuildMode(PlacingBuilidng);
        }
    }



}
