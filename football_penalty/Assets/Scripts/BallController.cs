using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public LevelController levelController;
    public float power;
    Rigidbody rb;
    public float x_min;
    public float x_max;
    public float y_min;
    public float y_max;
    public float z_min;
    public float z_max;
    bool isClickable;
    Vector3 originPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        isClickable = true;
        rb = GetComponent<Rigidbody>();
        originPosition = new Vector3();
        originPosition = gameObject.transform.position;
    }

    void Start()
    {
        
    }


    public void PlayerClickOnBall()
    {
        if(isClickable)
        {
            float x = Random.Range(x_min, x_max);
            float y = Random.Range(y_min, y_max);
            float z = Random.Range(z_min, z_max);
            Vector3 direction = new Vector3(x, y, z);
            isClickable = false;
            Kick(direction);
        }


    }

    private void Kick(Vector3 direction)
    {
        levelController.OnPlayerStartKicking();
        rb.AddForce(direction*power);
    }

    public void ResetPosition()
    {
        isClickable = true;
        gameObject.transform.position = originPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void SetFootballControlStatus(bool val)
    {
        isClickable = val;
    }
}
