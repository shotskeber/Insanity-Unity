using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Prime31;

public class PlayerMovement : MonoBehaviour {

	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	public float directionP = 1f;
	public bool _ladderInteract = false;
	public bool isHidden = false;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;

	private bool canMove = true;


	void Awake()
	{
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharController2D>();

		// listen to some events for illustration purposes
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
	}

	void Start(){
		runSpeed = 4f;
	}

	#region Event Listeners

	void onTriggerEnterEvent( Collider2D col )
	{
		//Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
	}

	#endregion


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
		
		if( _controller.isGrounded )
			_velocity.y = 0;

		if (Input.GetKey (KeyCode.LeftShift)) {
			runSpeed = 8f;
		} else {
			runSpeed = 4f;
		}

		if (Input.GetKeyDown (KeyCode.H)) {
			//_animator.SetTrigger("Hide");
		}

		if (Input.GetKeyDown (KeyCode.G)) {
			//_animator.SetTrigger("Fall");
		}

		if( Input.GetKey( KeyCode.RightArrow) && canMove)
		{
			normalizedHorizontalSpeed = 1;
			if (transform.localScale.x < 0f) {
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				directionP = 1;
			}
			//if (_controller.isGrounded) {
			//}
			if (runSpeed == 4f) {
				_animator.SetBool ("IsWalking", true);
				_animator.SetBool ("IsRunning", false);
				_animator.SetBool("IsStatic", false);
			} else {
				_animator.SetBool ("IsRunning", true);
				_animator.SetBool ("IsWalking", false);
				_animator.SetBool("IsStatic", false);
			}

		}
		else if( Input.GetKey( KeyCode.LeftArrow ) && canMove)
		{
			normalizedHorizontalSpeed = -1;
			if (transform.localScale.x > 0f) {
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				directionP = -1;
			}

			if (runSpeed == 4f) {
				_animator.SetBool ("IsWalking", true);
				_animator.SetBool ("IsRunning", false);
				_animator.SetBool("IsStatic", false);
			} else {
				_animator.SetBool ("IsRunning", true);
				_animator.SetBool ("IsWalking", false);
				_animator.SetBool("IsStatic", false);
			}
			//if( _controller.isGrounded ){}
			//_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else
		{
			normalizedHorizontalSpeed = 0;

			//if( _controller.isGrounded ){}
			//_animator.Play( Animator.StringToHash( "Idle" ) );
			_animator.SetBool ("IsWalking", false);
			_animator.SetBool ("IsWalking", false);
			_animator.SetBool("IsStatic", true);
		}
		// we can only jump whilst grounded




		// apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		// if holding down bump up our movement amount and turn off one way platform detection for a frame.
		// this lets us jump down through one way platforms
		if( _controller.isGrounded && Input.GetKey( KeyCode.DownArrow ))
		{
			_velocity.y *= 2f;
			_controller.ignoreOneWayPlatformsThisFrame = true;
		}

		_controller.move( _velocity * Time.deltaTime );

		// grab our current _velocity to use as a base for all calculations

		_velocity = _controller.velocity;
	}

	public void StopMovement(){
		canMove = false;
	}

	public void ActiveMovement(){
		canMove = true;
	}
}
