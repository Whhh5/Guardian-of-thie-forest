using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDate : MonoBehaviour
{
    public int wjhhh_Player_MaxHealth;
    public int wjhhh_Enemy_MaxHealth;
    
    public GameObject[] wjhhh_Arsenal;        //�������˺�������
    public int[] wjhhh_Arsenal_HarmDate;      //������Ӧ���˺���ֵ


    public GameObject wjhhh_HappenIsHarm_Weapon;//����˺�������
    public GameObject wjhhh_HappenIsHarm_Obj;  //���˺����Ķ���
    public int wjhhh_HappenIsHarm_Date;  //���˺�������ֵ

    public Enemy_Type wjhhh_Damage_C;
    public void wjhhh_F_WhichWeapon(GameObject weaponObj)      //�жϷ��������������˺�
    {
        int wjhhh_Weapon_Location = 0;
        for (int i = 0; i < wjhhh_Arsenal.Length; i++)
        {
            if (wjhhh_Arsenal[i] == weaponObj)
            {
                wjhhh_Weapon_Location = i;
            }
        }
        wjhhh_HappenIsHarm_Date = wjhhh_Arsenal_HarmDate[wjhhh_Weapon_Location];
    }
    public void wjhhh_F_AlterHralth(GameObject byHarmobj_DateF)       //��������ֵ
    {
        wjhhh_Damage_C.wjhhh_F_IndexesEnemy(byHarmobj_DateF, wjhhh_HappenIsHarm_Date);
    }
}
