using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMagicTailAfter : MonoBehaviour
{
    Transform playerTransform;
    public Vector2 speed2;
    float speed;
    bool action = false;
    public int damage = 2;
    void Start()
    {
        speed = Random.Range(speed2.x, speed2.y);
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        Invoke("MagicTailAfterMove", 4f);
    }

    void Update()
    {
        if (action)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + new Vector3(0,0.3f,0), speed * Time.deltaTime);
        }
    }
    void MagicTailAfterMove()
    {
        action = true;
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == 8 && other.gameObject.GetComponent<Wjhhh_Player_Move>())
        {
            other.gameObject.GetComponent<Wjhhh_Player_Move>().health -= damage;
        }
        else
        {
            Debug.Log("该对象不是第八层 or 没有指定脚本脚本");
        }
        if (other.gameObject.name == "Mage03")
        {
            other.GetComponent<EnemyMageBossMove>().health -= damage;
        }
    }
}
