using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;
using System.Runtime.InteropServices;

namespace v1
{
	[Serializable]
	public class Screenshot : MonoBehaviour
	{


		[DllImport("__Internal")]
		public static extern void DownloadImageJs(byte[] bytes, int size, string name);
		public int enlarge = 1;

		public bool saveState = false;

		private int picture;
		private bool takeHiResShot = false;
		private string size;

		public GameObject SaveCanvas;
		private bool SaveCanvas_Trigger;

		public GameObject[] pixels;
		Image ImageRenderer;
		Color colorchoose;

		[HideInInspector]
		public int currentTab;

		public RectTransform rectT; // Assign the UI element which you wanna capture
		public int width; // width of the object to capture
		public int height; // height of the object to capture

		void Start()
		{
			SaveCanvas_Trigger = false;
			SaveCanvas.SetActive(SaveCanvas_Trigger);
			width = System.Convert.ToInt32(rectT.rect.width);
			height = System.Convert.ToInt32(rectT.rect.height);
		}
		public void saveCanvas()
		{
			SaveCanvas_Trigger = !SaveCanvas_Trigger;
			SaveCanvas.SetActive(SaveCanvas_Trigger);
		}

		public void saveImage()
		{
			saveState = true;
			SaveCanvas_Trigger = false;
			SaveCanvas.SetActive(SaveCanvas_Trigger);
		}

		public void newDraw()
		{
			SaveCanvas_Trigger = false;
			SaveCanvas.SetActive(SaveCanvas_Trigger);

			for (int i = 0; i < pixels.Length; i++)
			{
				ImageRenderer = pixels[i].GetComponent<Image>();
				colorchoose.a = 0f;
				ImageRenderer.color = colorchoose;
			}
		}

		public void cancel()
		{
			SaveCanvas_Trigger = false;
			SaveCanvas.SetActive(SaveCanvas_Trigger);
		}
		void LateUpdate()
		{

			if (saveState == true)
			{
				takeHiResShot = true;
				saveState = false;
			}

			if (takeHiResShot)
			{

				picture = PlayerPrefs.GetInt("PhotoNumber");
				picture++;
				PlayerPrefs.SetInt("PhotoNumber", picture);
				StartCoroutine(takeScreenShot());
				takeHiResShot = false;
			}
		}

		public IEnumerator takeScreenShot()
		{
			yield return new WaitForEndOfFrame(); // it must be a coroutine 

			Vector3[] corners = new Vector3[4];
			rectT.GetWorldCorners(corners);
			Vector2 temp = rectT.transform.position;
			var startX = (temp.x - width / 2);
			var startY = (temp.y - height / 2);

			width = (int)corners[3].x - (int)corners[0].x;
			height = (int)corners[1].y - (int)corners[0].y;

			var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
			tex.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
			tex.Apply();

			// Encode texture into PNG
			var bytes = tex.EncodeToPNG();
			Destroy(tex);

			string imgsrc = System.Convert.ToBase64String(bytes);
			Texture2D scrnShot = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			scrnShot.LoadImage(System.Convert.FromBase64String(imgsrc));
			string filename = picture + "_pixelArt.png";
#if UNITY_EDITOR


			if (!Directory.Exists(Application.dataPath + "/../screenshots/"))
				Directory.CreateDirectory(Application.dataPath + "/../screenshots/");

			System.IO.File.WriteAllBytes(filename, bytes);
			Debug.Log(string.Format("Took screenshot to: {0}", filename));
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
		DownloadImageJs(bytes, bytes.Length, filename);
#endif
		}

		public void Capture()
		{
			StartCoroutine(takeScreenShot()); // screenshot of a particular UI Element.
		}
	}
}

