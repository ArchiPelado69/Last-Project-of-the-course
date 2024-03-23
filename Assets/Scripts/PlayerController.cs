using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRB;

    //Encapsulation to avoid negative speed
    private int p_velocity = 5;
    int velocity { get { return p_velocity; }
        set { 
        if (value < 0)
            {
                p_velocity = 0;
            }
            else { p_velocity = value; }
        } }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
       float p_Hinput = Input.GetAxis("Horizontal");
       float p_Vinput = Input.GetAxis("Vertical");

        playerRB.transform.Translate(Vector3.right * Time.deltaTime * velocity * p_Hinput);
        playerRB.transform.Translate(Vector3.forward * Time.deltaTime * velocity * p_Vinput);
    }

    void Jump()
    {
        float jumpForce = 2000;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(playerRB.transform.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
}