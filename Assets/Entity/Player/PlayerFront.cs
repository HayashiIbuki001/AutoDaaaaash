using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFront : MonoBehaviour
{
    /// <summary>
    /// Player�{�̂�GameObject
    /// </summary>
    GameObject playerObject;
    void Start()
    {
        //�e�I�u�W�F�N�g���擾
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
        Debug.Log("�ǂɌ��˂���");
    }
}
