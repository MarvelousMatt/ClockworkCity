using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    bool isAttached;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wrench")
        {
            collision.gameObject.transform.parent = transform;
            collision.gameObject.tag = "Untagged";
            Destroy(collision.gameObject.GetComponent<Wrench>());
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            isAttached = true;
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
