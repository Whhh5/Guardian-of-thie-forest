using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.Rendering;

public class Wjhhh_Player_Move : MonoBehaviour
{
    public int health;

    public Transform wjhhh_FollowCamera;
    public float addForceSpeed = 100f;
    
    Rigidbody rigid;
    Animator anima;
    float blendF = 0f;
    float blendFlyF = 0f;
    float blend_IsFly;
    float presenteTime = 0;
    public bool isGround = true;
    float v;
    float h;

    public Vector3 mDir;

    public PlayableDirector timeline;
    public TimelineAsset[] timelins;
    //其他对象
    public Animator wjhhh_FlameProjecter;
    public GameObject[] wjhhh_FlameProjecter_GB;
    public Animator wjhhh_HandGun; //手炮
    public ParticleSystem[] par;//剑技能一
    bool isSkill = false;
    public GameObject DowmLight;//光环
    public Animator addition_01;//攻击加成动画
    public GameObject addition_Light;
    float addition_01_Time = 0;
    public GameObject A;
    public GameObject FSkill;
    public GameObject[] Stating_0;



    //受伤效果
    int nowBloud = 0;
    Volume volume;
    void Start()
    {
        nowBloud = health;

        volume = GameObject.Find("Post-process Volume").GetComponent<Volume>();
        anima = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        rigid.interpolation = RigidbodyInterpolation.Interpolate;
        wjhhh_FollowCamera = GameObject.Find("Main Camera").transform;
    }

    //百度转身脚本变量
    public float bd_Speed = 6;
    public float bd_TurnSpeed = 15;
    public Transform bd_CamTransform;
    Vector3 bd_MoveMent;
    Vector3 bd_CamForward;

    //射线发射位置
    public GameObject wjhhh_Ray;
    void Update()
    {
        ReduceBloud(); // 受伤效果

        presenteTime += Time.deltaTime;

        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.C) && isSkill)
        {
            anima.SetTrigger("RollTrigger");
        }


        //状态切换
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anima.SetInteger("Stating", 1);
            wjhhh_HandGun.SetInteger("Stating", 1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            anima.SetInteger("Stating", 0);
            for (int i = 0; i < Stating_0.Length; i++)
            {
                Stating_0[i].SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anima.SetInteger("Stating", 2);
            if (timeline.state != PlayState.Playing)
            {
                timeline.Play(timelins[1]);
            }
        }
        else if(anima.GetInteger("Stating") != 1)
        {
            wjhhh_HandGun.SetInteger("Stating", 0);
        }
        else if(anima.GetInteger("Stating") != 2)
        {
            for (int i = 0; i < Stating_0.Length; i++)
            {
                Stating_0[i].SetActive(false);
            }
        }

        //加成
        if (Input.GetKeyDown(KeyCode.G))
        {
            addition_01.SetBool("Addition_Stating", true);
            addition_01_Time = presenteTime;
            addition_Light.SetActive(true);
        }
        if (addition_01.GetBool("Addition_Stating"))
        {
            if (presenteTime - addition_01_Time >= 20)
            {
                addition_01.SetBool("Addition_Stating", false);
                addition_Light.SetActive(false);
            }
        }


        //技能
        if (Input.GetKeyDown(KeyCode.E) && addition_01.GetBool("Addition_Stating"))
        {
            isSkill = false;
            anima.SetTrigger("SkillOneTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            isSkill = false;
            anima.SetTrigger("SkillTwoTrigger");
        }
        else if (Input.GetKeyDown(KeyCode.R) && addition_01.GetBool("Addition_Stating"))
        {
            isSkill = false;
            anima.SetTrigger("SkillThreeTrigger");
        }
        else if (Input.GetKey(KeyCode.T) && anima.GetInteger("Stating") != 0 && addition_01.GetBool("Addition_Stating"))
        {
            rigid.AddForce(transform.up * 1.1f, ForceMode.Impulse);
            isSkill = false;
            anima.SetBool("SkillFour",true);
        }
        else if(Input.GetMouseButton(0) && anima.GetInteger("Stating") != 0 && anima.GetInteger("Stating") != 1)
        {
            isSkill = false;
            anima.SetBool("SkillABool", true);
        }
        else if(Input.GetKeyDown(KeyCode.Y))
        {
            Transform t = transform;
            GameObject a = Instantiate(FSkill, t);
            a.transform.parent = null;
        }
        else
        {
            isSkill = true;
            anima.SetBool("SkillFour",false);
            anima.SetBool("SkillABool", false);
        }

        
        //移动控制
        if (Input.GetAxis("Horizontal") != 0 && isSkill)
        {
            Move();
            blendF += 0.01f;
            anima.SetFloat("Blend Y", blendF);
            if (blendF > blend_IsFly)
            {
                blendF = blend_IsFly;
            }
        }

        if (Input.GetKey(KeyCode.Space) && anima.GetInteger("Stating") == 2 && isSkill)
        {
            transform.Translate(Vector3.up * 5 * Time.deltaTime);
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            anima.SetTrigger("JumpTrigger");
        }
        if (Input.GetKey(KeyCode.LeftShift) && isSkill)
        {
            
            if (blendFlyF > 1)
            {
                blendFlyF = 1;
            }
            blendFlyF += 0.01f;
            blend_IsFly = 1;
            if (anima.GetInteger("Stating") == 0)
            {
                wjhhh_FlameProjecter.SetFloat("Blend", blendFlyF);
            }
        }
        else
        {
            if (blendFlyF < 0)
            {
                blendFlyF = 0;
            }
            if (isGround == true)
            {
                blendFlyF -= 0.1f;
                blend_IsFly = 0.5f;
                if (anima.GetInteger("Stating") == 0)
                {
                    wjhhh_FlameProjecter.SetFloat("Blend", blendFlyF);
                }
            }
        }
        if (Input.GetAxis("Vertical") != 0 && isSkill)
        {
            blendF += 0.01f;
            anima.SetFloat("Blend Y", blendF);
            if (blendF > blend_IsFly)
            {
                blendF = blend_IsFly;
            }

            if (!Input.GetKey(KeyCode.LeftAlt))
            {
                Move();
            }
            if (Input.GetKey(KeyCode.LeftShift) && anima.GetInteger("Stating") == 0)
            {
                rigid.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
                if (!wjhhh_FlameProjecter_GB[0].GetComponent<ParticleSystem>().isPlaying)
                {
                    for (int i = 0; i < wjhhh_FlameProjecter_GB.Length; i++)
                    {
                        wjhhh_FlameProjecter_GB[i].GetComponent<ParticleSystem>().Play();
                    }
                }
                
            }
            else if(!isGround)
            {
                for (int i = 0; i < wjhhh_FlameProjecter_GB.Length; i++)
                {
                    wjhhh_FlameProjecter_GB[i].GetComponent<ParticleSystem>().Stop();
                }
                rigid.AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);
            }
            mDir = new Vector3(wjhhh_FollowCamera.transform.position.x, 0f, wjhhh_FollowCamera.transform.position.z);
        }
        else if (isGround == true)
        {
            blendF -= 0.2f;
            anima.SetFloat("Blend Y", blendF);
            if (blendF <= 0)
            {
                blendF = 0;
            }
        }
        if (isGround == false && !Input.GetKey(KeyCode.T))
        {
            Vector3 v3 = transform.forward * 4 + -transform.up;
            rigid.AddForce(v3, ForceMode.Impulse);
            DowmLight.SetActive(false);
        }
        else
        {
            DowmLight.SetActive(true);
        }
        IsDie();
        Ply();
    }
    private void FixedUpdate()
    {

    }
    private void Move()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        if (h!=0 || v!=0)
        {
            Rotating(h, v);
        }
        
    }
    void Rotating(float hh,float vv)
    {
        bd_CamForward = Vector3.Cross(bd_CamTransform.right, Vector3.up);
        Vector3 taroetDir = bd_CamTransform.right * hh + bd_CamForward * vv;

        Quaternion targetRotation = Quaternion.LookRotation(taroetDir, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, bd_TurnSpeed * Time.deltaTime);
    }
    void Ply()
    {
        Ray ray = new Ray(wjhhh_Ray.transform.position, -transform.up);//从摄像机发出到点击坐标的射线
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject gameObj = hitInfo.collider.gameObject;
            float tr = hitInfo.distance;
            if (gameObj.layer == 7)//当射线碰撞目标
            {
                if (tr > 0.5f)
                {
                    isGround = false;
                    anima.SetBool("IsGround", false);
                }
                else
                {
                    isGround = true;
                    anima.SetBool("IsGround", true);
                }
            }
        }
    }
    public void IsDie()
    {
        if (health <= 0)
        {
            Debug.Log("玩家死亡");
            anima.SetBool("IsDie", true);
        }
    }

    void ReduceBloud()  //受伤效果
    {
        if (nowBloud != health)
        {
            List<VolumeComponent> list = volume.profile.components;
            list[2].parameters[0].SetValue(new ColorParameter(Color.Lerp(Color.black,Color.red, 1f)));
            Invoke("Answr", 1f);
            nowBloud = health;
        }
    }
    void Answr()
    {
        List<VolumeComponent> list = volume.profile.components;
        list[2].parameters[0].SetValue(new ColorParameter(Color.Lerp(Color.red,Color.black, 1f)));

        //List<VolumeComponent> list = volume.profile.components;
        //list[2].parameters[0].SetValue(new ColorParameter(new Color(0,0,0)));

    }
}
