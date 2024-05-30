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
        // 캐릭터 이동 입력 받기
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 이동 방향 계산
        moveDirection = new Vector3(horizontal, 0f, vertical);

        // 벽에 닿았는지 확인
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f, wallLayer))
        {
            // 벽 방향으로 이동 방향 설정
            climbDirection = (hit.point - transform.position).normalized;

            // 벽에 닿았을 때 물리적 반응 구현
            rb.AddForce(climbDirection * climbForce, ForceMode.Impulse);

            // 벽에 붙은 상태라면, 벽을 타고 오르거나 매달리기
            if (controller.IsGrounded())
            {
                moveDirection = new Vector3(horizontal, 0f, vertical);
                moveDirection.y = climbSpeed;
            }
        }
        else
        {
            // 벽에 닿지 않은 상태라면, 일반 이동
            moveDirection.y = 0f;
        }

        // 이동 방향 적용
      //  controller.Move(moveDirection * Time.deltaTime);
    }

}
