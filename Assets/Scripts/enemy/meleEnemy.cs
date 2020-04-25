using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class meleEnemy : MonoBehaviour
{ 
    public GameObject point1;
    public GameObject point2;
    public GameObject player;
    public float speed;
    
    // Start is called before the first frame update
    private GameObject targetPoint;
    private Vector3 lastVector;
    
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col == player.GetComponent<CapsuleCollider2D>())
        {
            player.transform.parent.transform.position = player.transform.position;
            player.GetComponent<Animator>().applyRootMotion = false;
            player.GetComponent<Animator>().SetTrigger("death");
        }
    }

    private void Start()
    {
        targetPoint = point1;
        lastVector = targetPoint.transform.position - gameObject.transform.position;
        lastVector = lastVector.normalized;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movementVector = targetPoint.transform.position - gameObject.transform.position;
        movementVector = movementVector.normalized;

        if (movementVector == Vector3.zero || movementVector != lastVector)
        {
            targetPoint = (targetPoint == point1) ? point2 : point1;
            lastVector = targetPoint.transform.position - gameObject.transform.position;
            lastVector = lastVector.normalized;
        }
        else
        {
            gameObject.transform.position += movementVector * (speed * Time.deltaTime);
            lastVector = movementVector;
        }
    }
}
