using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatlin : MonoBehaviour
{
    public Animator my_Gatlin_DadDancing_Long;
    public Animator my_Gatlin_DadDancing_Short;
    public Animator my_MachinechGun;
    public GameObject my_Gatlin_DadDancing_Fire;
    public GameObject my_Gatlin_DadDancing_Shrink_Fire; 
    public Transform[] my_Gatlin_DadDancing_Fire_Transform;
    public Transform my_Gatlin_DadDancing_Shrink_Fire_Transform;
    public Transform player;

    public bool isMouseButton1 = false;
    public float my_Interval_Time;
    public float fair_Jiange;
    void Start()
    {
        my_Interval_Time = 0f;
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        my_Interval_Time += Time.deltaTime;

        

        if (my_Interval_Time >= fair_Jiange && Mathf.Sqrt(Mathf.Pow(player.position.x - transform.position.x,2) + Mathf.Pow(player.position.z - transform.position.z,2)) <= 2 && Mathf.Sqrt(Mathf.Pow(player.position.y - transform.position.y, 2)) < 5)
        {
            Gatlin_Fire();
        }
    }
    void Gatlin_Fire()
    {
        if (Input.GetMouseButton(1) && isMouseButton1)
        {
            Instantiate(my_Gatlin_DadDancing_Shrink_Fire, my_Gatlin_DadDancing_Shrink_Fire_Transform);
            my_Gatlin_DadDancing_Long.SetBool("ShrinkFire", true);
            my_Gatlin_DadDancing_Short.SetBool("ShrinkFire", true);
            Debug.Log("Input Mouse 1");

            my_Interval_Time = 0f;

        }
        else if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < my_Gatlin_DadDancing_Fire_Transform.Length; i++)
            {
                Instantiate(my_Gatlin_DadDancing_Fire, my_Gatlin_DadDancing_Fire_Transform[i]);
                my_Gatlin_DadDancing_Long.SetBool("Fire", true);
                my_Gatlin_DadDancing_Short.SetBool("Fire", true);
            }
            my_Interval_Time = 0f;
        }
        else
        {
            my_Gatlin_DadDancing_Long.SetBool("ShrinkFire", false);
            my_Gatlin_DadDancing_Long.SetBool("Fire", false);
            my_Gatlin_DadDancing_Short.SetBool("ShrinkFire", false);
            my_Gatlin_DadDancing_Short.SetBool("Fire", false);
        }

    }
}
