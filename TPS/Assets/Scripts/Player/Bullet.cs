using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 2f; // �����܂ł̑ҋ@���ԁi�b�j

    void Start()
    {
        // �w��b���Destroy���\�b�h���Ăяo���Ď������g�i����Bullet�I�u�W�F�N�g�j����������
        Destroy(gameObject, destroyDelay);
    }
}
