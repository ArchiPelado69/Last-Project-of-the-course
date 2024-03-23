using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] float speed;
    GameObject target;
    Rigidbody enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        //Get own RB
        enemyRB = gameObject.GetComponent<Rigidbody>();

        //Get the player
       target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player"))
        {
            SeekPlayer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

      void SeekPlayer()
    {
        Vector3 targetPos = new Vector3 (target.transform.position.x, enemyRB.transform.position.y, target.transform.position.z);
        if (enemyRB.transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
