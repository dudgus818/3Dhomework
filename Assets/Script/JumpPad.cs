using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; // 점프대가 가하는 힘의 크기

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한 객체의 Rigidbody를 얻어옴
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        // 충돌한 객체에 Rigidbody가 있는지 확인
        if (rb != null)
        {
            Debug.Log("점프함");
            // Rigidbody에 순간적인 힘을 가함
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
