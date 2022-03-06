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


    public void Reduce(GameObject gb ,int number) //减少敌方血量
    {
        if (gb.tag == "Mage" && gb.GetComponent<EnemyMageMove>().health > 0)  //法师
        {
            gb.GetComponent<EnemyMageMove>().health -= number;
            gb.GetComponent<EnemyMageMove>().IsDie();
            Debug.Log("法师受到攻击");
        }
        else if (gb.tag == "Malphite" && gb.GetComponent<Enemys_DetectionOf>().health > 0)   //石头人
        {
            gb.GetComponent<Enemys_DetectionOf>().health -= number;
            gb.GetComponent<Enemys_DetectionOf>().wjhhh_F_IsDie();
            Debug.Log("石头人受到攻击");
        }
    }
    public void FoundMagic(GameObject gb,int number)  //找到被攻击道德对象
    {
        if (gb.tag == "Mage")
        {
            for (int i = 0; i < enemyMagic.Length; i++)
            {
                if (enemyMagic[i] == gb)
                {
                    Reduce(enemyMagic[i], number);
                    Debug.Log("受到攻击对象为" + enemyMagic[i].name);
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
                    Debug.Log("受到攻击对象为" + enemyMalphite[i].name);
                    break;
                }
            }
        }
    }

    int wjhhh_EnemyRun_i = 0;
    public Transform[] enemyTypeBonAtTransform;//生成位置
    int enemyAmount = 10;//生成数量
    public float currentTime = 5f;//生成间隔时间
    public GameObject malphite;//石头人预制体
    public void GenrerateEnemy()  //生成敌人石头人
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
    
    public Transform[] enemyMageBonAtTransform;//生成位置
    int enemyMageTransformNumber = 0;
    public int enemyMageAmount = 10;//生成次数
    public float enemyIntervalMageTime = 5f;//生成间隔时间
    public GameObject mage;//法师预制体

    public int enemyMageHameHame = 10;
    public GameObject enemyMageHame;
    public Vector2 hameTransform;
    public void GenrerateEnemyMage()  //生成敌人法师
    {
        //生成法师hame
        for (int i = 0; i < enemyMageHameHame; i++)
        {
            //生成洞穴位置随机数
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

        //生成法师
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
