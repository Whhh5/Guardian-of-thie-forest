using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garlin_Localtion : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Quaternion q = Quaternion.identity;
        q.SetLookRotation(Camera.main.transform.forward, Camera.main.transform.up);
        transform.rotation = q;
    }
}
