using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);
    private Building[,] grid;
    private Building flyingBuilding;
    public Camera mainCamera;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
    }
    public void StartPlacingBuildibg(Building buildingPrefab)
    {
        if (flyingBuilding != null)
            Destroy(flyingBuilding.gameObject);
        flyingBuilding = Instantiate(buildingPrefab);
        Service.BuildingMode = true;
    }
    private void Update()
    {
        if (flyingBuilding != null)
        {
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);
                flyingBuilding.transform.position = new Vector3(x,0,y);

                bool available = true;

                if (x < 0 || x > GridSize.x - flyingBuilding.Size.x) available = false;
                if (y < 0 || y > GridSize.y - flyingBuilding.Size.y) available = false;

                if (available && IsPlaceTaken(x, y)) available = false;

                flyingBuilding.lineColor(available);

                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x,y);
                    Service.BuildingMode = false;
                }
                if (Input.GetMouseButtonDown(1) && flyingBuilding != null)
                {
                    Destroy(flyingBuilding.gameObject);
                    Service.BuildingMode = false;
                }
            }
        }
    }
    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }
        return false;
    }
    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for(int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = flyingBuilding;
            }
        }
        flyingBuilding = null;
    }
}
