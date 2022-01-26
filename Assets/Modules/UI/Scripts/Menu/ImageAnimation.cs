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
		private int frame = 0;

		public Sprite[] sprites;
		public int spritePerFrame = 6;
		public bool loop = true;
		public bool destroyOnEnd = false;

		/// <summary>
		/// Is called when the script instance is being loaded.
		/// </summary>
		void Awake()
		{
			image = GetComponent<Image>();
		}

		/// <summary>
		/// Is called every frame, if the MonoBehaviour is enabled. Called other method based on Key Input.
		/// </summary>
		void Update()
		{
			if (!loop && index == sprites.Length) return;
			frame++;
			if (frame < spritePerFrame) return;
			image.sprite = sprites[index];
			frame = 0;
			index++;
			if (index >= sprites.Length)
			{
				if (loop) index = 0;
				if (destroyOnEnd) Destroy(gameObject);
			}
		}
	}
}
