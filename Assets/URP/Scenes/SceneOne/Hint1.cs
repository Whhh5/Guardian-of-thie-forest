using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint1 : MonoBehaviour
{
    public Sprite[] hint;
    public Image hit;
    int number = 0;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void Next()
    {
        if (number == hint.Length)
        {
            hit.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            hit.sprite = hint[number];
            number++;
        }
    }

}
