using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Type : MonoBehaviour
{
    public GameObject[] wjhhh_EnemyRun;
    int wjhhh_EnemyRun_i = 0;
    public int[] wjhhh_EnemyRun_NowHealth;
    public GameObject[] wjhhh_EnemyFly_Primary;
    int[] wjhhh_EnemyFly_Primary_NowHealth;
    public GameObject[] wjhhh_EnemyFly_Intermediate;
    int[] wjhhh_EnemyFly_Intermediate_NowHealth;
    public GameObject[] wjhhh_EnemyFly_Advanced;
    int[] wjhhh_EnemyFly_Advanced_NowHealth;
    public GameObject[] wjhhh_EnemyGuidedMissiler;
    int[] wjhhh_EnemyGuidedMissiler_NowHealth;

    public GameObject[] enemyType;//���ɵ�������
    public Transform[] enemyTypeBonAtTransform;//����λ��
    int enemyAmount = 10;//���������
    float currentTime = 0.0f;
    private void Start()
    {
        GenrerateEnemy();
    }
    private void Update()
    {
        //currentTime += Time.deltaTime;
        //if (currentTime % 5 == 0)
        //{
        //    for (int i = 0; i < enemyTypeBonAtTransform.Length; i++)
        //    {
        //        GameObject obj = Instantiate(enemyType[0], enemyTypeBonAtTransform[i]);
        //        wjhhh_EnemyRun[wjhhh_EnemyRun_i] = obj;
        //        wjhhh_EnemyRun_NowHealth[wjhhh_EnemyRun_i] = 10;
        //    }
        //}



        //for (int i = 0; i < enemyAmount; i++) //��������һ����
        //{
        //    if (true)
        //    {

        //    }
        //    for (int j = 0; j < enemyTypeBonAtTransform.Length; i++)
        //    {
        //        Invoke("GenrerateEnemy", 1);
        //    }
        //}


    }
    public void GenrerateEnemy()  //���ɵ���
    {
        if (enemyAmount > 0)
        {
            for (int i = 0; i < enemyTypeBonAtTransform.Length; i++)
            {
                GameObject obj = Instantiate(enemyType[0], enemyTypeBonAtTransform[i]);
                wjhhh_EnemyRun[wjhhh_EnemyRun_i] = obj;
                wjhhh_EnemyRun_NowHealth[wjhhh_EnemyRun_i] = 10;
                wjhhh_EnemyRun_i++;
            }
            enemyAmount--;
        }
        Invoke("GenrerateEnemy", 5);
    }
    public void wjhhh_F_IndexesEnemy(GameObject byEnemy_TypeF,int wjhhh_HappenIsHarm_Date)       //�жϵ������Ͳ�����Ѫ��
    {
        for (int j = 0; j < wjhhh_EnemyRun.Length; j++)    //�жϵ�һ����������
        {
            if (wjhhh_EnemyRun[j] == byEnemy_TypeF)
            {
                if (wjhhh_EnemyRun_NowHealth[j] > 0)
                {
                    wjhhh_EnemyRun_NowHealth[j] -= wjhhh_HappenIsHarm_Date;
                    wjhhh_EnemyRun[j].GetComponent<Enemys_DetectionOf>().wjhhh_F_Reception_Incident();
                    return;
                }
                else
                {
                    Debug.Log("�������Ķ����Ѿ�����");
                }
            }
        }
        wjhhh_F_IsDie();
    }
    public void wjhhh_F_IsDie()    //����Ƿ�����
    {
        for (int i = 0; i < wjhhh_EnemyRun_NowHealth.Length; i++)
        {
            if (wjhhh_EnemyRun_NowHealth[i] <= 0)
            {
                wjhhh_EnemyRun[i].GetComponent<Enemys_DetectionOf>().wjhhh_F_IsDie();
                wjhhh_EnemyRun_NowHealth[i]--;
            }
        }
        //for (int i = 0; i < wjhhh_EnemyFly_Primary_NowHealth.Length; i++)
        //{
        //    if (wjhhh_EnemyFly_Primary_NowHealth[i] == 0)
        //    {
        //        wjhhh_EnemyFly_Primary[i].GetComponent<Enemys_DetectionOf>().wjhhh_F_IsDie();
        //        wjhhh_EnemyFly_Primary_NowHealth[i]--;
        //    }
        //}
        //for (int i = 0; i < wjhhh_EnemyFly_Intermediate_NowHealth.Length; i++)
        //{
        //    if (wjhhh_EnemyFly_Intermediate_NowHealth[i] == 0)
        //    {
        //        wjhhh_EnemyFly_Intermediate[i].GetComponent<Enemys_DetectionOf>().wjhhh_F_IsDie();
        //        wjhhh_EnemyFly_Intermediate_NowHealth[i]--;
        //    }
        //}
        //for (int i = 0; i < wjhhh_EnemyFly_Advanced_NowHealth.Length; i++)
        //{
        //    if (wjhhh_EnemyFly_Advanced_NowHealth[i] == 0)
        //    {
        //        wjhhh_EnemyFly_Advanced[i].GetComponent<Enemys_DetectionOf>().wjhhh_F_IsDie();
        //        wjhhh_EnemyFly_Advanced_NowHealth[i]--;
        //    }
        //}
        //for (int i = 0; i < wjhhh_EnemyGuidedMissiler_NowHealth.Length; i++)
        //{
        //    if (wjhhh_EnemyGuidedMissiler_NowHealth[i] == 0)
        //    {
        //        wjhhh_EnemyGuidedMissiler[i].GetComponent<Enemys_DetectionOf>().wjhhh_F_IsDie();
        //        wjhhh_EnemyGuidedMissiler_NowHealth[i]--;
        //    }
        //}
    }
}
