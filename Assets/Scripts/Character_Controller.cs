using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject ShootPoint1;
    public GameObject ShootPoint2;

    private PlayerController controls;
    private Rigidbody body;
    private Animator animator;
    void Awake()
    {
        controls = new PlayerController();
        controls.Player.Jump.performed += _ => Jump();
        controls.Player.Shoot.performed += _ => Shoot();

        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }   

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-10, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Jump()
    {
        body.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
    }

    private bool isFirstPoint;
    private void Shoot()
    {
        if (isFirstPoint)
        {
            CreateBullet(ShootPoint1.transform.position);
        }
        else
        {
            CreateBullet(ShootPoint2.transform.position);
        }
        isFirstPoint = !isFirstPoint;
    }

    private void CreateBullet(Vector3 position)
    {
        var bullet = Instantiate(Bullet, position, Quaternion.identity);
        var bulletBody = bullet.GetComponent<Rigidbody>();
        bulletBody.AddForce(transform.forward * 15, ForceMode.Impulse);

        Destroy(bullet, 5f);
    }

    void FixedUpdate()
    {
        var moveDirection = controls.Player.Move.ReadValue<Vector2>();
        body.AddForce(new Vector3(moveDirection.x, 0, moveDirection.y)*3);
        animator.SetFloat("speed", body.velocity.magnitude);
        if(controls.Player.RotateLeft.ReadValue<float>() > 0.5f)
        {
            transform.Rotate(Vector3.up, -180 * Time.fixedDeltaTime);
        } 
        else
        if (controls.Player.RotateRight.ReadValue<float>() > 0.5f)
        {
            transform.Rotate(Vector3.up, 180 * Time.fixedDeltaTime);
        }
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
}
