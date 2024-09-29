using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class tileBehavior : MonoBehaviour
{
   CellularAutomata cellScript;

    void Awake(){
        cellScript = transform.parent.GetComponent<CellularAutomata>();
    }
    void OnMouseDown(){
        cellScript.grid[(int)transform.localPosition.x, (int)transform.localPosition.y] = 0;
    }
}
