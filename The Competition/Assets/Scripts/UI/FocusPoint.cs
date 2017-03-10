using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FocusPoint : MonoBehaviour {

	public InfoPanel _infoPanel = null;
	public List<string> myTitle = new List<string> ();
	public List<Sprite> myPic = new List<Sprite>();
	public List<string> myIntro = new List<string>();

	public void show(){
		transform.DOScale (Vector3.one, 0.5f).SetEase (Ease.OutBounce);
		transform.DORotate (Vector3.forward * 90f, 5f).SetEase (Ease.Linear).SetLoops (-1, LoopType.Incremental);
		transform.GetComponent<Image> ().DOFade (1f, 1f).SetEase (Ease.OutExpo).SetLoops (-1, LoopType.Yoyo);
	}

	public void hide(){
		
	}

}
