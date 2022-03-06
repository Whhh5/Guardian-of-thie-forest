using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosBloodVolume : MonoBehaviour
{
    GameObject pllayer;

    int player_MaxHealth;
    int player_NowHealth;
    float player_HealthProprotion = 0;
    RectTransform image_p;
    public GameObject hea;

    public GameObject defeated;



    public GameObject mageBoss;
    int mageBossMaxHealth;
    int mageBossNowHealth = 0;
    float mageBossProrotion = 0;
    public RectTransform image;

    public bool isAction = false;
    public GameObject cameraMageBoss;
    GameObject player;

    public GameObject victory;

    bool a = false;
    void Start()
    {
        mageBossMaxHealth = mageBoss.GetComponent<EnemyMageBossMove>().health;
        player = GameObject.Find("Player");


        player_MaxHealth = GameObject.Find("Player").GetComponent<Wjhhh_Player_Move>().health;
        image_p = hea.GetComponent<RectTransform>();
        pllayer = GameObject.Find("Player");
    }

    void Update()
    {
        Result();
        if (isAction)
        {
            cameraMageBoss.SetActive(true);
            if (image.localScale.x <= 1 && !a)
            {
                image.localScale += new Vector3(0.1f * Time.deltaTime, 0, 0);
            }
            else
            {
                a = true;
            }

            Invoke("BossMageVolume", 10);
        }


        player_NowHealth = GameObject.Find("Player").GetComponent<Wjhhh_Player_Move>().health;
        player_HealthProprotion = (float)player_NowHealth / (float)player_MaxHealth;
        if (player_HealthProprotion < 0)
        {
            player_HealthProprotion = 0;
        }
        Debug.Log("当前血量比例为" + player_HealthProprotion + "最大血量为" + player_MaxHealth + "当前血量为" + player_NowHealth);
        image_p.localScale = new Vector3(1 * player_HealthProprotion, 1, 1);
    }

    void BossMageVolume()
    {
        mageBossNowHealth = mageBoss.GetComponent<EnemyMageBossMove>().health;
        mageBossProrotion = (float)mageBossNowHealth / (float)mageBossMaxHealth;

        image.localScale = new Vector3(1 * mageBossProrotion, 1, 1);
    }

    void Result()
    {
        if (mageBoss.GetComponent<EnemyMageBossMove>().health <= 0)
        {
            victory.SetActive(true);
        }
        else if (player.GetComponent<Wjhhh_Player_Move>().health <= 0)
        {
            defeated.SetActive(true);
        }
    }
}
