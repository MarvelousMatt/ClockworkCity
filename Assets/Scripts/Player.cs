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

    public bool wrenchDeployed = true;
    public float wrenchThrowSpeed;
    public GameObject wrenchPrefab;

    [Header("Oil")]

    public float oilDrag;
    public float nDrag;

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Wrench"));
            wrenchDeployed = false;
        }

        GroundedCheck();

        Movement();

        Jumping();

        HandleVelocity();

        if (Input.GetButtonDown("Fire1") && !wrenchDeployed)
            ThrowWrench();

    }

    void Movement()
    {
        Ray rayB = new Ray(transform.position - Vector3.down * 0.3f, transform.right * Input.GetAxis("Horizontal"));
        Ray rayU = new Ray(transform.position - Vector3.down * -0.3f, transform.right * Input.GetAxis("Horizontal"));

        if (Physics.SphereCast(rayU, 0.1f,0.5f,1,QueryTriggerInteraction.Ignore) || Physics.SphereCast(rayB, 0.1f, 0.5f, 1, QueryTriggerInteraction.Ignore))
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
            if(drag != oilDrag)
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

        if (!Physics.SphereCast(ray, 0.3f, 0.8f, 1, QueryTriggerInteraction.Ignore))
        {
            RaycastHit hit;
            Ray Ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(Ray,out hit,1.5f) && hit.collider.gameObject.tag == "Oil")
                drag = oilDrag;
            else
                drag = nDrag;
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
        wrenchDeployed = true;

        Vector3 throwDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 20)) - transform.position;

        GameObject wrench = Instantiate(wrenchPrefab, transform.position, Quaternion.identity);

        Quaternion rotStore = wrench.transform.rotation;

        wrench.transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 20)));

        wrench.transform.rotation = new Quaternion(rotStore.x, rotStore.y, wrench.transform.rotation.z, rotStore.w);


        wrench.GetComponent<Rigidbody>().AddForce(throwDirection.normalized * wrenchThrowSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Death"))
        {
            transform.position = GameManager.instance.playerRespawnPos;
        }
    }

}
