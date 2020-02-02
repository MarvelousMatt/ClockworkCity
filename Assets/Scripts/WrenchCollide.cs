using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma 

public class WrenchCollide : MonoBehaviour
{
    public bool ISONE;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            

            if (ISONE && transform.parent.transform.parent != null)
            {
                SendMessageUpwards("Collider1Trigger", gameObject);
            }
            else if (transform.parent.transform.parent != null)
            {
                SendMessageUpwards("Collider2Trigger", gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        if(transform.parent.transform.parent != null)
            SendMessageUpwards("DetachWrench",gameObject);
    }

}
