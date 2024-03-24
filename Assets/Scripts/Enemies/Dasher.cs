using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : Enemy
{
    bool dashed = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            SeekPlayer();
            if (dashed == false)
            {
                StartCoroutine(DashCorrutine());
                dashed = true;
            }
        }
        else
        {
            StopCoroutine(DashCorrutine());
            dashed = true;
        }
    }

    IEnumerator DashCorrutine()
    {
       yield return new WaitForSeconds(3);
       Dash();
       dashed = false;
    }
}