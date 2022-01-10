using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha
{
    /// <summary>
    /// Class for the button to create a profile
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
        /// Event called when the user clicks on the button
        /// <example> Example(s):
        /// <code>
        ///     GetComponent<Button>().onClick.AddListener(OnClick);
        /// </code>
        /// </example>
        /// </summary>
        void OnClick()
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