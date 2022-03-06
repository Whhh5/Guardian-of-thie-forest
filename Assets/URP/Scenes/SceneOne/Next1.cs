using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next1 : MonoBehaviour
{
    void Update()
    {
        
    }
    public void OnTriggerEnter()
    {
        SceneManager.LoadScene("SampleSceneTwo");
    }
}
