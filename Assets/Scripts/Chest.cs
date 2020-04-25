using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    public CapsuleCollider2D picer;
    public string nextScene;
    
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetBool("Openning", Varibles.coins >= 3);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Ebanyi");
        if (anim.GetBool("Openning"))
        {
            Debug.Log("ROT");
            if (col == picer)
            {
                Debug.Log("etogo casino BLATy");
                SceneLoader.loadScene(nextScene);
            }
        }
    }
}
