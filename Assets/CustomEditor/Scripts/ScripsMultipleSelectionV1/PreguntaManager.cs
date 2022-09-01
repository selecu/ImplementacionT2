using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;


namespace v1
{
	public class PreguntaManager : MonoBehaviour
	{
		[System.Serializable]
		public struct Pieza
		{

			public Sprite Icon;
			[TextArea]
			public string Info;
		}

		[SerializeField] Pieza[] AllPiezas;

		void Start()
		{
			GameObject PiezaTemplate = transform.GetChild(0).gameObject;
			GameObject g;

			int N = AllPiezas.Length;

			for (int i = 0; i < N; i++)
			{

				g = Instantiate(PiezaTemplate, transform);
				g.transform.GetChild(0).GetComponent<Image>().sprite = AllPiezas[i].Icon;
				g.transform.GetChild(1).GetComponent<Text>().text = AllPiezas[i].Info;



			}

			Destroy(PiezaTemplate);
		}
	}

}

