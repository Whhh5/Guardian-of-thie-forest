using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wjhhh_Camera_Move : MonoBehaviour
{
    public float speed;
    public Transform wjhhh_Player_Transform;

    public GameObject objectToFollow;   //�����Ŀ��
    public float followSpeed = 0.2f;    //�����ٶ�
    public Vector3 offset = new Vector3(0, 1.5f, -1.5f);   //һĿ��Ϊԭ���λ��

    //��ֵ����
    //�۲����
    public float distanceZ = 5f;
    public float distanceY = 2.2f;
    public Transform target;
    //��ȡ�������
    float mX = 0.0f;
    float mY = 0.0f;
    //�����������ת�Ƕ�
    public float MinLiMity = 5f;
    public float MaxLiMity = 180f;
    //�Ƿ����ò�ֵ
    public bool isNeedDamping = true;
    //�ٶ�
    public float Damping = 2.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceZ = distanceZ - Input.GetAxis("Mouse ScrollWheel") * 2;

        //transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position + offset, speed * Time.deltaTime);   //���ò�ֵ�������ƽ�������ٶ�

        if (Input.GetKeyDown(KeyCode.O))              //�������������
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyDown(KeyCode.P))              //��ʾ�����
        {
            Cursor.lockState = CursorLockMode.None;
        }

        ////��ȡ���λ����Ϣ
        //float hor = Input.GetAxis("Mouse X") * speed; 
        //float ver = Input.GetAxis("Mouse Y") * speed;

        //Vector3 forword = Quaternion.Euler(-ver, hor, 0) * Camera.main.transform.forward;
        //Camera.main.transform.rotation = Quaternion.LookRotation(forword, Vector3.up);
    }
    private void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, objectToFollow.transform.position + offset, speed * Time.deltaTime);


        //��ȡ�������
        mX += Input.GetAxis("Mouse X") * Damping * 0.02f;     //  +=
        mY -= Input.GetAxis("Mouse Y") * Damping * 0.02f;     //  -=

        //��Χ����
        mY = ClampAngle(mY, MinLiMity, MaxLiMity);

        //���¼���λ�úͽǶ�
        Quaternion mRotation = Quaternion.Euler(mY, mX, 0);
        Vector3 mPosition = mRotation * new Vector3(0.0f, distanceY, -distanceZ) + target.position;

        //�����������λ�úͽǶ�

        if (isNeedDamping)
        {
            //���β�ֵ
            transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * Damping);
            //���Բ�ֵ
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
