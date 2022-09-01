using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

namespace v1
{
    public class GameManagerConteo : MonoBehaviour
    {
        [Header("Settings")]

        [SerializeField] private Sprite[] faces;

        [Space]

        [SerializeField] private Transform tokens;

        [Space]

        [SerializeField] private GameObject checker;

        [Space]

        [SerializeField] GameObject check_INTEGRADOR;

        [Space]

        [SerializeField] private Transform snap;

        [Space]

        [SerializeField] private Spore main;

        [Space]

        [SerializeField] private AudioSource p;

        [SerializeField]
        int respuesta;

        public GameObject[] ventana;

        IEnumerator ReproduceAudio()
        {

            yield return new WaitForEndOfFrame();

            yield return new WaitForSeconds(0.69f);

            p.Play();
        }

        private void Awake()
        {
            StartCoroutine(ReproduceAudio());
        }

        void Start()
        {
            check_INTEGRADOR.SetActive(false);
            

            int[] mask = new int[faces.Length];

            for(int i = 0; i < faces.Length; i++)
                mask[i] = i;

            for(int i = 0; i < mask.Length; i++)
            {
                int tmp = mask[i],
                r = Random.Range(0,mask.Length);

                mask[i] = mask[r];
                mask[r] = tmp;
            }

            for(int i = 0; i < tokens.childCount; i++)
            {
                var token = tokens.GetChild(i).GetComponent<Token>();

                token.SetVars(mask[i], faces[mask[i]]);
            }
        }

        private void Update() =>
            checker.GetComponent<Button>().interactable =  main.children >= 1;


        public void CheckAns()
        {
            if(main.children != respuesta)
            {
                for(int i = 0; i < snap.childCount;i++)
                {
                    if(snap.GetChild(i).childCount < 1)
                        continue;

                    snap.GetChild(i).GetChild(0).GetComponent<Token>().GoHome();
                }
                ventana[1].SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.incorrecto.Play();
                StartCoroutine(Waiting());

                Start();
            }
            else
            {
                //SceneManager.UnloadSceneAsync(sceneName);
                ventana[0].SetActive(true);
                v1.Managersound item = FindObjectOfType<Managersound>();
                item.correcto.Play();
                check_INTEGRADOR.SetActive(true);
                checker.SetActive(false);
                



            }
                
        }
        IEnumerator Waiting()
        {
            yield return new WaitForSeconds(5);
            ventana[1].SetActive(false);
            StopCoroutine(Waiting());
        }
    }
}