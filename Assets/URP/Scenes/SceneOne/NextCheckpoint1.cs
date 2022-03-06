using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCheckpoint1 : MonoBehaviour
{
    public EnemyType enemyType;
    public GameObject next;
    public Text enemyMaxQuantity;
    public Text enemyNowQuantity;

    private void Start()
    {

    }


    void Update()
    {
        EnemyQuantity(); //µÐÈËÊýÄ¿

        a();
    }
    void a()
    {
        for (int i = 0; i < enemyType.enemyMalphite.Length; i++)
        {
            if (enemyType.enemyMalphite[i])
            {
                if (enemyType.enemyMalphite[i].GetComponent<Enemys_DetectionOf>().health > 0)
                {
                    return;
                }
            }
        }
        next.SetActive(true);
    }

    void EnemyQuantity()
    {
        int enemyQuantity = 0;
        for (int i = 0; i < enemyType.enemyMalphite.Length; i++)
        {
            if (enemyType.enemyMalphite[i])
            {
                if (enemyType.enemyMalphite[i].GetComponent<Enemys_DetectionOf>().health > 0)
                {
                    enemyQuantity++;
                }
            }
        }
        enemyNowQuantity.text = enemyQuantity.ToString();
    }
}
