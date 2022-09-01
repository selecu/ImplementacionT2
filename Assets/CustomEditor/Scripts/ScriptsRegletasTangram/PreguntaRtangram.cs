using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;




[Serializable]
public class PReTangram
{
	public string id1R;
	public Sprite IconR;
	[TextArea]
	public string InfoR;

}

namespace v2
{
	public class PreguntaRtangram : MonoBehaviour
	{


		public List<PReTangram> AllPiezasR;




		private void Shuffle<T>(List<T> list)
		{
			for (int i = 0; i < list.Count - 1; i++)
			{
				T temp = list[i];
				int rnd = UnityEngine.Random.Range(i, list.Count);
				list[i] = list[rnd];
				list[rnd] = temp;
			}
		}



		void Start()
		{
			Instance();

		}

		public void Instance()
		{
			Shuffle(AllPiezasR);

			GameObject PiezaTemplate = transform.GetChild(0).gameObject;
			GameObject g;

			int N = AllPiezasR.Count;

			for (int i = 0; i < N; i++)
			{
				g = Instantiate(PiezaTemplate, transform);
				g.transform.GetChild(0).GetComponent<Image>().sprite = AllPiezasR[i].IconR;
				g.transform.GetChild(1).GetComponent<Text>().text = AllPiezasR[i].InfoR;
				g.transform.GetComponent<DragHandlerDragandDropRtangram>().id = AllPiezasR[i].id1R;


			}

			Destroy(PiezaTemplate);
		}



	}
}



