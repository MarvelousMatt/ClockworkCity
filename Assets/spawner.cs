using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject cratePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(cratePrefab, transform.position + Vector3.down, Quaternion.identity);
        }
        

    }
}
