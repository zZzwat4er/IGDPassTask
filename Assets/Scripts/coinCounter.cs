using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCounter : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < Varibles.coins; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite =
                Resources.Load("Pixel Platformer Pack/coin_gold", typeof(Sprite)) as Sprite;
        }
    }

    
}
