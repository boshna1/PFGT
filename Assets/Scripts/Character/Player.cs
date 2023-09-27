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
    float x, y, z;
    void Start()
    {
        InputManager.Init(myPlayer:this,Sphere,x,y,z,CowR,Cow);
        InputManager.SetGameControls();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(speed * Time.deltaTime * _moveDirection);
        x = Cow.transform.position.x;
        y = Cow.transform.position.y;
        z = Cow.transform.position.z;
    }

    public void SetMovementDirection(Vector3 currentDireciton)
    {
        _moveDirection = currentDireciton;
    }

    public void SetJump(Vector3 currentDireciton)
    {
        _moveDirection = currentDireciton;
    }
    
}
