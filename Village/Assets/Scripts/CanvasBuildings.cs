using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBuildings : MonoBehaviour
{
    private void Start()
    {
        transform.Find("Canvas").rotation = Service.camera¿ngle;
    }
    public void ExitMenu()
    {
        transform.Find("Canvas").gameObject.SetActive(false);
    }
    public void DestroyBuilding()
    {
        for (int x = 0; x < GetComponent<Building>().Size.x; x++)
        {
            for (int y = 0; y < GetComponent<Building>().Size.y; y++)
            {
                BuildingsGrid.grid[(int)transform.position.x + x, (int)transform.position.z + y] = null;
            }
        }
        Destroy(transform.gameObject);
    }
}
