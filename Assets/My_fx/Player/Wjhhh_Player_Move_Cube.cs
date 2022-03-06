using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wjhhh_Player_Move_Cube : MonoBehaviour
{
    public Transform wjhhh_FollowCamera;
    public float addForceSpeed = 100f;

    Rigidbody rb;
    
    Vector3 mDir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        wjhhh_FollowCamera = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.AddForce(transform.right * addForceSpeed * h);


        }
        if (Input.GetAxis("Vertical") != 0)
        {
            rb.AddForce(transform.forward * addForceSpeed * v);

            mDir = new Vector3(wjhhh_FollowCamera.transform.position.x, 0, wjhhh_FollowCamera.transform.position.z);
            Quaternion newRotation = Quaternion.LookRotation(mDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, 100);
        }
    }
}
