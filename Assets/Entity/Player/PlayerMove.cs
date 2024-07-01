using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// Player�ɕt���Ă���Rigidbody
    /// </summary>
    private Rigidbody2D PlayerRb;

    public float speed;
    public float jumpPower;

    /// <summary>
    /// 2�i�W�����v���ł��邩�؂�ւ���
    /// </summary>
    private bool jumpTrigger;

    /// <summary>
    /// ���݂̃W�����v��
    /// </summary>
    private int jumpTime;

    // Start is called before the first frame update

    void Start()
    {
        //Rigidbody2D���擾
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
    /// �J�n����Player�̓���
    /// </summary>
    void StartMove()
    {
        //PlayerRb�ɗ͂�������
        PlayerRb.AddForce(Vector2.right * speed * 10);
    }
    /// <summary>
    /// �W�����v�{�^�����������Ƃ��̃v���C���[�̓���
    /// </summary>
    void PlayerJump()
    {
        if (jumpTrigger == true)
        {
            if (jumpTime < 2)
            {
                //PlayerRb�ɗ͂�������
                PlayerRb.AddForce(Vector2.up * jumpPower * 10);

                //�W�����v�񐔂�1�ǉ�
                jumpTime += 1;
            }

            if (jumpTime == 2)
            {
                jumpTrigger = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //��i�W�����v�̐ݒ�
        if (collision.gameObject.tag == "Ground")
        {
            //2�i�W�����vON
            jumpTrigger = true;
            jumpTime = 0;
        }
    }
}
