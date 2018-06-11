using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuriLikeDodge;

public class Player : MonoBehaviour {

  public float speed = 2.0f;

  private Camera playerCamera;
  private Rigidbody rb;
  
  // Use this for initialization
	void Start () {
    this.playerCamera = GetComponentInChildren<Camera>() ;
    this.rb = Helpers.GetComponentOrFail<Rigidbody>(this);
	}
	
	// Update is called once per frame
	void Update () {
    Vector3 cameraDirection = this.playerCamera.transform.forward;
    Vector3 cameraRight = this.playerCamera.transform.right;

    // == player.forward
    Vector3 depthDirection = ToPlanarVector(cameraDirection);
    // == player.right
    Vector3 lateralDirection = ToPlanarVector(cameraRight);

    Debug.DrawRay(transform.position, depthDirection, Color.green);
    Debug.DrawRay(transform.position, lateralDirection, Color.blue);

    float depthInput = Input.GetAxis("Vertical");
    float lateralInput = Input.GetAxis("Horizontal");

    Debug.Log(depthInput);
    Debug.Log(lateralInput);

    float dDepth = depthInput * speed;
    float dLateral = lateralInput * speed;

    Vector3 depthForce = dDepth * depthDirection;
    Vector3 lateralForce = dLateral * lateralDirection;

    rb.AddForce(depthForce + lateralForce);
	}

  private Vector3 ToPlanarVector(Vector3 vector)
  {
    return new Vector3(vector.x, 0, vector.z);
  }

  private void computeInputs (float dx, float dy)
  {

  }
}
