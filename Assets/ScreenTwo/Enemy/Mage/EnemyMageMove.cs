using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMageMove : MonoBehaviour
{
    public int health = 10;
    NavMeshAgent nav;
    Transform playerTr;
    Vector3 pos = new Vector3(0, 0, 0);
    Animator anima;
    float persentTime = 0f;
    
    public Vector2 activateInterval2;
    float activateInterval;

    float middle = 0;
    int activate = 0;
    void Start()
    {
        activateInterval = Random.Range(activateInterval2.x, activateInterval2.y);
        Debug.Log("��ǰ��������Ϊ" + activateInterval);
        nav = GetComponent<NavMeshAgent>();
        playerTr = GameObject.Find("Player").GetComponent<Transform>();
        anima = GetComponent<Animator>();
    }
    void Update()
    {
        persentTime += Time.deltaTime;

        IsAttack(); // ����

        Move();  //�ƶ�
    }
    void Move() //�ƶ�
    {
        if (!anima.GetBool("IsDie") && !anima.GetCurrentAnimatorStateInfo(0).IsName("EnemyMageServe1") && !anima.GetCurrentAnimatorStateInfo(0).IsName("EnemyMageServe2") && anima.GetBool("Activate"))
        {
            nav.SetDestination(playerTr.position);
        }
        else
        {
            Debug.Log("����ֹͣ");
            
        }
        if(Mathf.Sqrt(Mathf.Pow(transform.position.x - pos.x, 2) + Mathf.Pow(transform.position.y - pos.y, 2) + Mathf.Pow(transform.position.z - pos.z, 2)) == 0f && !anima.GetBool("IsDie") && anima.GetBool("Activate"))    //λ���Ƿ����仯  ����ʱ���Ƴ���
        {

            //Quaternion.Lerp(transform.rotation, playerTr.rotation, 0.5f);
            //Vector3 playtr = playerTr.right * playerTr.position.x + -playerTr.forward * playerTr.position.z;
            Vector3 playtr = new Vector3(playerTr.position.x, 0, playerTr.position.z);
            transform.LookAt(playtr);
            anima.SetFloat("Tree", 0);//�����˶�״̬
            nav.SetDestination(this.transform.position);
            Debug.Log("Mageվ������");
        }
        else    //�����仯
        {
            anima.SetFloat("Tree", 1);
        }
        pos = transform.position;
    }
    void IsAttack()   //�Ƿ񹥻�
    {
        if (!anima.GetBool("IsDie") && anima.GetBool("Activate"))
        {
            if (persentTime - middle >= activateInterval)
            {
                activate++;
                if (activate == 3)
                {
                    anima.SetTrigger("Attack2");
                    activate = 0;
                }
                else
                {
                    anima.SetTrigger("Attack1");
                }
                middle = persentTime;
            }
        }
    }
    public void IsDie()  //����Ƿ�����
    {
        if (health <= 0)  // �����¼�
        {
            anima.SetBool("IsDie", true);
            GetComponent<EnemyMageAnimationIncident>().IncidentMagicSphere(3);
            GetComponent<EnemyMageAnimationIncident>().enabled = false;
            GetComponent<EnemyMageMove>().enabled = false;
            Debug.Log("���˷�ʦ����");
        }
    }
    private void OnAnimatorMove()//��дanimayormove����   ���ö�����˶�
    {
        
    }
}
