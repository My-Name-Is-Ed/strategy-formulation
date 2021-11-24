using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    public GameObject Prefab;
    public Vector2Int Size;
    private Vector3 PositionNew;
    private float Hight = .1f;

    private void Update()
    {
        PositionNew = (Size == Vector2Int.one) 
            ? transform.position - new Vector3 (1, 0, 1) 
            : transform.position;
        if (Service.buildingMode == true || transform.Find("Canvas").gameObject.activeSelf == true)
        {
            GetComponent<LineRenderer>().enabled = true;
            LinePainter();
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject()
            &&  Service.buildingMode == false)
            transform.Find("Canvas").gameObject.SetActive(true);
    }
    public void LinePainter()   //Only for Building Mode
    {
        GetComponent<LineRenderer>().SetPositions(
            new Vector3[] { PositionNew - new Vector3(Size.x/2, -Hight ,Size.y/2),
            new Vector3(Size.x + PositionNew.x - Size.x/2, Hight, PositionNew.z - Size.y/2),
            new Vector3(Size.x + PositionNew.x - Size.x/2, Hight, Size.y + PositionNew.z - Size.y/2),
            new Vector3(PositionNew.x - Size.x/2, Hight, Size.y + PositionNew.z - Size.y/2)});
    }
    public void lineColor(bool available)   //Only for Building Mode
    {
        GetComponent<LineRenderer>().startColor = GetComponent<LineRenderer>().endColor = (available)
            ? Color.green
            : Color.red;
        Hight = (available)
            ? .1f
            : .15f;
    }   
    private void OnDrawGizmos() //Only for Building Mode
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = (x+y)%2==0 ?  Color.red : Color.blue;
                Gizmos.DrawCube(PositionNew + new Vector3(x- Size.x / 2+ 0.5f, 0, y- Size.y / 2 + 0.5f), new Vector3(1, .1f, 1));
            }
        }
    }
}
