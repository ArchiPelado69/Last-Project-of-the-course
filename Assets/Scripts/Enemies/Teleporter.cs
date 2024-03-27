using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Enemy
{

    bool teleported = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            SeekPlayer();
            if (teleported == false)
            {
                StartCoroutine(TPCorrutine());
                teleported = true;
            }
        }
        else
        {
            StopCoroutine(TPCorrutine());
            teleported = true;
        }

    }

    IEnumerator TPCorrutine()
    {
        yield return new WaitForSeconds(5);
        Teleport();
        teleported = false;
    }
}
