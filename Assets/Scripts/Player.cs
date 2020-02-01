using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xVel = 0;
    float yVel = 0;

    public float gravity = 0.01f;
    public float drag = 0.01f;

    public float maxYVel = 15f;
    public float minYVel = 0.05f;
    public float maxXVel = 0.5f;

    public float xSpeed = 0.1f;
    public float jumpSpeed = 0;

    [Header ("Wrench")]

    bool wrenchDeployed;
    public float wrenchThrowSpeed;
    public GameObject wrenchPrefab;

    private void Update()
    {
        GroundedCheck();

        Movement();

        Jumping();

        HandleVelocity();

        if (Input.GetButtonDown("Fire1"))
            ThrowWrench();

    }

    void Movement()
    {
        Ray rayB = new Ray(transform.position - Vector3.down * 0.3f, transform.right * Input.GetAxis("Horizontal"));
        Ray rayU = new Ray(transform.position - Vector3.down * -0.3f, transform.right * Input.GetAxis("Horizontal"));

        if (Physics.SphereCast(rayU, 0.1f,0.5f) || Physics.SphereCast(rayB, 0.1f, 0.5f))
        {
            xVel = 0;
            return;
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            xVel += xSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else
        {
            xVel = 0;
        }



        
    }

    void Jumping()
    {
        if(Input.GetKey(KeyCode.Space) && GroundedCheck())
        {
            yVel = 0;
            yVel += jumpSpeed * Time.deltaTime;
        }
    }

    bool GroundedCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (!Physics.SphereCast(ray, 0.3f, 0.8f))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void HandleVelocity()
    {

        xVel = Mathf.Clamp(xVel, -maxXVel, maxXVel);
        yVel = Mathf.Clamp(yVel, -maxYVel, maxYVel);

        Vector3 moveVector = new Vector3(xVel,yVel);

        transform.position += moveVector;


        if (GroundedCheck())
        {
            yVel = 0;
        }
        else if(yVel > -minYVel)
        {
            yVel -= gravity;
        }
    }

    void ThrowWrench()
    {
        Vector3 throwDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        GameObject wrench = Instantiate(wrenchPrefab, transform.position, Quaternion.identity);

        wrench.GetComponent<Rigidbody>().AddForce(throwDirection.normalized * wrenchThrowSpeed);
    }

   


}
