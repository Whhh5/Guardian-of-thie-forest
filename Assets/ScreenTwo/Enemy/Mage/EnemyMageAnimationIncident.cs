using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMageAnimationIncident : MonoBehaviour
{

    //法师对象
    public GameObject enemyMage;

    //法师法球
    public GameObject magicSphere;//预制体
    public Transform[] magicSphereTr;//生成位置
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
