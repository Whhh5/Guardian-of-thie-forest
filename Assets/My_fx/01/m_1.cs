using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_1 : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 6) //���˲�
        {
            GameObject.Find("DamageDate").GetComponent<DamageDate>().wjhhh_F_WhichWeapon(gameObject);
            GameObject.Find("DamageDate").GetComponent<DamageDate>().wjhhh_F_AlterHralth(other.gameObject);
            Debug.Log("����m_1����������");
        }
    }
}
