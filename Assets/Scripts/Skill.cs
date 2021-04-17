using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    GameObject[] shapegenerators;
    GameManager gMScript;
    GameObject gameManager;
    GeneratorContoller generatorContoller;

    int changeShapeNum = 1000;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gMScript = gameManager.GetComponent<GameManager>();
        shapegenerators = GameObject.FindGameObjectsWithTag("PuzzleShape");
    }

    public void UseSkill()
    {
        //　時間を止めて形を２個選択しひとつめを二つ目の形に変える
        //　時間を止める
        Time.timeScale = 0;
        //　ゲームマネージャーに知らせる
        gMScript.UseSkill();
        //　選択する
        //　形を変える
        //
    }
    public void Choice(GameObject shape)
    {
        generatorContoller = shape.GetComponent<GeneratorContoller>();
        if (changeShapeNum > 99)
        {
            changeShapeNum = generatorContoller.shapeNum;
        }
        else
        {
            ChangeShape(generatorContoller.shapeNum);
        }
    }

    void ChangeShape(int changeNum)
    {
        for (int i = 0; i < shapegenerators.Length; i++)
        {

        }
    }
}
