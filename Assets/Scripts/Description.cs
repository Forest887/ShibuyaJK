using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField] GameObject[] panels = null;

    int panelNum = 0;

    public void Plus()
    {
        if (panelNum != panels.Length - 1)
        {
            panelNum++;
        }
        Change();
    }

    public void Mminus()
    {
        if (panelNum != 0)
        {
            panelNum--;
        }
        Change();
    }

    void Change()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
        panels[panelNum].SetActive(true);
    } 
}
