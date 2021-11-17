using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DragAndDrop : MonoBehaviour
{
    public GameObject objSelected = null;
    public GameObject[] snapPoints;
    private float snapSensitivity = 7.0f;
    public TextMeshProUGUI log;


    void Update()
    {
        //object clicked on
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
        }
        //drag an object 
        if (Input.GetMouseButton(0) && objSelected != null)
        {
            DragObject();
        }
        //drop object
        if (Input.GetMouseButtonUp(0) && objSelected != null)
        {
            DropObject();
        }

        
    }

    void CheckHitObject()
    {
        RaycastHit2D hit2d = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        if (hit2d.collider != null)
        {
            objSelected = hit2d.transform.gameObject;
        }
      
    }

    
     void DragObject()
    {
        objSelected.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 10.0f));
    }

    void DropObject()
    {
        for (int i = 0; i < snapPoints.Length; i++)
        {

            if (Vector3.Distance(snapPoints[i].transform.position, objSelected.transform.position) < snapSensitivity)
            {
                objSelected.transform.position = new Vector3(snapPoints[i].transform.position.x + 0.3f , snapPoints[i].transform.position.y, snapPoints[i].transform.position.z - 0.1f);
            }
        }
        objSelected = null;
    }

}