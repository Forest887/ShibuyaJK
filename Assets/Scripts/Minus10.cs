using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minus10 : MonoBehaviour
{
    int maxCount = 20;
    int count = 0;

    private void FixedUpdate()
    {
        count++;
        if (maxCount <= count)
        {
            Destroy(this.gameObject);
        }
    }
}
