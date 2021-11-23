using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBuildings : MonoBehaviour
{

    public void ExitMenu()
    {
        transform.Find("Canvas").gameObject.SetActive(false);
    }
}
