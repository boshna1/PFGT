using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    [SerializeField, Range(1, 20)] private float mousesensX;
    [SerializeField, Range(1, 20)] private float mousesensY;

    [SerializeField, Range(0, 90)] private float maxViewAngle;
    [SerializeField, Range(-90, 0)] private float minViewAngle;

    [SerializeField] private Transform followTarget;

    [SerializeField] private Rigidbody bullet;
    [SerializeField] private float bulletForce;

    private Vector2 currentAngle;

    private Rigidbody rb;

    GameObject currentGun;

    public GameObject Sniper;
    public GameObject Shotgun;

    float FireRate;
    string WeaponType;
    bool disableShoot;

    void Start()
    {
        InputManager.Init(myPlayer: this);
        InputManager.SetGameControls();

        rb = GetComponent<Rigidbody>();

        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * ((Vector3)(speed * Time.deltaTime * _moveDirection));
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

    public void SetLookRotation(Vector2 Readvalue)
    {

        currentAngle.x += Readvalue.x * Time.deltaTime * mousesensX;
        currentAngle.y += Readvalue.y * Time.deltaTime * mousesensY;
        currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle);

        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector2.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector2.right);
    }

    public void Shoot()
    {
        if (disableShoot == false && WeaponType == "Sniper")
        {
            Rigidbody currentBullet = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), followTarget.rotation);
            disableShoot = true;
            currentBullet.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            Destroy(currentBullet, 4);
            Invoke("EnableShoot", FireRate);
        }
        if (disableShoot == false && WeaponType == "Shotgun")
        {
            Rigidbody currentBullet = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), (followTarget.rotation * new Quaternion(10,10,0,0)));
            Rigidbody currentBullet2 = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), followTarget.rotation * new Quaternion(10, -10, 0, 0));
            Rigidbody currentBullet3 = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), followTarget.rotation * new Quaternion(10, 10, 0, 0));
            Rigidbody currentBullet4 = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), followTarget.rotation * new Quaternion(-10, 10, 0, 0));
            Rigidbody currentBullet5 = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), followTarget.rotation * new Quaternion(-10, -10, 0, 0));
            Rigidbody currentBullet6 = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), followTarget.rotation * new Quaternion(10, 0, 0, 0));
            Rigidbody currentBullet7 = Instantiate(bullet, transform.position + new Vector3(0, 0.2f), followTarget.rotation * new Quaternion(-10, 0, 0, 0));
            disableShoot = true;
            currentBullet.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            currentBullet2.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            currentBullet3.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            currentBullet4.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            currentBullet5.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            currentBullet6.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            currentBullet7.AddForce(followTarget.forward * bulletForce, ForceMode.Impulse);
            Destroy(currentBullet, 2);
            Destroy(currentBullet2, 2);
            Destroy(currentBullet3, 2);
            Destroy(currentBullet4, 2);
            Destroy(currentBullet5, 2);
            Destroy(currentBullet6, 2);
            Destroy(currentBullet7, 2);
            Invoke("EnableShoot", FireRate);
        }
    }

    public void SwitchSniper()
    {
        Destroy(currentGun);
        currentGun = Instantiate(Sniper, Cow, false);
        FireRate = 2;
        WeaponType = "Sniper";
        DisplayText.instance.SwitchSniper();
    }

    public void SwitchShotgun()
    {
        Destroy(currentGun);
        currentGun = Instantiate (Shotgun, Cow, false);
        FireRate = 1.5f;
        WeaponType = "Shotgun";
        DisplayText.instance.SwitchShotgun();
    }

    public void EnableShoot()
    {
        disableShoot = false;
    }

    public bool GetDisableShoot()
    {
        return disableShoot;
    }

    public string GetWeaponType()
    {
        return WeaponType;
    }
       
}

