using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    [SerializeField] private float speedRotation;

/*    private void Start()
    {
        ScoreManager.Instance.AddBananaInListAllBanans(this);
    }*/
    private void Update()
    {
        transform.Rotate(Vector3.up * speedRotation * Time.deltaTime);
    }
}
