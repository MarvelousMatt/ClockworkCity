using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrench : MonoBehaviour
{
    public enum UseMode { physics,turn,jam,stick};
    public UseMode mode = UseMode.physics;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.gameObject.CompareTag("Player"))
        {
            gameObject.layer = 0;
        }
    }

}
