using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// Playerに付いているRigidbody
    /// </summary>
    private Rigidbody2D PlayerRb;

    public float speed;
    public float jumpPower;
    public float secondJumpPower;

    /// <summary>
    /// 2段ジャンプができるか切り替える
    /// </summary>
    private bool jumpTrigger;

    /// <summary>
    /// 現在のジャンプ回数
    /// </summary>
    private int jumpTime;

    // Start is called before the first frame update

    void Start()
    {
        //Rigidbody2Dを取得
        PlayerRb = GetComponent<Rigidbody2D>();

        StartMove();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerJump();
        }
    }

    /// <summary>
    /// 開始時のPlayerの動作
    /// </summary>
    void StartMove()
    {
        //PlayerRbに力を加える
        PlayerRb.AddForce(Vector2.right * speed * 10);
    }
    /// <summary>
    /// ジャンプボタンを押したときのプレイヤーの動作
    /// </summary>
    void PlayerJump()
    {
        if (jumpTrigger == true)
        {
            //一段目
            if (jumpTime == 0)
            {
                //PlayerRbに力を加える
                PlayerRb.AddForce(Vector2.up * jumpPower * 10);

                //ジャンプ回数を1追加
                jumpTime += 1;
            }
            //二段目
            else if (jumpTime == 1)
            {
                //PlayerRbに力を加える
                PlayerRb.AddForce(Vector2.up * jumpPower * 10 * secondJumpPower);

                //ジャンプ回数を1追加
                jumpTime += 1;
            }
            //二段ジャンプ後
            else if (jumpTime == 2)
            {
                jumpTrigger = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //二段ジャンプの設定
        if (collision.gameObject.tag == "Ground")
        {
            //2段ジャンプON
            jumpTrigger = true;
            jumpTime = 0;
        }
    }
}
