using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRB;
    private float e_speed = 5;

    //encapsulated enemy speed
    protected float speed { get { return e_speed; }
        set {
            if (value < 0)
            {
                e_speed = 0;
            }
            else { e_speed = value; }
        }
    }

    //Kill player on contact
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    protected virtual void SeekPlayer()
    {
        //Get own RB
        enemyRB = gameObject.GetComponent<Rigidbody>();
        //Get the player
        GameObject target = GameObject.Find("Player");
        Vector3 targetPos = new Vector3(target.transform.position.x, enemyRB.transform.position.y, target.transform.position.z);
        if (enemyRB.transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }

    protected virtual void Dash()
    {
        if (GameObject.Find("Player"))
        {
            enemyRB = gameObject.GetComponent<Rigidbody>();
            GameObject target = GameObject.Find("Player");
            Vector3 direction = (target.transform.position - gameObject.transform.position).normalized;
            int speed = 10;
            enemyRB.AddForce(direction * speed, ForceMode.Impulse);
        }
    }

    protected virtual void Teleport()
    {
        float r_x = Random.Range(-10,10);
        float r_z = Random.Range(-10,10);
        if (GameObject.Find("Player"))
        {
            enemyRB = gameObject.GetComponent<Rigidbody>();
            GameObject target = GameObject.Find("Player");
            Vector3 P_Position = (target.transform.position + new Vector3(r_x,0,r_z));
            int speed = 10;
            enemyRB.transform.position = P_Position;
        }
    }
}
