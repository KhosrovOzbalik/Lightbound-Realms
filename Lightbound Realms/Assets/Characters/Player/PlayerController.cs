using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveCharacter();
        HandleSkills();
    }

    void MoveCharacter()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void HandleSkills()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Skill 1 Activated");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Skill 2 Activated");
        }
    }
}