using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 10f; // �����밡 ���ϴ� ���� ũ��

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ��ü�� Rigidbody�� ����
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        // �浹�� ��ü�� Rigidbody�� �ִ��� Ȯ��
        if (rb != null)
        {
            Debug.Log("������");
            // Rigidbody�� �������� ���� ����
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
