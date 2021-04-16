using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorContoller : MonoBehaviour
{
    [SerializeField] GameObject[] stars = null;
    [SerializeField] GameObject[] shape = null;
    GameObject nowShape;
    public int shapeNum;

    void Start()
    {
        shapeNum = Random.Range(0, shape.Length);
        nowShape = Instantiate(shape[shapeNum], this.transform);
    }


    void Update()
    {

    }

    /// <summary>
    /// 形を変える
    /// </summary>
    public void Change()
    {
        Stars();
        Destroy(nowShape);
        int i = Random.Range(0, shape.Length - 1);
        if (i >= shapeNum)
        {
            i++;
        }
        shapeNum = i;
        nowShape = Instantiate(shape[shapeNum], this.transform);
    }

    /// <summary>
    /// 星を生成する
    /// </summary>
    public void Stars()
    {
        for (int i = 0; i < 3; i++)
        {
            int a = Random.Range(0, stars.Length);
            Instantiate(stars[a], this.transform);
        }
    }
}
