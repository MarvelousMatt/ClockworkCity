using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapValues;

public class Nut : MonoBehaviour
{
    bool isAttached;

    Vector3 scale;

    public enum ActivationMode { transform,rotate,animate,special};
    public ActivationMode mode;

    public float rotSpeed;

    public GameObject targetObject;

    public Quaternion startRotation;
    public Vector3 targetRotation;

    public Vector3 startPosition;
    public Vector3 targetPosition;

    bool targetReached;

    bool startReached;

    private void Awake()
    {
        scale = transform.localScale;
        startRotation = targetObject.transform.rotation;
        startPosition = targetObject.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wrench")
        {
            collision.gameObject.transform.parent = transform;
            collision.gameObject.GetComponent<Wrench>().AttachMode();
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            isAttached = true;
        }
    }

    void DetachWrench()
    {
        isAttached = false;
        transform.localScale = scale;
    }


    public void Collider1Trigger()
    {
        transform.Rotate(Vector3.down * rotSpeed * Time.deltaTime);
        UpdateTarget(true);
    }

    public void Collider2Trigger()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        UpdateTarget(false);
    }

    void UpdateTarget(bool up)
    {
        switch (mode)
        {
            case ActivationMode.rotate:
                if (up)
                {
                    targetObject.transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime);
                }
                else
                {
                    targetObject.transform.Rotate(Vector3.left * rotSpeed * Time.deltaTime);
                }
                break;
            case ActivationMode.transform:
                if (up)
                {
                    targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, targetPosition,rotSpeed * 0.25f * Time.deltaTime);
                }
                else
                {
                    targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position,startPosition , rotSpeed * 0.25f * Time.deltaTime);
                }

                break;
        }
    }

    private void Update()
    {
        
        if (!isAttached)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezeRotationY;
        }
        
        
    }

    private void LateUpdate()
    {
        //transform.rotation = new Quaternion(Quaternion.identity.x, Quaternion.identity.y, transform.rotation.z, Quaternion.identity.w);
    }
}
