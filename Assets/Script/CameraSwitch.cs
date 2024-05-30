using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public KeyCode switchKey = KeyCode.V; // ī�޶� ��ȯ Ű ���� (��: V Ű)

    private void Start()
    {
        // �ʱ� ī�޶� ����: 1��Ī ī�޶� Ȱ��ȭ, 3��Ī ī�޶� ��Ȱ��ȭ
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);
    }

    private void Update()
    {
        // ��ȯ Ű�� ������ �� ī�޶� ��ȯ
        if (Input.GetKeyDown(switchKey))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // ī�޶� Ȱ��ȭ ���� ��ȯ
        bool isFirstPersonActive = firstPersonCamera.gameObject.activeSelf;
        firstPersonCamera.gameObject.SetActive(!isFirstPersonActive);
        thirdPersonCamera.gameObject.SetActive(isFirstPersonActive);
    }
}
