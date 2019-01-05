using UnityEngine;



public class HumanMovement : MonoBehaviour {

    public Rigidbody rb;
    public int[] rdy = new int[2];
    const int constant = 100;
    public CapsuleCollider cc;

    // Use this for initialization
    void Start () {

        Debug.Log("Creation - HUMAN [ENTER]");
        rdy[0] = 0;
        rdy[1] = 0;
       
        Debug.Log("Creation - HUMAN [EXIT]");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        guardHouse(rdy);
        

        
    }
    void guardHouse(int[] rdy) {

        if ((rdy[0]) < constant && (rdy[1]) == 0)
        {
            rb.AddForce(0, 0, 40 * Time.deltaTime);
            rdy[0]++;
        }
        else if ((rdy[0]) == constant && (rdy[1]) < constant)
        {
            rb.AddForce(0, 0, -40 * Time.deltaTime);
            rdy[1]++;
        }                                                       //speed 0

        else if (((rdy[0]) <= constant) && ((rdy[1]) == constant) && (rdy[0] != 0))
        {
            rb.AddForce(0, 0, -40 * Time.deltaTime);
            rdy[0]--;
        }

        else if ((rdy[0]) == 0 && (rdy[1] <= constant) && (rdy[1] != 0))
        {
            rb.AddForce(0, 0, 40 * Time.deltaTime);
            rdy[1]--;
        }                                                        //speed 0
    }

    
}
