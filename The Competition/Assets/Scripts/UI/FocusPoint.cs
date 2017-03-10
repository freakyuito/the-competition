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


	void Update(){
		if (Input.GetKeyDown (KeyCode.A))
			show ();
		if (Input.GetKeyDown (KeyCode.B))
			hide ();
	}
	public void show(){
		transform.DOScale (Vector3.one, 0.5f).SetEase (Ease.OutBounce);
		transform.DORotate (Vector3.forward * 90f, 5f).SetEase (Ease.Linear).SetLoops (-1, LoopType.Incremental).SetId(GetInstanceID() + 1);
		transform.GetComponent<SpriteRenderer> ().DOFade (0f, 1f).SetEase (Ease.InOutCubic).SetLoops (-1, LoopType.Yoyo).SetId(GetInstanceID() + 2);
		SendMessage ("beginAction");
	}

	public void hide(){
		DOTween.Kill (GetInstanceID() + 1);
		DOTween.Kill (GetInstanceID () + 2);
		transform.DOScale (Vector3.zero, 0.5f).onComplete = delegate() {
			GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
		};
	}

	public void onClick(){
		hide ();
		_infoPanel.show ();
	}

}
