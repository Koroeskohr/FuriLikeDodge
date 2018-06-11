using FuriLikeDodge.Input;
using UnityEngine;

public class InputModeDetection : MonoBehaviour {
  [HideInInspector]
  public InputMode inputMode;

  [ReadOnly] public string[] pads;

  void Awake()
  {
    this.inputMode = detectInputMode();
  }
	
	// Update is called once per frame
	void Update () {
    InputMode mode = detectInputMode();
    if (mode != this.inputMode)
    {
      this.inputMode = mode;
    }
	}

  public InputMode GetInputMode() { return this.inputMode; }

  private InputMode detectInputMode()
  {
    var pads = Input.GetJoystickNames();

    this.pads = pads;
    bool gamepadPlugged = pads.Length > 0;

    if (gamepadPlugged)
    {
      return InputMode.GAMEPAD;
    }

    return InputMode.KEYBOARD;
  }
}
