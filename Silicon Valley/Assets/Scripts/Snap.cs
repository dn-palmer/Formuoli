using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snap : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<DragAndDrop> draggableObjects;
    public float snapRange = 0.5f;
    
    void Start()
    {
        foreach (DragAndDrop draggable in draggableObjects )
        {
            draggable.dragEndedCallBack = OnDragEnded;
        }
    }

   private void OnDragEnded(DragAndDrop draggable)
    {
        float closestDistance = -1f;
        Transform closestSnapPoint = null; 
        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector3.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;

            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange )
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
        }
    }
}
