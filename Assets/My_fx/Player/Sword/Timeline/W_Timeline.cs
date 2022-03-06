using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class W_Timeline : MonoBehaviour
{
    public PlayableDirector timeline;
    public TimelineAsset[] timelins;
    public ParticleSystem playerSkill_Q;
    public ParticleSystem playerSkill_E;
    public ParticleSystem playerSkill_R;
    public ParticleSystem playerSkill_T;
    public ParticleSystem playerSkill_y;
    AudioSource audioSource;
    public AudioClip[] audioClip;


    public void Action_A()
    {
        timeline.Play(timelins[4]);
    }
    public void Stop_A()
    {
        if (GameObject.Find("Player").GetComponent<Animator>().GetBool("SkillABool"))
        {

        }
        else
        {
            timeline.time = timeline.duration;
        }
    }
    public void PlayerSkill_Q()
    {
        Debug.Log("按下Q技能");
    }
    public void PlayerSkill_E(int musicNumber = 1)
    {
        playerSkill_E.Play();
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClip[musicNumber];
        audioSource.Play();
    }
    public void PlayerSkill_R(int musicNumber = 2)
    {
        playerSkill_R.Play();
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClip[musicNumber];
        audioSource.Play();
    }
    public void PlayerSkill_T(int musicNumber = 3)
    {
        playerSkill_T.Play();
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClip[musicNumber];
        audioSource.Play();
    }

    public void Stating2()
    {
        GameObject.Find("Sword").GetComponent<AudioSource>().Play();
    }
}
