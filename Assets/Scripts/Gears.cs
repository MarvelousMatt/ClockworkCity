using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gears : MonoBehaviour
{

    public GameObject targetObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wrench"))
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            Destroy(targetObj);

        }
    }
}
