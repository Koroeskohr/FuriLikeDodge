using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuriLikeDodge;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour {

  public float speed = 2.0f;

  private Camera playerCamera;
  private Rigidbody rb;
  
  // Use this for initialization
	void Start () {
    this.playerCamera = GetComponentInChildren<Camera>() ;
    this.rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    float depthInput = Input.GetAxis("Vertical");
    float lateralInput = Input.GetAxis("Horizontal");

    Vector3 computedMovement = inputsToMovement(depthInput, lateralInput);
    rb.AddForce(computedMovement);
	}

  private Vector3 ToPlanarVector(Vector3 vector)
  {
    return new Vector3(vector.x, 0, vector.z);
  }

  private Vector3 inputsToMovement(float depthInput, float lateralInput)
  {
    Vector3 cameraDirection = this.playerCamera.transform.forward;
    Vector3 cameraRight = this.playerCamera.transform.right;

    // == player.forward
    Vector3 depthDirection = ToPlanarVector(cameraDirection);
    // == player.right
    Vector3 lateralDirection = ToPlanarVector(cameraRight);

    float dDepth = depthInput * speed;
    float dLateral = lateralInput * speed;

    Vector3 depthForce = dDepth * depthDirection;
    Vector3 lateralForce = dLateral * lateralDirection;

    return depthForce + lateralForce;
  }
}
