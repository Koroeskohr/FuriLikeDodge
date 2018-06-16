using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuriLikeDodge;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {


  public float speed = 180.0f;
  public float dashSpeed = 10000f;
  public int dashEndLag = 20;

  private Camera playerCamera;
  private Rigidbody rb;
  private Transform model;

  [ReadOnly]
  public int framesToAvailableDash = 0;

  private bool canMove = true;
  private bool canDash = true;

  // Use this for initialization
	void Start () {
    this.playerCamera = GetComponentInChildren<Camera>() ;
    this.rb = GetComponent<Rigidbody>();
    this.model = transform.Find("Model");
	}

  private void Update()
  {
    // FIXME : move to a "ThrottledAction" with an update to call here
    if (framesToAvailableDash > 0)
    {
      framesToAvailableDash--;
    }
  }

  void FixedUpdate () {
    float depthInput = Input.GetAxis("Vertical");
    float lateralInput = Input.GetAxis("Horizontal");

    bool dashPressed = Input.GetButtonDown("Dash");

    Vector3 cameraDirection = this.playerCamera.transform.forward;
    Vector3 cameraRight = this.playerCamera.transform.right;

    // == player.forward
    Vector3 depthDirection = ToPlanarVector(cameraDirection).normalized;
    // == player.right
    Vector3 lateralDirection = ToPlanarVector(cameraRight).normalized;

    Vector3 direction = (depthDirection + lateralDirection).normalized;

    // FIXME : move to function
    if (canMove)
    {
      Vector3 computedMovement = ComputeMovement(depthInput, lateralInput, depthDirection, lateralDirection);
      if (computedMovement.magnitude > 0.001)
      {
        Move(computedMovement);
      }
    }

    if (dashPressed && CanDash())
    {
      Dash(new NormalizedVector(model.forward), dashSpeed);
    }
	}

  private void Move(Vector3 force)
  {
    model.rotation = Quaternion.LookRotation(force);
    rb.AddForce(force);
  }

  private bool CanDash()
  {
    return canDash && framesToAvailableDash == 0;
  }

  private void Dash(NormalizedVector direction, float force)
  {
    rb.AddForce(direction.Value * force);
    framesToAvailableDash = dashEndLag;
  }

  private Vector3 ToPlanarVector(Vector3 vector)
  {
    return new Vector3(vector.x, 0, vector.z);
  }

  private Vector3 ComputeMovement(float dDepth, float dLateral, Vector3 depthDirection, Vector3 lateralDirection)
  {
    Vector3 depthForce = dDepth * depthDirection;
    Vector3 lateralForce = dLateral * lateralDirection;

    return (depthForce + lateralForce) * speed;
  }
}
