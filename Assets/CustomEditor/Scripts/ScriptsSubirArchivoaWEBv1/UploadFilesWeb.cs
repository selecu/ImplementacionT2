using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System;
using System.IO;
using System.Collections;

namespace v1
{
   public class UploadFilesWeb : MonoBehaviour
   {
        public GameObject check;

      // Extension allowed
      public string[] extension;

      // This Event is called when file is upload
      public UnityEvent whenFileLoad;

      // Put here interaction of file upload
      public string interaction;

      [DllImport("__Internal")]
      private static extern void UploadFilesJs(string nameInteraction);

      // Add here the calls when the file is upload :D
      public void FileIsUpload()
      {
         whenFileLoad?.Invoke();
      }
      public void UploadFile()
      {
#if UNITY_EDITOR
         var path = EditorUtility.OpenFilePanel("Seleciona el archivo", "", "*");
         if (!File.Exists(path)) return;
         StartCoroutine("FakeUploadFileUnity");
#endif
#if UNITY_WEBGL && !UNITY_EDITOR
         UploadFilesJs(interaction);
#endif
      }


        private void Start()
        {
            check.SetActive(false);    
        }

        // Fake upload :D
        IEnumerator FakeUploadFileUnity()
      {
         yield return new WaitForSeconds(2f);
         FileIsUpload();
      }

      // Fake Test :D
      public void Test()
      {
            check.SetActive(true);
#if UNITY_EDITOR
            Debug.Log("Se subio :D");
#endif
        }
    }
}

