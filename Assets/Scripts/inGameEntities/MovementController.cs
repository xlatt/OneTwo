using UnityEngine;
using System;
using UnityEngine.AI;



public class MovementController : MonoBehaviour {
    [SerializeField]
    GameObject destinatiomMarker;
    [SerializeField]
    public NavMeshAgent navMeshAgent;

    [HideInInspector]
    private bool moving;
    
    private Vector3 endPosition;

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
            hideDestinationMarker();
            moving = false;
        }
         else {
            showDestinationMarker(endPosition);
            navMeshAgent.SetDestination(endPosition);
            moving = true;
        }
        


    }

    public void showDestinationMarker(Vector3 newUnitPosition) {
        destinatiomMarker.transform.position = newUnitPosition;
        destinatiomMarker.SetActive(true);
    }
    public void hideDestinationMarker(){
        destinatiomMarker.SetActive(false);
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
