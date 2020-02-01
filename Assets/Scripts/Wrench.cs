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
        Invoke("EnablePickup",0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnablePickup()
    {
        gameObject.layer = 12;
    }

}
