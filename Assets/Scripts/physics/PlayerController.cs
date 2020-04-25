using System;
using JetBrains.Annotations;
using UnityEngine;
using static Unity.Mathematics.math;

namespace physics
{
    public class PlayerController : PhysiscsObject
    {
        public float maxSpeed = 50;
        public float JumpTaceOffSpeed = 70;

        private Animator animator;
        private SpriteRenderer spriteRenderer;
        private int jumpCount;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            //spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void ComputeVelocity()
        {
            Vector2 move = Vector2.zero;
            move.x = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && jumpCount > 0)
            {
                jumpCount--;
                velocity.y = JumpTaceOffSpeed;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0)
                {
                    velocity.y *= 0.5f;
                }
            }

            // bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f ) : (move.x < 0.01f));
            //
            // if (flipSprite)
            // {
            //     spriteRenderer.flipX = !spriteRenderer.flipX;
            // }
            animator.SetBool("Grounded", grounded);
            if (abs(move.x) > 0.1f)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }
            
            if (grounded) jumpCount = 1;
            outComeVelocity = move * maxSpeed;
        }

        
    }
}