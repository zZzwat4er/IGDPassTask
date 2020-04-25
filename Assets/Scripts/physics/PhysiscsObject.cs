using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysiscsObject : MonoBehaviour
{
    public float minNormalY = 0.65f;
    public float gravityModifire = 1f;


    protected Rigidbody2D rb2d;
    protected Vector2 groundNormal;
    protected Vector2 velocity;
    protected Vector2 outComeVelocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hit = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBuffer = new List<RaycastHit2D>(16);
    
    
    protected bool grounded;
    
    protected const float minDistanse = 0.01f;
    protected const float shallRadious = 0.01f;
    
    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    private void Update()
    {
        outComeVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {
        
    }

    private void FixedUpdate()
    {
        velocity += Physics2D.gravity * (gravityModifire * Time.deltaTime);
        velocity.x = outComeVelocity.x;
        grounded = false;
        Vector2 deltaPosition = velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x; 
        movement(move, false);
        move = Vector2.up * deltaPosition.y;
        movement(move, true);

    }

    private void movement(Vector2 move, bool yMove)
    {
        float distance = move.magnitude;

        if (distance > minDistanse)
        {
            int count = rb2d.Cast(move, contactFilter, hit, distance + shallRadious);
            hitBuffer.Clear();
            for (int i = 0; i < count; i++)
            {    
                hitBuffer.Add(hit[i]);
            }

            for (int i = 0; i < hitBuffer.Count; i++)
            {
                Vector2 currentNormal = hitBuffer[i].normal;
                if (currentNormal.y > minNormalY)
                {
                    grounded = true;
                    if (yMove)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float progection = Vector2.Dot(velocity, currentNormal);
                if (progection < 0)
                {
                    velocity -= currentNormal * progection;
                }

                float modifiedDistance = hitBuffer[i].distance - shallRadious;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
            
        }

        rb2d.position += move.normalized * distance;
    }
}
