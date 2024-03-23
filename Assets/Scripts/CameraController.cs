using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 offset = new Vector3(0, 17, -20);
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameObject.Find("Player"))
        {
            transform.position = player.transform.position + offset;
        }
    }
}
