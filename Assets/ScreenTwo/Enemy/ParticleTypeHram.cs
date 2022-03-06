using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTypeHram : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.layer == 6) //���˲�
        {
            int number;
            number = GameObject.Find("DamageDate2").GetComponent<DamageDate2>().FoundWeapon(gameObject);
            GameObject.Find("DamageDate2").GetComponent<EnemyType>().FoundMagic(other.gameObject,number);

            //��Ƶ
            GameObject gb = new GameObject("AudioSource");
            gb.AddComponent<AudioSource>();
            AudioSource audioSource = gb.GetComponent<AudioSource>();
            audioSource.clip = GameObject.Find("Player").GetComponent<W_Timeline>().audioClip[5];
            audioSource.Play();

            Debug.Log("��������������");
        }
    }
}
