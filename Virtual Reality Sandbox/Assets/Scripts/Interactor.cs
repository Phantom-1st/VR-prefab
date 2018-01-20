using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{

	//
	[SerializeField]
	protected OVRInput.Controller m_controller;

	protected OVRGrabber OVRGrabberScript;

	[SerializeField]
	protected OVRInput.Button colorButton;
	[SerializeField]
	protected OVRInput.Button rotateInput;
	[SerializeField]
	protected OVRInput.Button pushInput;


	// Use this for initialization
	void Start ()
	{
		OVRGrabberScript = gameObject.GetComponent<OVRGrabber>();
	}

	// Update is called once per frame
	void Update ()
	{
		OVRInput.Update();
		// Check if there's an object in controller hand
		if (OVRGrabberScript.m_grabbedObj != null)
		{
			// Check if button for activity is down
			if(OVRInput.Get(colorButton, m_controller))
			{
				colorChange();
			}
			if(OVRInput.Get(rotateInput, m_controller))
			{
				rotate();
			}
			if(OVRInput.Get(pushInput, m_controller))
			{
				push();
			}
		}
	}

	//Changes color of object
	public void colorChange (float colorTime=0f)
	{
			colorTime += Time.deltaTime;
			OVRGrabberScript.m_grabbedObj.GetComponent<Renderer>().material.SetColor(
					"_Color",
					new Color (Mathf.Abs (Mathf.Cos (colorTime)),
							Mathf.Abs (Mathf.Cos (2 * colorTime)),
							Mathf.Abs (Mathf.Cos (3 * colorTime))));
	}

	// Rotates object
	public void rotate ()
	{
			OVRGrabberScript.m_grabbedObj.transform.Rotate(Vector3.up*5f);
	}

	// Sends object with a force
	public void push ()
	{
		OVRGrabberScript.m_grabbedObj.GetComponent<Rigidbody>().AddExplosionForce(50f, OVRGrabberScript.m_grabbedObj.transform.position, 10f);
		OVRGrabberScript.GrabEnd();
	}
}
