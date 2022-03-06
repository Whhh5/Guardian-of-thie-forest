using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wjhhh_Camera_Move : MonoBehaviour
{
    public float speed;
    public Transform wjhhh_Player_Transform;

    public GameObject objectToFollow;   //跟随的目标
    public float followSpeed = 0.2f;    //运算速度
    public Vector3 offset = new Vector3(0, 1.5f, -1.5f);   //一目标为原点的位置

    //插值运算
    //观察距离
    public float distanceZ = 5f;
    public float distanceY = 2.2f;
    public Transform target;
    //获取鼠标输入
    float mX = 0.0f;
    float mY = 0.0f;
    //限制摄像机旋转角度
    public float MinLiMity = 5f;
    public float MaxLiMity = 180f;
    //是否启用插值
    public bool isNeedDamping = true;
    //速度
    public float Damping = 2.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceZ = distanceZ - Input.GetAxis("Mouse ScrollWheel") * 2;

        //transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position + offset, speed * Time.deltaTime);   //利用插值运算计算平滑跟随速度

        if (Input.GetKeyDown(KeyCode.O))              //隐藏锁定摄像机
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.P))              //显示摄像机
        {
            Cursor.lockState = CursorLockMode.None;
        }

        ////获取鼠标位置信息
        //float hor = Input.GetAxis("Mouse X") * speed; 
        //float ver = Input.GetAxis("Mouse Y") * speed;

        //Vector3 forword = Quaternion.Euler(-ver, hor, 0) * Camera.main.transform.forward;
        //Camera.main.transform.rotation = Quaternion.LookRotation(forword, Vector3.up);
    }
    private void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position + offset, speed * Time.deltaTime);


        //获取鼠标输入
        mX += Input.GetAxis("Mouse X") * Damping * 0.02f;     //  +=
        mY -= Input.GetAxis("Mouse Y") * Damping * 0.02f;     //  -=

        //范围限制
        mY = ClampAngle(mY, MinLiMity, MaxLiMity);

        //重新计算位置和角度
        Quaternion mRotation = Quaternion.Euler(mY, mX, 0);
        Vector3 mPosition = mRotation * new Vector3(0.0f, distanceY, -distanceZ) + target.position;

        //设置摄像机的位置和角度

        if (isNeedDamping)
        {
            //球形插值
            transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * Damping);
            //线性插值
            transform.position = Vector3.Lerp(transform.position, mPosition, Time.deltaTime * Damping * 0.1f);
        }
        else
        {
            transform.rotation = mRotation;
            transform.position = mPosition;
        }
    }
    float ClampAngle(float angle,float min,float max)
    {
        if (angle < -360)
        {
            angle += 360;
            if (angle > -360)
            {
                angle -= 360;
            }
        }

        return Mathf.Clamp(angle,min,max);
    }
}
