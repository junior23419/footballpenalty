using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseActionListener : MonoBehaviour
{
    public BallController ballController;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit) && Input.GetMouseButtonDown(0))
        {   
            if(hit.transform.name =="ball")
            {
                Debug.Log("hit ball");
                ballController.PlayerClickOnBall();
            }
        }
    }

   
}
