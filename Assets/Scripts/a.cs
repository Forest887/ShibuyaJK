using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
    [SerializeField] GameObject[] stars = null;
    void Start()
    {
        
    }

    public void Stars()
    {
        int i = Random.Range(0, stars.Length);
        Instantiate(stars[i]);
    }
}
