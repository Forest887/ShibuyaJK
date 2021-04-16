﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject lastShape = null;
    [SerializeField] GameObject scoreText = null;
    [SerializeField] GameObject comboText = null;
    [SerializeField] GameObject timerText = null;
    [SerializeField] GameObject missMinus = null;
    [SerializeField] GameObject plus5 = null;
    [SerializeField] GameObject canvas = null;
    [SerializeField] GameObject timeOverUI = null;

    [SerializeField] int timeLimit = 60;
    [SerializeField] int missScore = 10;

    int timer = 0;
    float timerFloat = 0;
    int score = 0;
    int displayScore = 0;
    int combo = 0;
    int lastDeleteNum = 99;

    Text timer_text;
    Text score_text;
    Text combo_text;

    void Start()
    {
        timer = timeLimit;
        timer_text = timerText.GetComponent<Text>();
        score_text = scoreText.GetComponent<Text>();
        combo_text = comboText.GetComponent<Text>();
    }



    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            TimeOver();
        }
        timerFloat += Time.deltaTime;
        timer = timeLimit - (int)timerFloat;

        for (int i = 0; i < 4; i++)
        {
            if (displayScore < score)
            {
                displayScore++;
            }
            else if (displayScore > score)
            {
                displayScore--;
            }
        }

        timer_text.text = " 残り " + timer + "秒";
        score_text.text = displayScore.ToString() + "  ";
        if (combo == 0)
        {
            combo_text.text = " ";
        }
        else
        {
            combo_text.text = " コンボ " + combo + "  ";
        }

        if (scoreText.transform.localScale.x > 1)
        {
            float scale = scoreText.transform.localScale.x;
            scale -= 0.01f;
            scoreText.transform.localScale = new Vector3(scale, scale, 1);
        }

        if (comboText.transform.localScale.x > 1)
        {
            float scale = comboText.transform.localScale.x;
            scale -= 0.01f;
            comboText.transform.localScale = new Vector3(scale, scale, 1);
        }
    }

    void TimeOver()
    {
        Time.timeScale = 0;
        timeOverUI.SetActive(true);
    }

    /// <summary>
    /// 得点を加算する
    /// </summary>
    void AddScore(int num)
    {
        scoreText.transform.localScale *= 1.2f;
        comboText.transform.localScale *= 1.2f;

        // １コンボごとに１点貰える
        float comboP = 100 * ((float)combo / 100);

        // comboは1/10の点数が貰える（小数点以下切り捨て）
        //int comboP = combo / 10;

        score += 100 + (int)comboP;
        combo++;

        if (lastDeleteNum == num)
        {
            score += 5;
            Instantiate(plus5, canvas.transform);
        }
        lastDeleteNum = num;
    }

    /// <summary>
    /// shapeを受け取り同じものか違うものか判断し行動する
    /// </summary>
    /// <param name="shape">形</param>
    public void ShapeCheck(GameObject shape)
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!lastShape)// １回目の選択時
        {
            lastShape = shape;
            lastShape.transform.localScale *= 1.2f;// 選択時に大きくする
            Debug.Log("set");
        }
        else
        {
            GeneratorContoller shapeScript = shape.GetComponent<GeneratorContoller>();
            GeneratorContoller lastShapeScript = lastShape.GetComponent<GeneratorContoller>();
            int shapeNum = shapeScript.shapeNum;
            int lastShapeNum = lastShapeScript.shapeNum;

            // 同じ形を選択したとき
            if (shapeNum == lastShapeNum && lastShape != shape)
            {
                AddScore(shapeNum);

                Debug.Log("change");
                shapeScript.Change();
                lastShapeScript.Change();
                lastShape.transform.localScale = Vector3.one;
                lastShape = null;
            }
            else // 違う形を選択したとき
            {
                Debug.Log("lose");
                //
                //  失敗したときのスコアのマイナスを表示する
                Instantiate(missMinus, canvas.transform);
                score -= missScore;
                combo = 0;

                lastShape.transform.localScale = Vector3.one;
                lastShape = null;
            }
        }
    }
}
