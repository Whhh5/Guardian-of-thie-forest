using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodVolume : MonoBehaviour
{
    GameObject pllayer;

    int player_MaxHealth;
    int player_NowHealth;
    float player_HealthProprotion = 0;
    RectTransform image;
    public GameObject hea;

    public GameObject defeated;
    private void Start()
    {
        player_MaxHealth = GameObject.Find("Player").GetComponent<Wjhhh_Player_Move>().health;
        image = hea.GetComponent<RectTransform>();
        pllayer = GameObject.Find("Player");
    }
    private void Update()
    {
        player_NowHealth = GameObject.Find("Player").GetComponent<Wjhhh_Player_Move>().health;
        player_HealthProprotion = (float)player_NowHealth / (float)player_MaxHealth;
        if (player_HealthProprotion < 0)
        {
            player_HealthProprotion = 0;
        }
        Debug.Log("��ǰѪ������Ϊ" + player_HealthProprotion + "���Ѫ��Ϊ" + player_MaxHealth + "��ǰѪ��Ϊ" + player_NowHealth);
        image.localScale = new Vector3(1 * player_HealthProprotion, 1 , 1 );

        Reslt();
    }
    void Reslt()
    {
        if (pllayer.GetComponent<Wjhhh_Player_Move>().health <= 0)
        {
            defeated.SetActive(true);
        }
    }
}
