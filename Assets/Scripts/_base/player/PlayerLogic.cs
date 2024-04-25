using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private float speed = 150.0f; // скорость
    [SerializeField] private float rotationSpeed = 120.0f; // скорость поворота
    [SerializeField] private float jumpForce = 10.0f; // высота прыжка

    Rigidbody rb;

    public Camera playerCamera; // Ссылка на камеру
    [SerializeField] private float cameraRotationSpeed = 2.0f; // Скорость вращения камеры
    private float mouseX;
    private float mouseY;
    private bool isJumping;

    [SerializeField] private GameObject ViewMonkey;
    [SerializeField] private GameObject ViewSecretCustom;

    private Animator animator;
    [SerializeField] private RuntimeAnimatorController controllerAvatarSecretCustom;
    [SerializeField] private Avatar avatarSecretCustom;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        jumpForce *= rb.mass;
    }

    private void Update()
    {
        if (ScoreManager.Instance.SecretCustomOpen)
        {
            animator.runtimeAnimatorController = controllerAvatarSecretCustom;
            ViewMonkey.SetActive(false);
            ViewSecretCustom.SetActive(true);
            animator.avatar = avatarSecretCustom;
        }
        mouseX = Input.GetAxis("Mouse X") * cameraRotationSpeed;
        mouseY = Input.GetAxis("Mouse Y") * cameraRotationSpeed;
    }

    void FixedUpdate()
    {

        float movementDir = Input.GetAxisRaw("Vertical");
        float rotatiomDir = Input.GetAxisRaw("Horizontal");

        Vector3 movement = transform.forward * movementDir * speed;
        Vector3 gravity = new Vector3(0, rb.velocity.y, 0);

        if (Input.GetAxisRaw("Jump") > 0 && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            animator.SetTrigger("jump");
        }

        if (movementDir != 0)
        {
            animator.SetBool("run", true);
        }
        else animator.SetBool("run", false);

        rb.velocity = movement + gravity;
        transform.Rotate(Vector3.up * Time.fixedDeltaTime * rotatiomDir * rotationSpeed);
    }



    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
