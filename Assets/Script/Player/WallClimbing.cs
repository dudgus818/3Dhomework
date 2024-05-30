using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimbing : MonoBehaviour
{
    public float climbSpeed = 5f;
    public float climbForce = 50f;
    public LayerMask wallLayer;

    private PlayerController controller;
    private Rigidbody rb;

    private Vector3 moveDirection;
    private Vector3 climbDirection;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // ĳ���� �̵� �Է� �ޱ�
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �̵� ���� ���
        moveDirection = new Vector3(horizontal, 0f, vertical);

        // ���� ��Ҵ��� Ȯ��
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, wallLayer))
        {
            // �� �������� �̵� ���� ����
            climbDirection = (hit.point - transform.position).normalized;

            // ���� ����� �� ������ ���� ����
            rb.AddForce(climbDirection * climbForce, ForceMode.Impulse);

            // ���� ���� ���¶��, ���� Ÿ�� �����ų� �Ŵ޸���
            if (controller.IsGrounded())
            {
                moveDirection = new Vector3(horizontal, 0f, vertical);
                moveDirection.y = climbSpeed;
            }
        }
        else
        {
            // ���� ���� ���� ���¶��, �Ϲ� �̵�
            moveDirection.y = 0f;
        }

        // �̵� ���� ����
      //  controller.Move(moveDirection * Time.deltaTime);
    }

}
