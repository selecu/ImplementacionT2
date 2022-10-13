using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace I2745
{

    [System.Serializable]
    public class infoE
    {
        [TextArea(10, 10)]
        public string info;
        public AudioClip Audio;
        public Sprite sprite;

    }
    public class ManagerVerificatorCardsreverseAudio : MonoBehaviour
    {
        GameObject c1;
        GameObject c2;
        private int ideInfo;
        List<v1.ManagerCardInforeverseAudio> cards;

        public List<infoE> infoText;
        Queue<string> frases;
        Queue<AudioClip> audioClips;
        Queue<Sprite> sprites;


        [SerializeField]
        GameObject panelInfo;
        [SerializeField]
        TMP_Text textInfo;
        [SerializeField]
        Image imageTarget;
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
            sprites = new Queue<Sprite>();
            foreach (var item in infoText)
            {
                frases.Enqueue(item.info);
                audioClips.Enqueue(item.Audio);
                sprites.Enqueue(item.sprite);
            }
            panelInfo.SetActive(false);
            cards = FindObjectsOfType<v1.ManagerCardInforeverseAudio>().ToList();
            if (reverse != null)
            {
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
                c1.GetComponent<v1.ManagerCardInforeverseAudio>().isUsed = true;
                c1.GetComponent<Button>().interactable = false;
                if (c1.GetComponent<v1.ManagerCardInforeverseAudio>().image != null)
                {
                    c1.GetComponent<Image>().sprite = c1.GetComponent<v1.ManagerCardInforeverseAudio>().image;
                }

            }
            else if (c2 == null)
            {
                if (EventSystem.current.currentSelectedGameObject.gameObject != c1)
                {
                    c2 = EventSystem.current.currentSelectedGameObject.gameObject;
                    c2.GetComponent<v1.ManagerCardInforeverseAudio>().isUsed = true;
                    c2.GetComponent<Button>().interactable = false;
                    if (c2.GetComponent<v1.ManagerCardInforeverseAudio>().image != null)
                    {
                        c2.GetComponent<Image>().sprite = c2.GetComponent<v1.ManagerCardInforeverseAudio>().image;
                    }
                    Check();
                }

            }
        }

        public void Check()
        {
            if (c1.GetComponent<v1.ManagerCardInforeverseAudio>().cardID == c2.GetComponent<v1.ManagerCardInforeverseAudio>().cardID)
            {
                if (conPanelInfo)
                {
                    panelInfo.SetActive(true);
                    textInfo.text = frases.Dequeue();
                    imageTarget.sprite = sprites.Dequeue();
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
                c1.GetComponent<v1.ManagerCardInforeverseAudio>().isUsed = false;
                c1.GetComponent<Button>().interactable = true;
                c2.GetComponent<v1.ManagerCardInforeverseAudio>().isUsed = false;
                c2.GetComponent<Button>().interactable = true;
                if (reverse != null)
                {
                    StartCoroutine("esperar");
                }
                else
                {
                    c1 = null;
                    c2 = null;
                }

            }
        }

        IEnumerator esperar()
        {
            yield return new WaitForSeconds(1f);
            c1.GetComponent<Image>().sprite = reverse;
            c2.GetComponent<Image>().sprite = reverse;
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
