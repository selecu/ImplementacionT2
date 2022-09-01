using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace v1
{
    public class I9428Controller : MonoBehaviour
    {
        private int count;
        [SerializeField] private GameObject audiosParent;
        [SerializeField] private GameObject panel;
        private bool inCoroutine;
        [SerializeField] private GameObject checkIntegrador;
        public void IncrementCount() =>
            count++;

        public void Interactable(GameObject obj)
        {
            obj.GetComponent<Button>().interactable = false;
            obj.transform.GetChild(0).GetComponent<Button>().interactable = false;
        }

        public void OnPressButton(AudioSource audioSource) =>
            StartCoroutine(AudioRutine(audioSource));

        IEnumerator AudioRutine(AudioSource audioSource)
        {
            yield return new WaitForSeconds(2f);
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            panel.GetComponent<Animator>().SetTrigger("UnShow");
            yield return new WaitForSeconds(2.2f);
            panel.GetComponent<Image>().raycastTarget = false;
            if (count >= audiosParent.transform.childCount - 1 && !checkIntegrador.activeInHierarchy)
            {
                yield return new WaitForSeconds(audioSource.clip.length + 3f);
                checkIntegrador.SetActive(true);
            }
        }
    }
}
