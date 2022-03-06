using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            GameObject.Find("DamageDate").GetComponent<DamageDate>().wjhhh_F_WhichWeapon(gameObject);
            GameObject.Find("DamageDate").GetComponent<DamageDate>().wjhhh_F_AlterHralth(other.gameObject);
            Debug.Log("ÎäÆ÷m_2¹¥»÷µ½µÐÈË");
        }
    }
}
