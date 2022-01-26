using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
	/// <summary>
	/// Class to animate an image
	/// https://gist.github.com/almirage/e9e4f447190371ee6ce9
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
			StartCoroutine(Animate(this.Delay));
		}

		/// <summary>
		/// Coroutine to animate the image
		/// </summary>
		private IEnumerator Animate(float delay)
		{
			while (true)
            {
				image.sprite = Sprites[index];
				index++;
				if (index >= Sprites.Length)
				{
					if (Loop) index = 0;
					if (DestroyOnEnd) Destroy(gameObject);
				}
				yield return new WaitForSeconds(delay);
			}
		}
	}
}
