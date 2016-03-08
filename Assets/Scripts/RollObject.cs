using UnityEngine;
using System.Collections;

public class RollObject : MonoBehaviour {

	float rollZ;

	// Use this for initialization
	void Start () {
		rollZ = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		rollZ += Time.deltaTime * 360.0f;
		transform.rotation = Quaternion.Euler(0, 0, rollZ);
	}
}
