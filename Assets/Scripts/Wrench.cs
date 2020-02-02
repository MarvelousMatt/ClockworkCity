using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    public enum UseMode { physics,turn,jam,stick};
    public UseMode mode = UseMode.physics;

    bool attached;

    // Start is called before the first frame update
    void Start()
    {
    }


    public void AttachMode()
    {
        attached = true;
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.gameObject.CompareTag("Player"))
        {
            gameObject.layer = 0;
        }
    }

}
