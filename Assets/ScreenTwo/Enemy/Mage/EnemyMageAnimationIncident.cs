using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageAnimationIncident : MonoBehaviour
{

    //��ʦ����
    public GameObject enemyMage;

    //��ʦ����
    public GameObject magicSphere;//Ԥ����
    public Transform[] magicSphereTr;//����λ��
    private void Update()
    {
        
    }
    public void IncidentMagicSphere(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject gb = Instantiate(magicSphere, magicSphereTr[i]);
            gb.transform.parent = null;
            Destroy(gb, 70f);
        }
    }
}
