using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
	/// <summary>
	/// Class to animate an image
	/// </summary>
	public class ImageAnimation : MonoBehaviour
	{
		private int index = 0;
		private Image image;

		public Sprite[] Sprites;
		public float Delay = 1.0f;
		public int spritePerFrame = 6;
		public bool Loop = true;
		public bool DestroyOnEnd = false;

		/// <summary>
		/// Is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			image = GetComponent<Image>();
		}

		/// <summary>
		/// Is called when the script instance is active.
		/// </summary>
		void OnEnable()
		{
			// Set to default value
			index = 0;

			// Start the coroutine
			StartCoroutine(Animate(this.Delay));
		}

		/// <summary>
		/// Coroutine to animate the image
		/// </summary>
		private IEnumerator Animate(float delay)
		{
			Debug.Log(">> Animate");
			while (true)
			{
				Debug.Log(">> Animate >> while");
				image.sprite = Sprites[index];
				index++;
				Debug.Log(">> Animate >> index++ ? "+index);
				Debug.Log(">> Animate >> Sprites.Length ? " + Sprites.Length);
				if (index >= Sprites.Length)
				{
					Debug.Log(">> Animate >> if");
					if (Loop) index = 0;
					Debug.Log(">> Animate >> loop");
					Debug.Log(">> Animate >> destroyOnEnd ? "+DestroyOnEnd);
					if (DestroyOnEnd) Destroy(gameObject);
					Debug.Log(">> Animate >> destroy");
				}
				Debug.Log(">> Animate >> Wait for "+delay);
				yield return new WaitForSeconds(delay);
				Debug.Log(">> Animate >> after waiting");
				yield return null;
			}
		}

        private void OnDestroy()
        {
			Debug.Log("DESTROY");
        }
    }
}
