using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMusic : MonoBehaviour
{
    public void Fly()
    {
        GetComponent<AudioSource>().Play();
    }
}
