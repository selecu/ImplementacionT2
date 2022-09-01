using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


[System.Serializable]
public class Pieza1
{
	public string id1;
	public Sprite Icon;
	[TextArea]
	public string Info;

}

namespace v1
{
	public class PreguntaManagerO : MonoBehaviour
	{


		public List<Pieza1> AllPiezas;




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
			Shuffle(AllPiezas);

			GameObject PiezaTemplate = transform.GetChild(0).gameObject;
			GameObject g;

			int N = AllPiezas.Count;

			for (int i = 0; i < N; i++)
			{
				g = Instantiate(PiezaTemplate, transform);
				g.transform.GetChild(0).GetComponent<Image>().sprite = AllPiezas[i].Icon;
				g.transform.GetChild(1).GetComponent<Text>().text = AllPiezas[i].Info;
				g.transform.GetComponent<DragHandlerO>().id = AllPiezas[i].id1;


			}

			Destroy(PiezaTemplate);
		}



	}
}



