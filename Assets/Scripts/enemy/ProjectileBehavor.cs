using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavor : MonoBehaviour
{
    
    public GameObject player;
    public float speed;
    public Vector3 direction;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == player)
        {
            player.transform.parent.transform.position = player.transform.position;
            player.GetComponent<Animator>().applyRootMotion = false;
            player.GetComponent<Animator>().SetTrigger("death");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += direction * (speed * Time.deltaTime);
    } 
}
