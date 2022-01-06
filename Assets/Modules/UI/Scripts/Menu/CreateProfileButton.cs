using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class CreateProfileButton : MonoBehaviour
    {
        public InputField InputName;
        public MenuRoot MenuRoot;
        public GameObject CreateProfilUI;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public void OnClick()
        {
            if (ProfilManager.Instance)
            {
                ProfilManager.Instance.CreateProfil(new Profil(InputName.text));
                InputName.text = "";
                CreateProfilUI.SetActive(false);
                MenuRoot.ShowMainMenu();
            }
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}