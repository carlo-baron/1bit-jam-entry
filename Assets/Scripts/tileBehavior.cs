using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class tileBehavior : MonoBehaviour
{
   cell cellScript;

    void Awake(){
        cellScript = transform.parent.GetComponent<cell>();
    }
    void OnMouseDown(){
        cellScript.grid[(int)transform.localPosition.x, (int)transform.localPosition.y] = 1;
    }
}
