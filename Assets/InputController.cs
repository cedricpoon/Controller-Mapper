using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	MatchScreen _console;
	bool _hasJoystick;
	string _preKeyIn = "";

	// Use this for initialization
	void Start ()
	{
		_console = GetComponent<MatchScreen> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Connected to controller
		if (!_hasJoystick && Input.GetJoystickNames ().Length != 0) {
			_console.Push ("Connected to joystick [" + Input.GetJoystickNames () [0] + "]");
			_hasJoystick = true;
		} else if (_hasJoystick) {
			string keyIn = "";
			string axisIn = "";

			CheckIfAxisMoved (ref axisIn, 1);
			CheckIfAxisMoved (ref axisIn, 2);
			CheckIfAxisMoved (ref axisIn, 3);
			CheckIfAxisMoved (ref axisIn, 4);
			CheckIfAxisMoved (ref axisIn, 5);
			CheckIfAxisMoved (ref axisIn, 6);
			CheckIfAxisMoved (ref axisIn, 7);

			CheckIfPressed (ref keyIn, "b0", KeyCode.JoystickButton0);
			CheckIfPressed (ref keyIn, "b1", KeyCode.JoystickButton1);
			CheckIfPressed (ref keyIn, "b2", KeyCode.JoystickButton2);
			CheckIfPressed (ref keyIn, "b3", KeyCode.JoystickButton3);
			CheckIfPressed (ref keyIn, "b4", KeyCode.JoystickButton4);
			CheckIfPressed (ref keyIn, "b5", KeyCode.JoystickButton5);
			CheckIfPressed (ref keyIn, "b6", KeyCode.JoystickButton6);
			CheckIfPressed (ref keyIn, "b7", KeyCode.JoystickButton7);
			CheckIfPressed (ref keyIn, "b8", KeyCode.JoystickButton8);
			CheckIfPressed (ref keyIn, "b9", KeyCode.JoystickButton9);
			CheckIfPressed (ref keyIn, "b10", KeyCode.JoystickButton10);
			CheckIfPressed (ref keyIn, "b11", KeyCode.JoystickButton11);
			CheckIfPressed (ref keyIn, "b12", KeyCode.JoystickButton12);
			CheckIfPressed (ref keyIn, "b13", KeyCode.JoystickButton13);
			CheckIfPressed (ref keyIn, "b14", KeyCode.JoystickButton14);
			CheckIfPressed (ref keyIn, "b15", KeyCode.JoystickButton15);
			CheckIfPressed (ref keyIn, "b16", KeyCode.JoystickButton16);

			if ((axisIn + keyIn).Length != 0) {
				if (_preKeyIn != (axisIn + keyIn)) {
					_console.UnHold ("pressing", "pressed");
					if (axisIn.Length != 0)
						_console.Hold ("Axis: " + axisIn);
					if (keyIn.Length != 0)
						_console.Hold (keyIn + " is pressing");
					_preKeyIn = (axisIn + keyIn);
				}
			} else {
				_console.UnHold ("pressing", "pressed");
				_preKeyIn = "";
			}
		}
	}

	void CheckIfPressed (ref string keyList, string key, KeyCode code)
	{
		if (Input.GetKey (code))
			keyList += "[" + key + "] ";
	}

	void CheckIfAxisMoved (ref string keyList, int index)
	{
		if (Input.GetAxisRaw ("x-" + index) != 0 ||
		    Input.GetAxisRaw ("y-" + index) != 0) {

			keyList += "[" + "x-" + index + ":" + Input.GetAxisRaw ("x-" + index) + "] ";
			keyList += "[" + "y-" + index + ":" + Input.GetAxisRaw ("y-" + index) + "] ";
		}
	}
}
