using UnityEngine;
using System.Collections;

public class rotatePlayer : MonoBehaviour {

	public float RotationSpeed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		var y = Input.GetAxis ("Mouse Y") * -1 * RotationSpeed * Time.deltaTime;
		var x = Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime;

		transform.Rotate(y, x, 0, Space.Self);

	
	}
}
