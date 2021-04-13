using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    Vector2 clickPosition = Vector2.zero;

    [SerializeField] GameObject gameManager = null;
    GameManager gM;

    void Start()
    {
        gM = gameManager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // クリックした位置を記録する
        {
            clickPosition = Input.mousePosition;
            //Debug.Log("Down" + Input.mousePosition);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            float dist = (clickPosition - (Vector2)Input.mousePosition).magnitude;
            if (dist > 40) // クリックしてから放す際に大きく移動していたらキャンセルする
            {
                //Debug.Log(dist);
                return;
            }
            //Debug.Log("UP" + Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction); // 2D マウスのポジションからRayを投げて何かに当たったらhitに入れる
            
            // クリックしたものがshapeのとき
            if (hit && hit.collider.gameObject.tag == "PuzzleShape")
            {
                GameObject shape = hit.collider.gameObject;
                gM.ShapeCheck(shape);
            }
        }
    }
}
