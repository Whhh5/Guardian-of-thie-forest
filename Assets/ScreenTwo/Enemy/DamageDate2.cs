using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDate2 : MonoBehaviour
{
    public GameObject[] weaponType;
    public int[] weaponHarm;

    public int FoundWeapon(GameObject gb)  // �ҵ����𹥻�������  �����ع�����ֵ
    {
        for (int i = 0; i < weaponType.Length; i++)
        {
            if (weaponType[i] == gb)
            {
                return weaponHarm[i];
            }
        }
        return 1;
    }
}
