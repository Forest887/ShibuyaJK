using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject lastShape = null;
    int score = 0;
    int combo = 0;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    /// <summary>
    /// 得点を加算する
    /// </summary>
    void AddScore()
    {
        combo++;
    }

    /// <summary>
    /// shapeを受け取り同じものか違うものか判断し行動する
    /// </summary>
    /// <param name="shape">形</param>
    public void ShapeCheck(GameObject shape)
    {
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
                AddScore();

                Debug.Log("change");
                shapeScript.Change();
                shapeScript.Stars();
                lastShapeScript.Change();
                lastShapeScript.Stars();
                lastShape.transform.localScale = Vector3.one;
                lastShape = null;
            }
            else // 違う形を選択したとき
            {
                Debug.Log("lose");
                lastShape.transform.localScale = Vector3.one;
                lastShape = null;
            }
        }
    }
}
