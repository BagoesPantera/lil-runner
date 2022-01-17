using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMover : MonoBehaviour
{
    public List<Transform> points;
    public Transform saw;
    int goalPoint=0;
    public float moveSpeed = 2;

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //change the position of the saw (move towards the goal point)
        saw.position = Vector2.MoveTowards(saw.position, points[goalPoint].position,Time.deltaTime*moveSpeed);
        //Check if we are in very close proximity of the next point
        if(Vector2.Distance(saw.position, points[goalPoint].position)<0.1f)
        {
            //If so change goal point to the next one
            //Check if we reached the last point, reset to first point
            if (goalPoint == points.Count - 1)
                goalPoint = 0;
            else
                goalPoint++;            
        }
    }
}
