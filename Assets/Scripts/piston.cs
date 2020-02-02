using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piston : MonoBehaviour
{
    bool broken;

    bool up;

    public float waitTime = 0.05f;

    Vector3 startPos;

    private void Start()
    {
        StartCoroutine(ChangeDirection());
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (up && !broken)
        {
            transform.position = startPos + Vector3.up * 1;
        }
        else if (!broken)
        {
            transform.position = startPos + Vector3.down * 1;
        }
        
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            up = !up;
        }

    }


}
