using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFront : MonoBehaviour
{
    /// <summary>
    /// Player本体のGameObject
    /// </summary>
    GameObject playerObject;
    void Start()
    {
        //親オブジェクトを取得
        playerObject = transform.parent.gameObject;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround();
        }
    }

    void isGround()
    {
        Destroy(playerObject);
        Debug.Log("壁に激突した");
    }
}
