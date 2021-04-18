using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    GameObject[] shapegenerators;
    GameManager gMScript;
    GameObject gameManager;
    GeneratorContoller generatorContoller;

    Button button;
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip = null;

    GameObject lastShape;
    //float timer = 0;

    int changeShapeNum = 1000;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager");
        gMScript = gameManager.GetComponent<GameManager>();
        audioSource = gameManager.GetComponent<AudioSource>();
        shapegenerators = GameObject.FindGameObjectsWithTag("PuzzleShape");
    }

    //private void FixedUpdate()
    //{
    //    if (timer > 20)
    //    {
    //        button.interactable = true;
    //    }
    //    else
    //    {
    //        timer += Time.deltaTime;
    //    }
    //}

    public void UseSkill()
    {
        button.interactable = false;
        //timer = 0;
        audioSource.PlayOneShot(audioClip[2]);
        //　時間を止めて形を２個選択しひとつめを二つ目の形に変える
        //　時間を止める
        Time.timeScale = 0;
        //　ゲームマネージャーに知らせる
        gMScript.UseSkill(true);
        //
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shape"></param>
    public void Choice(GameObject shape)
    {
        generatorContoller = shape.GetComponent<GeneratorContoller>();
        if (changeShapeNum > 99)
        {
            audioSource.PlayOneShot(audioClip[0]);
            lastShape = shape;
            lastShape.transform.localScale *= 1.25f;
            changeShapeNum = generatorContoller.shapeNum;
        }
        else
        {
            audioSource.PlayOneShot(audioClip[1]);
            //　形を変える
            lastShape.transform.localScale = Vector3.one;
            ChangeShape(generatorContoller.shapeNum);
        }
    }

    void ChangeShape(int changeNum)
    {
        for (int i = 0; i < shapegenerators.Length; i++)
        {
            generatorContoller = shapegenerators[i].GetComponent<GeneratorContoller>();
            if (changeShapeNum == generatorContoller.shapeNum)
            {
                generatorContoller.Change(changeNum);
            }
        }

        gMScript.UseSkill(false);
        changeShapeNum = 1000;
        Time.timeScale = 1;
    }
}
