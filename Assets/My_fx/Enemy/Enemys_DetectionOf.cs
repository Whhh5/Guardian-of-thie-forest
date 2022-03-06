using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemys_DetectionOf : MonoBehaviour
{
    public int health = 10;

    public float maxmumDetectionRange;   //最大检测范围

    GameObject player;
    Animator anim;

    public float wjhhh_Enemy_PursuitOfTime = 0;
    bool wjhhh_IsPursuit = true;
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        MoveEnemy(); // 移动
    }

    public void wjhhh_F_IsDie()    //检测是否死亡
    {
        if (health <= 0 || player.GetComponent<Wjhhh_Player_Move>().health <= 0)
        {
            Debug.Log("死亡事件");
            anim.SetBool("IsDie", true);
            GetComponent<Enemys_DetectionOf>().enabled = false;
        }
    }
    public void wjhhh_F_Reception_Incident()    //受到攻击效果
    {
        Debug.Log("受到攻击");
    }
    void MoveEnemy() //控制移动
    {
        if (player.GetComponent<Wjhhh_Player_Move>().health <= 0)
        {
            player.GetComponent<Wjhhh_Player_Move>().IsDie();
            wjhhh_F_IsDie();
        }
        else
        {
            if (wjhhh_Enemy_PursuitOfTime >= 5 && wjhhh_IsPursuit)
            {
                Vector3 mDir = new Vector3(player.transform.position.x, 0, player.transform.position.z);
                transform.LookAt(mDir);
                wjhhh_Enemy_PursuitOfTime = 0;
            }
            if (wjhhh_IsPursuit)
            {
                wjhhh_Enemy_PursuitOfTime += Time.deltaTime;
            }
            //根据距离出发事件

            if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2) + Mathf.Pow(this.transform.position.z - player.transform.position.z, 2)) <= 1.0f)
            {
                Debug.Log("Player进入Enemy in maxmumRetectionRange 8m Attacking");
                anim.SetInteger("State", 5);
                player.GetComponent<Wjhhh_Player_Move>().health--;
                player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50f, -50f), ForceMode.Impulse);
            }
            else if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2) + Mathf.Pow(this.transform.position.z - player.transform.position.z, 2)) <= maxmumDetectionRange / 5)
            {
                Debug.Log("Player进入Enemy in maxmumRetectionRange / 5");
                anim.SetInteger("State", 4);
                Vector3 mDir = new Vector3(player.transform.position.x, 0, player.transform.position.z);
                transform.LookAt(mDir);

            }
            else if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2) + Mathf.Pow(this.transform.position.z - player.transform.position.z, 2)) <= maxmumDetectionRange / 4)
            {
                Debug.Log("Player进入Enemy in maxmumRetectionRange / 4");
                anim.SetInteger("State", 3);
            }
            else if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2) + Mathf.Pow(this.transform.position.z - player.transform.position.z, 2)) <= maxmumDetectionRange / 3)
            {
                Debug.Log("Player进入Enemy in maxmumRetectionRange / 3");
                anim.SetInteger("State", 2);
            }
            else if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2) + Mathf.Pow(this.transform.position.z - player.transform.position.z, 2)) <= maxmumDetectionRange)
            {
                Debug.Log("Player进入Enemy in maxmumRetectionRange");
                anim.SetInteger("State", 1);
            }
        }
    } 
}
