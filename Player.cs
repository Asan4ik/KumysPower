using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SerializeField] private float speed = 3f; // �������� ������������ ������
    [SerializeField] private float sprintSpeed = 5f; // ������
    // [SerializeField] private float stamina = 10f;
    private Rigidbody2D rb; // ��������� Rigidbody2D ������
    private Vector2 movement; // ������ �������� ������
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isLocalPlayer) return;
        // �������� ���� �� ������
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // ��������� ������ ��������
        movement = new Vector2(moveX, moveY).normalized;
        anim.SetFloat("HorizontalMove", moveX);
        anim.SetFloat("VerticalMove", moveY);
        //Flip();
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0) transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (Input.GetAxis("Horizontal") > 0) transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift)) rb.MovePosition(rb.position + movement * (speed + sprintSpeed) * Time.fixedDeltaTime);
        else rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}