using System;
using System.Collections.Generic;
using UnityEngine;

namespace enemy
{
    public class rangeEnemy : MonoBehaviour
    {
        public float shotingDelay;
        public GameObject player;
        public GameObject projectTile;
        private GameObject targetPoint;
        private Vector3 lastVector;
        private float lastTime;

        private void Start()
        {
            lastTime = Time.time;
        }

        private void FixedUpdate()
        {
            if(Time.time - lastTime > shotingDelay)
            {
                var pula = Instantiate(projectTile) as GameObject;
                pula.transform.position = gameObject.transform.position;
                pula.GetComponent<ProjectileBehavor>().direction = -(gameObject.transform.parent.transform.position -
                                                                     player.transform.position);
                pula.GetComponent<ProjectileBehavor>().direction =
                    pula.GetComponent<ProjectileBehavor>().direction.normalized;
                pula.GetComponent<ProjectileBehavor>().speed = 200;
                pula.GetComponent<ProjectileBehavor>().player = player;

                lastTime = Time.time;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col == player.GetComponent<CapsuleCollider2D>())
            {
                player.transform.parent.transform.position = player.transform.position;
                player.GetComponent<Animator>().applyRootMotion = false;
                player.GetComponent<Animator>().SetTrigger("death");
            }
        }
    }
}