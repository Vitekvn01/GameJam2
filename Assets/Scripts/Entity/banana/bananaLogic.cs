using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananaLogic : MonoBehaviour
{
    private bool isCollected = false;
    private void OnTriggerEnter(Collider other)
    {
        // Проверка на столкновение с игроком
        if (other.CompareTag("Player") && !isCollected)
        {
            // Находим компонент PlayerLogic на объекте игрока
            PlayerLogic playerLogic = other.GetComponent<PlayerLogic>();

            // Проверяем, был ли найден компонент PlayerLogic
            if (playerLogic != null)
            {
                ScoreManager.Instance.AddCurrentCountBananas();
            }

            // Помечаем банан как собранный
            isCollected = true;

            // Уничтожаем банан после сбора
            Destroy(gameObject);
        }
    }
}
