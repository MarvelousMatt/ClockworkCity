using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speen : MonoBehaviour
{

    public float rotspeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * rotspeed * Time.deltaTime);
    }
}
