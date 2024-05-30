using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public KeyCode switchKey = KeyCode.V; // 카메라 전환 키 설정 (예: V 키)

    private void Start()
    {
        // 초기 카메라 설정: 1인칭 카메라 활성화, 3인칭 카메라 비활성화
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        // 전환 키가 눌렸을 때 카메라 전환
        if (Input.GetKeyDown(switchKey))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // 카메라 활성화 상태 전환
        bool isFirstPersonActive = firstPersonCamera.gameObject.activeSelf;
        firstPersonCamera.gameObject.SetActive(!isFirstPersonActive);
        thirdPersonCamera.gameObject.SetActive(isFirstPersonActive);
    }
}
