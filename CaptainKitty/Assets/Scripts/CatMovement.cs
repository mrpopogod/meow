﻿using UnityEngine;

public class CatMovement
{

    Animator catAnimator; 
    //private int jumpTimer = 0;
    private Rigidbody _rb;
    private bool _isJumping;
    private bool _isFalling;
    private bool _isActing = false;
    Transform _transform;

    private GameObject _firePrefab = null;
    private float _fireRate = 1.5f;
    private float _fireLife = 1.0f;
    private float _nextFire;

    private GameObject _waterPrefab = null;
    private float _waterRate = 0.05f;
    private float _waterLife = 3.0f;
    private float _nextWater;

    private float movementSpeed = 5.0f;
    private float sprintSpeed = 10.0f;
    private float rotationSpeed = 200.0f;
    private float jumpSpeed = 6.0f;

    public bool canFire = false;
    public bool canWind = false;
    public bool canWater = false; //sprint

    private GameObject _windPrefab = null;
	private GameObject _wind = null;

    public bool inWater { get; set; }
    

    public CatMovement(Rigidbody rb, Animator animator, Transform transform, GameObject firePrefab, GameObject windPrefab, GameObject waterPrefab)
    {
        _rb = rb;
        catAnimator = animator;
        _isJumping = false;
        _isFalling = false;
        _transform = transform;
        _firePrefab = firePrefab;
		_windPrefab = windPrefab;
        _waterPrefab = waterPrefab;
    }

    public void UnlockWater()
    {
        canWater = true;
        //TODO: Play a sound!
        //TODO: Open a dialog
    }

    public void UnlockFire()
    {
        canFire = true;
        //TODO: Play a sound!
        //TODO: Open a dialog
    }
    public void UnlockWind()
    {
        canWind = true;
        //TODO: Play a sound!
        //TODO: Open a dialog
    }

    private void HandleFlames()
    {
        if (canFire)
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

                catAnimator.SetBool("Meow", true);
                _isActing = true;
            }
            else if (Input.GetKey("f") == false && Time.time > _nextFire)
            {
                //GameObject.Destroy(_wind);
                //_wind = null;
                catAnimator.SetBool("Meow", false);
                _isActing = false;
            }
        }
    }
    private void Blow()
    {
        
        Vector3 position = this._transform.position;
        position.y += 0.5f;
        float distanceToBlow = 5.0f;
        Vector3 rotation = this._transform.TransformDirection(Vector3.forward) * distanceToBlow;// * 10.0f;//this._transform.rotation.eulerAngles;

        //check if there is a BlowableInteractable within X distance (along the ray-traced direction)

        RaycastHit[] hits = Physics.RaycastAll(position, rotation, 5.0f);//_rb.position + this._transform.forward * -0.1f/*+ rotation * 0.1f*/, rotation, 1.5f);//, LayerMask.GetMask("Puzzle"));//, false);
                                                                         //Debug.Log("Trying to blow an interactable"+hits+" "+hits.Length+" in dir: "+rotation.ToString());
        Debug.DrawRay(position, rotation, Color.yellow, 2.0f, false);

        if ((hits != null) && (hits.Length > 0))//.collider != null)
        {
            
            foreach (RaycastHit target in hits)
            {
                
                Debug.Log("Raycast has hit the object " + target.collider.gameObject);
                BlowableInteractable targetsInteractable = target.collider.GetComponent<BlowableInteractable>();
                //TODO: call those objects' functions to move them
                if (targetsInteractable != null) targetsInteractable.BlowWithForce(rotation*((distanceToBlow - target.distance)/distanceToBlow));
            }

        }
        catAnimator.SetBool("Meow", true);
        _isActing = true;
    }
    private void HandleWind()
    {
        if (canWind)
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
                catAnimator.SetBool("Meow", false);
                _isActing = false;
            }

            if (_wind != null)
            {
                Blow();
            }
        }
    }

    public void Update () {
        HandleFlames();
        HandleWind();
        var speed = movementSpeed;
        if (canWater)
        {
            if (Input.GetKey("left shift") || Input.GetKey("right shift"))
            {
                speed = sprintSpeed;

                //_nextFire = Time.time + _fireRate;
                if ((_waterPrefab != null)&& (Time.time > _nextWater))
                {
                    _nextWater = Time.time + _waterRate;

                    var pos = this._transform.position;// new Vector3(0, 0.0f, 0.0f);
                    //pos.x -= 1.0f;
                    var rot = this._transform.rotation;//Quaternion.Euler(0.0f, 0, 0); //
                    var water = GameObject.Instantiate(_waterPrefab);//, _transform);
                    water.transform.localRotation = rot;
                    water.transform.position = pos;
                    GameObject.Destroy(water, _waterLife);

                    //catAnimator.SetBool("Meow", true);
                    //_isActing = true;
                }
            }
        }
        if (_isActing == true)
        {
            speed = 0f;
        }
        
        
        //NEW code
        float horizontal = Input.GetAxis("Horizontal"); //how much the cat should turn local left or right
        float vertical = Input.GetAxis("Vertical"); //how much "forward" the cat should go
        Vector3 rotationVector = new Vector3(0, horizontal*rotationSpeed, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.deltaTime);//new Quaternion(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0f, 1f);

        Vector3 position = _rb.position;
        
        float moveDistance = Input.GetAxis("Vertical") * Time.deltaTime * speed;
       
        _rb.MovePosition((_rb.position)+(_transform.forward * moveDistance));// (1-Input.GetAxis("Horizontal")));//(Input.GetAxis("Horizontal") * speed * Time.deltaTime));
        _rb.MoveRotation(_rb.rotation * deltaRotation);
        //END NEW code

        catAnimator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
        catAnimator.SetFloat("MoveY", Input.GetAxis("Vertical"));
        //Vertical is actually just the speed, so set Animator Speed directly to Vertical

        
        //if Fire 1 (jump) is pressed
        if (Input.GetAxis("Jump") > 0.0f && !_isJumping && !inWater)
        {
            catAnimator.SetBool("Jump", true);
            _isJumping = true;
            _rb.velocity = new Vector3(_rb.velocity.x, jumpSpeed, _rb.velocity.z);
        }

        if (_rb.velocity.y < 0 && _isJumping && !_isFalling)
        {
            _isFalling = true;
        }

        if (Mathf.Abs(_rb.velocity.y) < 0.01 && _isFalling)
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