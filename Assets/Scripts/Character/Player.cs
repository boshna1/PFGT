using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject Sphere;
    public Transform Cow;
    public Quaternion CowR;
    [SerializeField] private float speed;
    private Vector3 _moveDirection;
    private bool isGrounded;
    [SerializeField] private float jumpforce;

    private Rigidbody rb;
    
    void Start()
    {
        InputManager.Init(myPlayer:this,Sphere,CowR,Cow);
        InputManager.SetGameControls();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(speed * Time.deltaTime * _moveDirection);
        CheckGrounded();
    }

    public void SetMovementDirection(Vector3 currentDireciton)
    {
        _moveDirection = currentDireciton;
        
    }

    public void SetJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
        
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.size.y);
        Debug.DrawRay(transform.position, Vector3.down * GetComponent<Collider>().bounds.size.y, Color.green, 0, false);
    }
    
}
