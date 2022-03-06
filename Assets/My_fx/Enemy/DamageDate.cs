using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDate : MonoBehaviour
{
    public int wjhhh_Player_MaxHealth;
    public int wjhhh_Enemy_MaxHealth;
    
    public GameObject[] wjhhh_Arsenal;        //所有物伤害型武器
    public int[] wjhhh_Arsenal_HarmDate;      //武器对应的伤害数值


    public GameObject wjhhh_HappenIsHarm_Weapon;//造成伤害的武器
    public GameObject wjhhh_HappenIsHarm_Obj;  //被伤害到的对象
    public int wjhhh_HappenIsHarm_Date;  //被伤害到的数值

    public Enemy_Type wjhhh_Damage_C;
    public void wjhhh_F_WhichWeapon(GameObject weaponObj)      //判断发出攻击的武器伤害
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
    public void wjhhh_F_AlterHralth(GameObject byHarmobj_DateF)       //减少生命值
    {
        wjhhh_Damage_C.wjhhh_F_IndexesEnemy(byHarmobj_DateF, wjhhh_HappenIsHarm_Date);
    }
}
