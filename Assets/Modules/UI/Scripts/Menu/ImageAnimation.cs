using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    public class ImageAnimation : MonoBehaviour
	{
		private int index = 0;
		private Image image;
		private int frame = 0;

		public Sprite[] sprites;
		public int spritePerFrame = 6;
		public bool loop = true;
		public bool destroyOnEnd = false;

		void Awake()
		{
			image = GetComponent<Image>();
		}

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
