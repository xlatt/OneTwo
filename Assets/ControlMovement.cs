using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class ControlMovement : MonoBehaviour {
    public NavMeshAgent navMeshAgent;
    public bool moving;
    private Vector3 endPosition;

    void Start()
    {
        moving = false;
    }

    void Update () {
        
         if (moving) move();
    }

    public void move()
    {

        endPosition.y = 1.1f;
        bool equalX = Math.Round(transform.position.x, 2).Equals(Math.Round(endPosition.x, 2));
        bool equalZ = Math.Round(transform.position.z, 2).Equals(Math.Round(endPosition.z, 2));
        if (equalX && equalZ)
        {
            moving = false;
        }
         else {
            navMeshAgent.SetDestination(endPosition);
            //transform.position = endPosition;
            moving = true;
        }
        


    }

    public bool getMoving()
    {
        return moving;
    }

    public void setMoving()
    {
       moving = true;
    }
    public void setEndPosition(Vector3 endPosition)
    {
        this.endPosition = endPosition;
    }

}
