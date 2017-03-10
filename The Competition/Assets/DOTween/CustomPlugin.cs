using UnityEngine;
using UnityEngine.UI;

namespace DG.Tweening
{
	public static class CustomPlugin
	{
		public static Tweener DOFade(this Image image, float endValue, float duration){
			return DOTween.To(image.AlphaGetter, image.AlphaSetter, endValue, duration);
		}
		public static Tweener DOFade(this Text text, float endValue, float duration){
			return DOTween.To(text.AlphaGetter, text.AlphaSetter, endValue, duration);
		}
		public static Tweener DOFade(this SpriteRenderer spriteRenderer, float endValue, float duration){
			return DOTween.To(spriteRenderer.AlphaGetter, spriteRenderer.AlphaSetter, endValue, duration);
		}
		private static float AlphaGetter(this Image image){
			return image.color.a;
		}
		private static float AlphaGetter(this Text text){
			return text.color.a;
		}
		private static float AlphaGetter(this SpriteRenderer spriteRenderer){
			return spriteRenderer.color.a;
		}
		private static void AlphaSetter(this Image image, float alpha){
			Color oldColor = image.color;
			oldColor.a = alpha;
			image.color = oldColor;
		}
		private static void AlphaSetter(this Text text, float alpha){
			Color oldColor = text.color;
			oldColor.a = alpha;
			text.color = oldColor;
		}
		private static void AlphaSetter(this SpriteRenderer spriteRenderer, float alpha){
			Color oldColor = spriteRenderer.color;
			oldColor.a = alpha;
			spriteRenderer.color = oldColor;
		}

		public static Tweener DOSize(this RectTransform rTrans, Vector2 endValue, float duration){
			return DOTween.To(rTrans.SizeGetter, rTrans.SizeSetter, endValue, duration);
		}
		private static Vector2 SizeGetter(this RectTransform rTrans){
			return rTrans.rect.size;
		}
		private static void SizeSetter(this RectTransform rTrans, Vector2 size){
			rTrans.sizeDelta = size;
		}
	}
}
