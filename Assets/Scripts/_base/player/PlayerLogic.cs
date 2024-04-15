using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    public int score = 0; // ���-�� �������
    public TextMeshProUGUI textScore;

    float speed = 15.0f; // ��������
    float rotationSpeed = 120.0f; // �������� ��������

    public float jumpHeight = 10.0f; // ������ ������

    Rigidbody rb;

    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;

        updateBananaScore();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.velocity = new Vector3(0, CalculateJumpSpeed(), 0);
            isJumping = true;
        }
        if (isJumping)
        {
            // ����������� �������� �������
            rb.velocity += Vector3.down * 40 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // ������� ������� �����
            transform.Rotate(Vector3.up * Time.deltaTime * -rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // ������� ������� ������
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }

    }

    float CalculateJumpSpeed()
    {
        // ������������ �������� ������ �� ������ �������� ������
        float gravity = Physics.gravity.magnitude;
        float jumpSpeed = Mathf.Sqrt(2 * gravity * jumpHeight);
        return jumpSpeed;
    }


    public void BananaCollect()
    {
        score++;
        updateBananaScore();
    }

    void updateBananaScore()
    {
        textScore.text = "" + score.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
