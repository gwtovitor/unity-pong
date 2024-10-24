using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    public float speed = 5f;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {

        spriteRenderer.color = SaveController.Instance.colorEnemy;

    }

    private void Update()
    {
        float moveInput = 0;
        if (Input.GetKey(KeyCode.W))
        {
            moveInput = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveInput = -1;
        }

        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        transform.position = newPosition;

    }

}
