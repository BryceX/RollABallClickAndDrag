using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    RaycastHit hit;
    RaycastHit hit2;
    Ray ray;
    Ray ray2;
    Vector3 movement;

    //You can play roll a ball, but instead of with arrow keys, by clicking and dragging the mouse
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //takes a position to compare against later
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 100);         
        }
        //checks to see that you actually clicked on the ball before comparing the first position to the second one and making it move
        if (Input.GetMouseButtonUp(0)&&hit.transform.gameObject.tag == "Ball")
        {
            ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray2, out hit2, 100);         
            movement = hit2.point - hit.point;
            rb.velocity = movement;

            //Debug.Log(hit.point);
            //Debug.Log(hit2.point);
            //Debug.Log(movement);
        }      
    }
}