using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayButtonOptions : MonoBehaviour {

	public Button standard;
	public Button time;
	public GameObject leftLine;
	public GameObject rightLine;

	private bool start = false;
	private float scale = 0;
	private Image leftLineImage;
	private Image rightLineImage;
	private RectTransform storyRect;
	private RectTransform survivalRect;
	private AudioSource buttonClick;

	void Start () {
		leftLineImage = leftLine.GetComponent <Image> ();
		rightLineImage = rightLine.GetComponent <Image> ();
		storyRect = standard.gameObject.gameObject.GetComponent<RectTransform> ();
		survivalRect = time.gameObject.gameObject.GetComponent<RectTransform> ();
		buttonClick = GameObject.Find("ButtonClickSound").GetComponent<AudioSource>();
	}

	public void onPlayClick () {
		buttonClick.Play();
		if (start == false) {
			start = true;
		} else {
			start = false;
		}
	}

	public void playClose () {
		start = false;
		scale = 0;
		leftLineImage.color = new Color (1, 1, 1, scale);
		rightLineImage.color = new Color (1, 1, 1, scale);
		standard.gameObject.SetActive (false);
		time.gameObject.SetActive (false);
	}

	void Update () {
			if (start == true) {
				standard.gameObject.SetActive (true);
				time.gameObject.SetActive (true);
				if (scale < 1f) {
					scale += 0.07f;
					leftLineImage.color = new Color (1, 1, 1, scale);
					rightLineImage.color = new Color (1, 1, 1, scale);
					storyRect.localScale = new Vector2 (scale, scale);
					survivalRect.localScale = new Vector2 (scale, scale);
				}
			} else {
				if (scale > 0f) {
					scale -= 0.07f;
					leftLineImage.color = new Color (1, 1, 1, scale);
					rightLineImage.color = new Color (1, 1, 1, scale);
					storyRect.localScale = new Vector2 (scale, scale);
					survivalRect.localScale = new Vector2 (scale, scale);
				} else {
					standard.gameObject.SetActive (false);
					time.gameObject.SetActive (false);
				}
			}
	}
}
