using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCountDwon : MonoBehaviour
{
    [SerializeField] int countDown = 3;
    [SerializeField] GameObject countDownText = null;
    [SerializeField] GameObject skill = null;


    int displayTimer = 0;
    float timer = 0;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        timer += Time.unscaledDeltaTime;

        displayTimer = countDown - (int)timer;


        Text timer_text = countDownText.GetComponent<Text>();
        timer_text.text = " " + displayTimer + " ";
        if (displayTimer == 0 )
        {
            Time.timeScale = 1;
            skill.SetActive(true);
            countDownText.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
