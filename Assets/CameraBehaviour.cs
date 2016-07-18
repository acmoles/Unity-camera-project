using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour {

	WebCamTexture cameraTest;

	public RawImage image;

	public AspectRatioFitter imageFitter;

	public GameObject target;






	// Use this for initialization
	void Start () {

		cameraTest = new WebCamTexture();
//		renderer.material.mainTexture = webCamTexture;
		cameraTest.Play();
	
	}
		

	// Update is called once per frame
	void Update () {

		float videoRatio = (float)cameraTest.width / (float)cameraTest.height;
		imageFitter.aspectRatio = videoRatio;


		GetComponent<RawImage>().texture = cameraTest;


	}


	public void onClick(){
		TakePhoto ();
	}

	IEnumerator TakePhoto() {

		yield return new WaitForEndOfFrame(); 

		int width = cameraTest.width;
		int height = cameraTest.height;
		Texture2D photo = new Texture2D(width, height, TextureFormat.RGB24, false);

		Color[] cameraGrab = cameraTest.GetPixels();

		//int x, int y, int blockWidth, int blockHeight

		photo.SetPixels(cameraGrab);
		photo.Apply();

		target.GetComponent<Renderer>().material.mainTexture = photo;

		//Encode to a PNG
		byte[] bytes = photo.EncodeToPNG();
		//Write out the PNG. Of course you have to substitute your_path for something sensible
		File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
	}
}
