using UnityEngine;


public class Player : MonoBehaviour, IDamageable
{
    public float speed = 5f;
    public float sensitivity = 2f;
    public Transform cam;
    float verticalRotation = 0f;
    public bool hasWeapon = false;
    public GameObject heldWeapon;

    Rigidbody rb;
    public void TakeDamage()
    {
        Debug.Log("Player Died");
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.transform.forward, out hit, 100f))
        {
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            if (target != null)
            {
                target.TakeDamage();
            }
        }
    }

    public void EquipWeapon()
    {
        hasWeapon = true;
        heldWeapon.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        Vector3 velocity = move * speed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        cam.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
        transform.Rotate(0, mouseX, 0);
        if (hasWeapon && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }
    
}
