using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuriLikeDodge;

public class GameController : MonoBehaviour {

  [HideInInspector]
  public InputModeDetection inputModeDetection;
  public GameObject player;

  void Awake()
  {
    inputModeDetection = Helpers.GetComponentOrFail<InputModeDetection>(this);
  }

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
