using UnityEngine;

public class CatMovement
{

    Animator catAnimator; 
    //private int jumpTimer = 0;
    private Rigidbody _rb;
    private bool _isJumping;
    private bool _isFalling;
    Transform _transform;

    private GameObject _firePrefab = null;
    private float _fireRate = 1.5f;
    private float _fireLife = 1.0f;
    private float movementSpeed = 5.0f;
    private float sprintSpeed = 10.0f;
    private float rotationSpeed = 200.0f;
    private float jumpSpeed = 6.0f;
    private float _nextFire;

	private GameObject _windPrefab = null;
	private GameObject _wind = null;

    public CatMovement(Rigidbody rb, Animator animator, Transform transform, GameObject firePrefab, GameObject windPrefab)
    {
        _rb = rb;
        catAnimator = animator;
        _isJumping = false;
        _isFalling = false;
        _transform = transform;
        _firePrefab = firePrefab;
		_windPrefab = windPrefab;
    }

    private void HandleFlames()
    {
        if (Input.GetKey("f") && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            var pos = new Vector3(0, 0.5f, 0.5f);
            var rot = Quaternion.Euler(90f, 0, 0);
            var fire = GameObject.Instantiate(_firePrefab, _transform);
            fire.transform.localRotation = rot;
            fire.transform.localPosition = pos;
            GameObject.Destroy(fire, _fireLife);
        }
    }

    private void HandleWind()
    {
        if (Input.GetKey("e") == true && _wind == null)
        {
			var pos = new Vector3(0, 0.5f, 0.5f);
            var rot = Quaternion.Euler(0f, 0, 0);
            _wind = GameObject.Instantiate(_windPrefab, _transform);
            _wind.transform.localRotation = rot;
            _wind.transform.localPosition = pos;
        }
		else if (Input.GetKey("e") == false && _wind != null)
		{
			GameObject.Destroy(_wind);
			_wind = null;
		}
    }

    public void Update () {
        HandleFlames();
        HandleWind();
        var speed = movementSpeed;
        if (Input.GetKey("left shift") || Input.GetKey("right shift"))
        {
          speed = sprintSpeed;
        }

        //transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0);
        //transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        
        //NEW code
        float horizontal = Input.GetAxis("Horizontal"); //how much the cat should turn local left or right
        float vertical = Input.GetAxis("Vertical"); //how much "forward" the cat should go
        Vector3 rotationVector = new Vector3(0, horizontal*rotationSpeed, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.deltaTime);//new Quaternion(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0f, 1f);

        Vector3 position = _rb.position;

        //position.Scale = position.magnitude + 3.0f * vertical * Time.deltaTime * speed;
        //position.x = position.x + 3.0f * vertical * Time.deltaTime * speed;
        //position.y = position.y + 3.0f * vertical * Time.deltaTime * speed;

        //Move forward in the translate direction
        //if (Input.GetAxis("Horizontal"))
        float moveDistance = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        //Vector3 rotation = transform.forward;//new Vector3(_rb.rotation.y, 0, 0);


        /*if (Input.GetAxis("Vertical") != 0)
        {
            //Debug.Log("Moving at speed: " + Input.GetAxis("Vertical")*Time.deltaTime*speed);
            moveDistance = Input.GetAxis("Vertical")*Time.deltaTime*speed*50;
            
        }*/
  
        _rb.MovePosition((_rb.position)+(_transform.forward * moveDistance));// (1-Input.GetAxis("Horizontal")));//(Input.GetAxis("Horizontal") * speed * Time.deltaTime));
        _rb.MoveRotation(_rb.rotation * deltaRotation);
        //END NEW code

        catAnimator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        catAnimator.SetFloat("MoveY", Input.GetAxis("Vertical"));
        //Vertical is actually just the speed, so set Animator Speed directly to Vertical

        
        //if Fire 1 (jump) is pressed
        if (Input.GetAxis("Jump") > 0.0f && !_isJumping)
        {
            catAnimator.SetBool("Jump", true);
            _isJumping = true;
            _rb.velocity = new Vector3(_rb.velocity.x, jumpSpeed, _rb.velocity.z);
        }

        if (_rb.velocity.y < 0 && _isJumping && !_isFalling)
        {
            _isFalling = true;
        }

        if (Mathf.Abs(_rb.velocity.y) < 0.001 && _isFalling)
        {
            _isFalling = false;
            _isJumping = false;
            catAnimator.SetBool("Jump", false);
        }
        //Debug.Log("Speed = " + (_rb.velocity.magnitude / Time.deltaTime));
        catAnimator.SetFloat("Speed", Mathf.Abs(moveDistance)/Time.deltaTime);// Mathf.Abs(moveDistance));// Input.GetAxis("Vertical")));//(Mathf.Abs(Input.GetAxis("Horizontal")* speed) + (Mathf.Abs(Input.GetAxis("Vertical")* speed))));
        //test
    }

}