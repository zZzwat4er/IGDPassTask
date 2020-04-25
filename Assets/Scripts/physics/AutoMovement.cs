using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : PhysiscsObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        outComeVelocity = Vector2.left * 10;
    }
}
