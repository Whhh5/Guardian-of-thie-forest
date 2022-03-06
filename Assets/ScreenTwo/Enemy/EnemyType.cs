using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public GameObject[] enemyMagic;
    public GameObject[] enemyMalphite;
    public int[] magicHealth;

    private void Start()
    {
        if (malphite)
        {
            GenrerateEnemy();
        }
        if (mage)
        {
            GenrerateEnemyMage();
        }
    }


    public void Reduce(GameObject gb ,int number) //���ٵз�Ѫ��
    {
        if (gb.tag == "Mage" && gb.GetComponent<EnemyMageMove>().health > 0)  //��ʦ
        {
            gb.GetComponent<EnemyMageMove>().health -= number;
            gb.GetComponent<EnemyMageMove>().IsDie();
            Debug.Log("��ʦ�ܵ�����");
        }
        else if (gb.tag == "Malphite" && gb.GetComponent<Enemys_DetectionOf>().health > 0)   //ʯͷ��
        {
            gb.GetComponent<Enemys_DetectionOf>().health -= number;
            gb.GetComponent<Enemys_DetectionOf>().wjhhh_F_IsDie();
            Debug.Log("ʯͷ���ܵ�����");
        }
    }
    public void FoundMagic(GameObject gb,int number)  //�ҵ����������¶���
    {
        if (gb.tag == "Mage")
        {
            for (int i = 0; i < enemyMagic.Length; i++)
            {
                if (enemyMagic[i] == gb)
                {
                    Reduce(enemyMagic[i], number);
                    Debug.Log("�ܵ���������Ϊ" + enemyMagic[i].name);
                    break;
                }
            }
        }
        else if (gb.tag == "Malphite")
        {
            for (int i = 0; i < enemyMalphite.Length; i++)
            {
                if (enemyMalphite[i] == gb)
                {
                    Reduce(enemyMalphite[i], number);
                    Debug.Log("�ܵ���������Ϊ" + enemyMalphite[i].name);
                    break;
                }
            }
        }
    }

    int wjhhh_EnemyRun_i = 0;
    public Transform[] enemyTypeBonAtTransform;//����λ��
    int enemyAmount = 10;//��������
    public float currentTime = 5f;//���ɼ��ʱ��
    public GameObject malphite;//ʯͷ��Ԥ����
    public void GenrerateEnemy()  //���ɵ���ʯͷ��
    {
        if (enemyAmount > 0)
        {
            for (int i = 0; i < enemyTypeBonAtTransform.Length; i++)
            {
                GameObject obj = Instantiate(malphite, enemyTypeBonAtTransform[i]);
                enemyMalphite[wjhhh_EnemyRun_i] = obj;
                wjhhh_EnemyRun_i++;
            }
            enemyAmount--;
        }
        Invoke("GenrerateEnemy", currentTime);
    }

    int wjhhh_EnemyMage_i = 0;
    
    public Transform[] enemyMageBonAtTransform;//����λ��
    int enemyMageTransformNumber = 0;
    public int enemyMageAmount = 10;//���ɴ���
    public float enemyIntervalMageTime = 5f;//���ɼ��ʱ��
    public GameObject mage;//��ʦԤ����

    public int enemyMageHameHame = 10;
    public GameObject enemyMageHame;
    public Vector2 hameTransform;
    public void GenrerateEnemyMage()  //���ɵ��˷�ʦ
    {
        //���ɷ�ʦhame
        for (int i = 0; i < enemyMageHameHame; i++)
        {
            //���ɶ�Ѩλ�������
            float hameX = Random.Range(hameTransform.x, hameTransform.y);
            float hameZ = Random.Range(hameTransform.x, hameTransform.y);
            float quaternion = Random.Range(0, 360);
            GameObject gb = Instantiate(enemyMageHame, new Vector3(hameX, 0, hameZ), Quaternion.Euler(90, quaternion, 90));
            enemyMageBonAtTransform[enemyMageTransformNumber] = gb.transform;

            GameObject obj = Instantiate(mage, enemyMageBonAtTransform[enemyMageTransformNumber]);
            enemyMagic[wjhhh_EnemyMage_i] = obj;
            wjhhh_EnemyMage_i++;
            

            enemyMageTransformNumber++;
        }

        //���ɷ�ʦ
        //if (enemyMageAmount > 0)
        //{
        //    for (int i = 0; i < enemyMageBonAtTransform.Length; i++)
        //    {
        //        GameObject obj = Instantiate(mage, enemyMageBonAtTransform[i]);
        //        enemyMagic[wjhhh_EnemyMage_i] = obj;
        //        wjhhh_EnemyMage_i++;
        //    }
        //}
        if (enemyMageAmount > 0)
        {
            Debug.Log(enemyMageAmount);
            enemyMageAmount--;
            Invoke("GenrerateEnemyMage", enemyIntervalMageTime);
        }
        

    }
}
