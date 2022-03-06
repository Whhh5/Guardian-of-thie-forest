using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        anima = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            
        }
    }
}
