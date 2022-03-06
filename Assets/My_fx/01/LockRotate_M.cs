using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotate_M : MonoBehaviour
{
    public GameObject obj;                             //生成的对象
    public Transform tran;                             //生成位置
    public int numberOfReflection;                    //发射次数
    public int numberOfReflection_Action;           //发射次数初始值
    public float timeBetweenLaunches;                 //发射间隔时间
    private float time_M;                              //发射间隔时间
    public float length;                               //可以被攻击的距离
    public int l_i = 0;                                //存储到的位置
    public GameObject[] l = new GameObject[100];       //存储所有生成的能量预制体

    public GameObject[] enemy_S;                       //敌人数组

    
    private void Start()
    {
        time_M = 0;

        enemy_S = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy_S.Length; i++)
        {
            Debug.Log(enemy_S[i].name);
        }

        
    }
    private void Update()
    {
        

        time_M += Time.deltaTime;
        fUp();

    }
    private void FixedUpdate()
    {
        enemy_S = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy_S.Length; i++)
        {
            if (Mathf.Sqrt(Mathf.Pow(transform.position.x - enemy_S[i].transform.position.x, 2f) + Mathf.Pow(transform.position.y - enemy_S[i].transform.position.y, 2f) + Mathf.Pow(transform.position.z - enemy_S[i].transform.position.z, 2f)) < length)
            {
                transform.LookAt(enemy_S[i].transform);
            }
        }
        Launch();
    }
    void fUp()
    {
        for (int i = 0; i < enemy_S.Length; i++)
        {
            if (Mathf.Sqrt(Mathf.Pow(transform.position.x - enemy_S[i].transform.position.x, 2f) + Mathf.Pow(transform.position.y - enemy_S[i].transform.position.y, 2f) + Mathf.Pow(transform.position.z - enemy_S[i].transform.position.z, 2f)) < length)
            {
                transform.LookAt(enemy_S[i].transform);
            }
        }
        Launch();
    }
    private void Launch()
    {
        if (numberOfReflection_Action < numberOfReflection)
        {
            if (time_M >= timeBetweenLaunches)
            {
                for (int i = 0; i < enemy_S.Length; i++)
                {
                    if (Mathf.Sqrt(Mathf.Pow(transform.position.x - enemy_S[i].transform.position.x, 2f) + Mathf.Pow(transform.position.y - enemy_S[i].transform.position.y, 2f) + Mathf.Pow(transform.position.z - enemy_S[i].transform.position.z, 2f)) < length)
                    {
                        GameObject instance = Instantiate(obj, tran);
                        instance.transform.LookAt(enemy_S[i].transform);
                        l[l_i] = instance;
                        l_i++;
                    }
                }
                time_M = 0f;
                Invoke("DisDel", 100f);
                numberOfReflection_Action++;
            }
        }
    }
    void DisDel()
    {
        for (int i = 0;  i < l.Length; i++)
        {
            GameObject.Destroy(l[i]);
        }
        l_i = 0;
    }
}
