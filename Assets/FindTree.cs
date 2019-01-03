using UnityEngine;

public class FindTree : MonoBehaviour {
    private int treeCount = 0;
    //treba dorobit tree count
    private void OnTriggerEnter(Collider collInfo)
    {

        //  if(collInfo.collider.tag == "Tree")
        if (collInfo.name == "Tree")
        {
            Debug.Log("Human Found A tree:" + collInfo.name);

            MeshRenderer meshRend = GetComponent<MeshRenderer>();
            meshRend.material.color = Color.blue;
            treeCount++;
        }
    }

    private void OnTriggerExit(Collider collInfo)
    {

        // Revert the cube color to white.
  
        if (collInfo.name == "Tree")
        {
            Debug.Log("Human Lost track of a tree: " + collInfo.name);
            MeshRenderer meshRend = GetComponent<MeshRenderer>();;
            treeCount--;
            if (treeCount == 0)
            {
                meshRend.material.color = Color.green;
            }
        }
       
    }

}
