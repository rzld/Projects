//attach script to camera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCap : MonoBehaviour {

	//grab camera view whtn this variable is true
	bool grab;

	//gameobject in which the texture will be applied
	public Renderer m_Display;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//[change function later] tap to start screen grab
		if (Input.GetKeyDown(KeyCode.Space)) {
			grab = true;
		}
	}

	private void OnPostRender() {
		if (grab) {
			//create new texture with W and H of screen
			Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
			//read pixels in Rect starting at 0,0 and ending at screen's W,H
			texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
			texture.Apply();
			//check if display field has been assigned in the Inspector
			if (m_Display != null) {
				//give the Renderer this texture
				m_Display.material.mainTexture = texture;
			}
			//reset grab state
			grab = false;
		}
	}
}
