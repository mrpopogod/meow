using UnityEngine;

public class CatMovement : MonoBehaviour
{

    Animator catAnimator; 
    private int jumpTimer = 0;
    private Rigidbody _rb;
    private bool _isJumping;
    private bool _isFalling;

    public void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _isJumping = false;
        _isFalling = false;
    }

    [SerializeField] public float movementSpeed = 5.0f;
    [SerializeField] public float sprintSpeed = 10.0f;
    [SerializeField] public float rotationSpeed = 200.0f;
    [SerializeField] public float jumpSpeed = 6.0f;

    void Update () {
        var speed = movementSpeed;
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
          speed = sprintSpeed;
        }

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        catAnimator = GetComponent<Animator>();
        catAnimator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        catAnimator.SetFloat("MoveY", Input.GetAxis("Vertical"));
        catAnimator.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Horizontal")* speed) + (Mathf.Abs(Input.GetAxis("Vertical")* speed))));

        //if Fire 1 (jump) is pressed
        if (Input.GetAxis("Jump") > 0.0f && !_isJumping)
        {
            Debug.Log("Someone pressed jump and we're not jumping already");
            catAnimator.SetBool("Jump", true);
            _isJumping = true;
            _rb.velocity = new Vector3(_rb.velocity.x, jumpSpeed, _rb.velocity.z);
            //transform.Rotate(0, jumpSpeed * Time.deltaTime * rotationSpeed, 0);
            //transform.Translate(0, jumpSpeed * Time.deltaTime, 0);//Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
        }

        if (_rb.velocity.y < 0)
        {
            Debug.Log("Setting is falling to true");
            _isFalling = true;
        }

        if (_rb.velocity.y == 0 && _isFalling)
        {
            Debug.Log("Setting is falling to false and is jumping to false");
            _isFalling = false;
            _isJumping = false;
            catAnimator.SetBool("Jump", false);
        }

        //if (Input.GetAxis("Jump") == 0.0f)
        //{
        //    catAnimator.SetBool("Jump", false);
        //}
    }

}