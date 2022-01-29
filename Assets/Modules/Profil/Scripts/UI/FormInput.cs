using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
	/// Class for the form of the profile creation
	/// </summary>
    [RequireComponent(typeof(InputField))]
    public class FormInput : MonoBehaviour
    {
        [SerializeField]
        private Button validationButton;

        // Update is called once per frame
        void Update()
        {
            Debug.Log("length : "+ GetComponent<InputField>().text.Length);
            Debug.Log("key enter : " + Input.GetKey(KeyCode.E));
            if ((GetComponent<InputField>().text.Length > 0) && (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return)))
            {
                Debug.Log("yeahhh");
                validationButton.onClick.Invoke();
            }
        }
    }
}
