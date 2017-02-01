using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour {

	public Transform head;

	public SteamVR_TrackedObject leftHand;
	public SteamVR_TrackedObject rightHand;

	private bool isFlying = false;

	// Update is called once per frame
	void Update () {
		var leftDevice = SteamVR_Controller.Input ((int)leftHand.index);
		var rightDevice = SteamVR_Controller.Input ((int)rightHand.index);
		if (leftDevice.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger) || rightDevice.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger)) {
			isFlying = !isFlying;
		}

		if (isFlying) {
			//Calculate distance between head and hands to get direction vector
			Vector3 leftDir = leftHand.transform.position - head.position;
			Vector3 rightDir = rightHand.transform.position - head.position;

			Vector3 dir = leftDir + rightDir;

			transform.position += (dir/10); // makes our direction change based on direction
		}
	}
}
