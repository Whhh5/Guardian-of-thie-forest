using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMageBossMove : MonoBehaviour
{
    public int health = 100;

    //����ű�
    NavMeshAgent nav;
    Animator anima;

    //���
    GameObject player;

    //����ģ��
    public GameObject smailMage;

    //NavMeshAgent ����
    public float navSpeed = 8;

    //��ǰʱ��
    float currentTime = 0;
    float attackIntervalTime = 0;

    //�������ű�
    EnemyType damageDate2;

    //�Ƿ񼤻�
    bool isActivate = false;
    bool a = false;

    void Start()
    {
        damageDate2 = GameObject.Find("DamageDate2").GetComponent<EnemyType>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        nav.speed = navSpeed;
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        JiHuo();

        IsDie();
    }
    void JiHuo()
    {
        if (IsActivate())
        {
            Move();
            Bag();






            if (!a)
            {
                GetComponent<AudioSource>().Play();
                ActivateIncident();
                a = true;
            }

            



            for (int i = 0; i < damageDate2.enemyMagic.Length; i++)
            {
                if (damageDate2.enemyMagic[i] != null)
                {
                    if (damageDate2.enemyMagic[i].transform.GetChild(5))
                    {
                        if (damageDate2.enemyMagic[i].transform.GetChild(5).GetComponent<Light>().intensity >= 0)
                        {
                            damageDate2.enemyMagic[i].transform.GetChild(5).GetComponent<Light>().intensity -= 0.2f * Time.deltaTime;
                        }

                    }
                }
            }
        }
    }


    void Bag()
    {
        if (currentTime - attackIntervalTime >= 10)
        {
            for (int i = 0; i < Random.Range(1, 5); i++)
            {
                Attack();
            }
            attackIntervalTime = currentTime;
        }

        if (transform.localScale.x < 10)
        {
            transform.localScale += new Vector3(0.2f, 0.2f, 0.2f) * Time.deltaTime;
            health = 100;
        }


        if (transform.GetChild(0).GetComponent<Light>().intensity <= 300)
        {
            transform.GetChild(0).GetComponent<Light>().intensity += 20 * Time.deltaTime;
        }
    }

    int mageNumber = 599;
    void Attack()  //����
    {
        //����Сħ��ʦ
        GameObject gb = Instantiate(smailMage, this.transform);
        gb.transform.parent = null;
        gb.transform.localScale = new Vector3(1, 1, 1);
        damageDate2.enemyMagic[mageNumber] = gb;
        mageNumber--;
    }

    void AnimatorIncident()  //�����¼�
    {

    }

    void IsByAttact()  //�������¼�
    {

    }

    void Move()  //�ƶ�
    {
        if (player.GetComponent<Wjhhh_Player_Move>().health > 0)
        {
            nav.SetDestination(player.transform.position);
        }
        else
        {
            nav.SetDestination(this.transform.position);
        }
    }

    bool IsActivate()  //�Ƿ񼤻�
    {
        //����Ƿ��й���
        for (int i = 0; i < damageDate2.enemyMagic.Length; i++)
        {
            if (damageDate2.enemyMagic[i] != null)
            {
                if (damageDate2.enemyMagic[i].GetComponent<EnemyMageMove>().health > 0)
                {
                    return isActivate;
                }
            }
        }
        isActivate = true;
        bossVolume.GetComponent<BoosBloodVolume>().isAction = true;
        Debug.Log("Boss����");
        return isActivate;
    }
    public GameObject bossVolume;
    public GameObject mageSphere;
    void ActivateIncident()  //�����¼�
    {
        //����Сħ��ʦ����
        for (int i = 0; i < damageDate2.enemyMagic.Length; i++)
        {
            if (damageDate2.enemyMagic[i] != null)
            {
                if (damageDate2.enemyMagic[i].transform.GetChild(5))
                {
                    Instantiate(mageSphere, damageDate2.enemyMagic[i].transform.position + new Vector3(0,2f,0),Quaternion.Euler(0,0,0));
                }
            }
        }
    }

    void IsDie()  //�Ƿ�����
    {
        if (health <= 0)
        {
            Debug.Log("���سɹ�");
            Time.timeScale = 0;
        }
    }
}
