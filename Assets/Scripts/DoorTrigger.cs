using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public int ID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (ID == 7)
            {
                Camera.main.transform.SetParent(null);
                Camera.main.orthographicSize = 10;
            }


            GameManager.instance.NewRoom(ID);

            if(ID == 6)
            {
                Camera.main.transform.SetParent(other.transform);
                Camera.main.orthographicSize = 20;
            }

            if (ID == 11)
            {
                Camera.main.transform.SetParent(other.transform);
            }


        }
    }
}
