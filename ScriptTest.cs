
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;

public class ScriptTest : MonoBehaviour {
	// Use this for initialization
	SerialPort stream = new SerialPort("/dev/cu.usbmodem14101", 115200);


	void Start () {

		stream.Open();
	}
		
	// Update is called once per frame
	void Update () {

		//string valueX = stream.ReadLine();
		//float x = float.Parse(valueX);
		//transform.Rotate (transform.eulerAngles.y, -x/1000, transform.eulerAngles.z);

		//string valueY = stream.ReadLine();
		//float y = float.Parse(valueY);

		//transform.Rotate (-y/1000, transform.eulerAngles.x, transform.eulerAngles.z);


		//string valueZ = stream.ReadLine();
		//float z = float.Parse(valueZ);

		//transform.Rotate (transform.eulerAngles.y, transform.eulerAngles.x, -z/1000);
		string[] values = stream.ReadLine().Split('|');
		float roll = float.Parse(values[0]);
		float pitch = float.Parse(values[1]);
		float yaw = float.Parse(values[2]);
		Debug.Log (pitch + ", " + yaw + ", " + roll);


		//float GyroY = y/1000;
		//float GyroX = x/1000;
		//float GyroZ = z/1000;

		//GyroZ = Mathf.Clamp(GyroZ, -90, 90);

	
		//transform.Rotate(pitch, yaw, roll);
		transform.localEulerAngles = new Vector3(roll,yaw+180, 0);//-pitch);


	}

}

