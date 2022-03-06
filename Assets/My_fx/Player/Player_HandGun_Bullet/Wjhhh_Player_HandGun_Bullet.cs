using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wjhhh_Player_HandGun_Bullet : MonoBehaviour
{
    public GameObject wjhhh_HandGunBullet;
    public Transform wjhhh_TargetLocation;
    int wjhhh_Player_Stating;

    public float wjhhh_BulletIntercalTime;
    float wjhhh_BulletTime =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wjhhh_BulletTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        wjhhh_Player_Stating = GameObject.Find("Player").GetComponent<Animator>().GetInteger("Stating");
        if (Input.GetMouseButton(0) && wjhhh_BulletTime >= wjhhh_BulletIntercalTime && wjhhh_Player_Stating == 1)
        {
            Instantiate(wjhhh_HandGunBullet, wjhhh_TargetLocation);
            wjhhh_BulletTime = 0;
        }
    }
}
