using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace v1
{

    [System.Serializable]
    public class infoE
    {
        [TextArea(10, 10)]
        public string info;
        public AudioClip Audio;

    }
    public class ManagerVerificatorCardsreverseAudio : MonoBehaviour
    {
        GameObject c1;
        GameObject c2;
        private int ideInfo;
        List<ManagerCardInforeverseAudio> cards;

        public List<infoE> infoText;
        Queue<string> frases;
        Queue<AudioClip> audioClips;


        [SerializeField]
        GameObject panelInfo;
        [SerializeField]
        Text textInfo;
        [SerializeField]
        GameObject container;
        [SerializeField]
        GameObject botonIntegrador;
        public Sprite reverse;
        public AudioSource Info;


        [Tooltip("Si cuando hacen pareja sale un mensaje de info")]
        public bool conPanelInfo;

        private void Start()
        {
            frases = new Queue<string>();
            audioClips = new Queue<AudioClip>();
            foreach (var item in infoText)
            {
                frases.Enqueue(item.info);
                audioClips.Enqueue(item.Audio);
            }
            panelInfo.SetActive(false);
            cards = FindObjectsOfType<ManagerCardInforeverseAudio>().ToList();
            if(reverse != null){
                foreach (var card in cards)
                {
                    card.GetComponent<Image>().sprite = reverse;
                    card.GetComponent<Image>().SetNativeSize();
                }
            }
            Reorder();
        }
        public void GetC1C2()
        {
            if (c1 == null && c2 == null)
            {
                c1 = EventSystem.current.currentSelectedGameObject.gameObject;
                c1.GetComponent<ManagerCardInforeverseAudio>().isUsed = true;
                c1.GetComponent<Button>().interactable = false;
                if(c1.GetComponent<ManagerCardInforeverseAudio>().image != null)
                {
                    c1.GetComponent<Image>().sprite = c1.GetComponent<ManagerCardInforeverseAudio>().image;
                }
                
            }
            else if (c2 == null)
            {
                if (EventSystem.current.currentSelectedGameObject.gameObject != c1)
                {
                    c2 = EventSystem.current.currentSelectedGameObject.gameObject;
                    c2.GetComponent<ManagerCardInforeverseAudio>().isUsed = true;
                    c2.GetComponent<Button>().interactable = false;
                    if(c2.GetComponent<ManagerCardInforeverseAudio>().image != null)
                    {
                        c2.GetComponent<Image>().sprite = c2.GetComponent<ManagerCardInforeverseAudio>().image;
                    }
                    Check();
                }

            }
        }

        public void Check()
        {
            if (c1.GetComponent<ManagerCardInforeverseAudio>().cardID == c2.GetComponent<ManagerCardInforeverseAudio>().cardID)
            {
                if (conPanelInfo)
                {
                    panelInfo.SetActive(true);
                    textInfo.text = frases.Dequeue();
                    Info.clip = audioClips.Dequeue();
                    Info.Play();


                    
                }
                botonIntegrador.SetActive(IsFinished());
                //Debug.Log("<color=lime> aca gano? </color>" + IsFinished());
                c1 = null;
                c2 = null;
            }
            else
            { 
                c1.GetComponent<ManagerCardInforeverseAudio>().isUsed = false;
                c1.GetComponent<Button>().interactable = true;
                c2.GetComponent<ManagerCardInforeverseAudio>().isUsed = false;
                c2.GetComponent<Button>().interactable = true;
                if(reverse!= null){
                    StartCoroutine("esperar");
                }else{
                    c1 = null;
                    c2 = null;
                }
                
            }
        }

        IEnumerator esperar() {
            yield return new WaitForSeconds(1f);
            c1.GetComponent<Image>().sprite = reverse ;
            c2.GetComponent<Image>().sprite = reverse ;
            c1 = null;
            c2 = null;
    }


        private bool IsFinished()
        {
            int total = cards.Count();
            int count = 0;
            foreach (var item in cards)
            {
                if (item.isUsed)
                {
                    count++;
                }
            }

            if (count == total)
            {
#if UNITY_EDITOR
                Debug.Log("gano el maldito lo logro");
#endif

                return true;
            }
            else
                return false;
        }

        private void Shuffle<T>(List<T> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                T temp = list[i];
                int rnd = Random.Range(i, list.Count);
                list[i] = list[rnd];
                list[rnd] = temp;
            }
        }

        private void Reorder()
        {
            Shuffle(cards);
            foreach (var item in cards)
            {
                item.transform.SetParent(container.transform);
            }
        }
    }

}
