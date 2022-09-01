using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace v1
{
    public class PeceraTimer_ContainerImageView : MonoBehaviour
    {
        public static PeceraTimer_ContainerImageView instance;
        public GameObject ImageCellPrefab;
        public Transform ImageViewContent;

        public Text[] cantidades;
        [SerializeField]
        int minimo;
        [SerializeField]
        int maximo;
        public static int ItemCounts;

        public BoxCollider2D spawnArea;
        Vector2 maxSpawnPos;


        [Header("Image Assets")]
        public List<Sprite> Images = new List<Sprite>();

        private void Awake()
        {
            instance = this;
        }


        // Start is called before the first frame update
        void Start()
        {
            ItemCounts = 0;

            //Debug.Log(maxSpawnPos + "max");
        }

        public void Setup()
        {

            PrepareImages();

        }



        public void PrepareImages()
        {
            for (int j = 0; j < Images.Count; j++)
            {
                Sprite Img = Images[j];
                SpawnImageCell(Img, j);
            }
        }
        public void SpawnImageCell(Sprite Image, int k)
        {
            spawnArea = ImageViewContent.GetComponent<BoxCollider2D>();
            maxSpawnPos = new Vector2(spawnArea.size.x / 2, spawnArea.size.y / 2);
            int Randomindex = UnityEngine.Random.Range(minimo, maximo);
            //        WordSearch_StartScript.instance.SecondGame();
            ItemCounts += Randomindex;
            cantidades[k].text = Randomindex.ToString();


            for (int i = 0; i < Randomindex; i++)
            {
                GameObject cell = Instantiate(ImageCellPrefab);
                cell.GetComponent<Image>().sprite = Image;
                cell.transform.SetParent(ImageViewContent);
                //Vector3 pos = new Vector3(Random.Range(-135, 135), Random.Range(-99, 99), 0);
                Vector3 pos = new Vector3(Random.Range(maxSpawnPos.x, -maxSpawnPos.x), Random.Range(-maxSpawnPos.y, maxSpawnPos.y), 0);
                //Debug.Log(maxSpawnPos);
                cell.transform.localPosition = pos;

            }
            
        }

    }
}

