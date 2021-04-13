using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    int count = 0;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int x = Random.Range(-10, 11);
        int y = Random.Range(2, 6);
        Debug.Log(x + "" + y);
        rb.AddForce(new Vector2(x / 5, y),ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        count++;
        if (count > 20)
        {
            Destroy(this.gameObject);
        }
    }
}
