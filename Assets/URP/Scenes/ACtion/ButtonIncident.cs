using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonIncident : MonoBehaviour
{
    public void Next1()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
