using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject Prefab;
    public Vector2Int Size;
    private Vector3 PositionNew;
    private void Update()
    {
        PositionNew = (Size == Vector2Int.one) 
            ? transform.position - new Vector3 (1, 0, 1) 
            : transform.position;
        if (Service.BuildingMode == true)
        {
            GetComponent<LineRenderer>().enabled = true;
            LinePainter();
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
        }
    }
    public void LinePainter()
    {
        GetComponent<LineRenderer>().SetPositions(
            new Vector3[] { PositionNew - new Vector3(Size.x/2,-.1f,Size.y/2),
            new Vector3(Size.x + PositionNew.x - Size.x/2, .1f, PositionNew.z - Size.y/2),
            new Vector3(Size.x + PositionNew.x - Size.x/2, .1f, Size.y + PositionNew.z - Size.y/2),
            new Vector3(PositionNew.x - Size.x/2, .1f, Size.y + PositionNew.z - Size.y/2)});
    }
    public void lineColor(bool available)
    {
        GetComponent<LineRenderer>().startColor = GetComponent<LineRenderer>().endColor = (available)
            ? Color.green
            : Color.red;
    }
    private void OnDrawGizmos()
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
