using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatinRotation : MonoBehaviour
{
    float h;
    float v;
    Vector3 bd_CamForward;
    public Transform bd_CamTransform;
    public float bd_TurnSpeed;
    public Vector3 tr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        W_Ray();
        transform.LookAt(tr);
    }
    private void Move()
    {
        h = Input.GetAxis("Mouse Y");
        v = Input.GetAxis("Mouse X");
        Rotating(h, v);

    }
    void Rotating(float hh, float vv)
    {
        bd_CamForward = Vector3.Cross(bd_CamTransform.right, Vector3.up);
        Vector3 taroetDir = bd_CamTransform.right * hh + bd_CamForward * vv;

        Quaternion targetRotation = Quaternion.LookRotation(taroetDir, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, bd_TurnSpeed * Time.deltaTime);
    }

    void W_Ray()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit infohit;
        if (Physics.Raycast(ray,out infohit))
        {
            tr = infohit.point;
        }
    }
}
