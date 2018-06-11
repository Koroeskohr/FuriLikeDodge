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
 
    // == player.forward
    Vector3 planarDirection = new Vector3(cameraDirection.x, 0, cameraDirection.z).normalized;

    Quaternion planarDirectionRight = Quaternion.Euler(planarDirection) * Quaternion.Euler(0, 90, 0);
    Vector3 pdrAsVec3 = planarDirectionRight.eulerAngles.normalized;

    Debug.Log(planarDirection);
    Debug.Log(planarDirectionRight);

    Debug.DrawRay(transform.position, planarDirection, Color.green);
    Debug.DrawRay(transform.position, pdrAsVec3, Color.blue);

    float depthInput = Input.GetAxis("Horizontal");
    float lateralInput = Input.GetAxis("Vertical");

    float dDepth = depthInput * speed;
    float dLateral = lateralInput * speed;

    Vector3 depthForce = dDepth * planarDirection;
    Vector3 lateralForce = dLateral * pdrAsVec3;

    rb.AddForce(depthForce + lateralForce);
	}

  private void computeInputs (float dx, float dy)
  {

  }
}
