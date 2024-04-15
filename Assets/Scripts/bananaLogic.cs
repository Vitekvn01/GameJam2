using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaLogic : MonoBehaviour
{

    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        // �������� �� ������������ � �������
        if (other.CompareTag("Player") && !isCollected)
        {
            // ������� ��������� PlayerLogic �� ������� ������
            PlayerLogic playerLogic = other.GetComponent<PlayerLogic>();

            // ���������, ��� �� ������ ��������� PlayerLogic
            if (playerLogic != null)
            {
                playerLogic.BananaCollect();
            }

            // �������� ����� ��� ���������
            isCollected = true;

            // ���������� ����� ����� �����
            Destroy(gameObject);
        }
    }
}
