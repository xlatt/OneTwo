using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

    [SerializeField]
    private Material isAllowed;

    [SerializeField]
    private Material isNotAllowed;
    
    private MeshRenderer myRenderer;

    [HideInInspector]
    public List<Collider> colliders = new List<Collider>();
    
	// Use this for initialization
	void Awake () {
        myRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (colliders.Count > 0) {
            myRenderer.material = isNotAllowed;
        }
        else myRenderer.material = isAllowed;
    }

    private void OnTriggerEnter(Collider collider){
        if (!collider.tag.Equals("Untagged")) {
            colliders.Add(collider);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (!collider.tag.Equals("Untagged")) { 
            colliders.Remove(collider);
        }
    }

}
