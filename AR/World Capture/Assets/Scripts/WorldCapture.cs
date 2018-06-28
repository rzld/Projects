using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class WorldCapture : MonoBehaviour {

	public GameObject plane;
	private Texture2D planeTex;
	private Pose spawnPoint;
	private Anchor anchor;

	// Use this for initialization
	void Start () {
		// plane = GameObject.CreatePrimitive(PrimitiveType.Quad);
		plane.transform.localScale = new Vector3(Screen.width/1000f, Screen.height/1000f, 1.0f);
		Debug.Log(plane.transform.localScale);
	}
	
	// Update is called once per frame
	void Update () {
		//maybe?
		//spawnPoint.position = Camera.main.transform.position;
		if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
			Debug.Log("Touch");
			CaptureWorld();
		}
	}

	void CaptureWorld() {
		//capture screen to texture
		//yield return new WaitForEndOfFrame();
		planeTex = ScreenCapture.CaptureScreenshotAsTexture();
		//yield return new WaitForEndOfFrame();

		Pose cameraPose = new Pose(Camera.main.transform.position, Camera.main.transform.rotation);

		//create anchor
		Pose planePosition = new Pose(cameraPose.position + cameraPose.forward * 1.5f, cameraPose.rotation);
		anchor = Session.CreateAnchor(planePosition);
		
		//instantiate game object and put texture to quad
		GameObject newPlane = Instantiate(plane, cameraPose.position + cameraPose.forward * 1.5f, cameraPose.rotation);
		newPlane.transform.parent = anchor.transform;
		//newPlane.transform.localScale = new Vector3(Screen.width, Screen.height, 1.0f);
		newPlane.GetComponent<MeshRenderer>().material.mainTexture = planeTex;
		planeTex.Apply();
	}

	public void LateUpdate() {
	 	//StartCoroutine(CaptureWorld());
	}
}
