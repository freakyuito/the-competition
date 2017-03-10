using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityStandardAssets.ImageEffects;

public class InfoPanel : MonoBehaviour {

	List<Sprite> pics = new List<Sprite>();
	List<string> intros = new List<string>();
	List<string> titles = new List<string>();
	int sort;
	Image curPic = null;
	Text curTitle,curIntro = null;
	RectTransform myRect = null;
	bool isInDetailMode = false;
	public Button prevBtn = null, nextBtn = null;
	public Blur _blur;
	public float expandWidth;

	void Start(){
		myRect = GetComponent<RectTransform> ();
	}

	public void assign(List<string> tit, List<Sprite> spr, List<string> intr){
		titles = tit;
		pics = spr;
		intros = intr;
		curTitle.text = titles [0];
		curPic.sprite = pics [0];
		curIntro.text = intros [0];
	}

	public void prev(){
		sort--;
		updateInfo ();
	}
	public void next(){
		sort++;
		updateInfo ();
	}
	private void updateInfo(){
		curPic.DOFade (0f, 0.25f).onComplete = delegate() {
			curTitle.text = titles [sort];
			curPic.sprite = pics [sort];
			curIntro.text = intros [sort];
			curPic.DOFade(1f,0.25f);
		};
	}

	void setBtnColor(){
		if (sort == 0) {
			prevBtn.interactable = false;
		} else if (sort == titles.Count) {
			nextBtn.interactable = false;
		} else {
			prevBtn.interactable = nextBtn.interactable = true;
		}
	}

	public void show(){
		_blur.enabled = true;
		myRect.DOScaleY (1f, 0.25f).SetEase (Ease.OutCubic);
	}
	public void hide(){
		_blur.enabled = false;
		myRect.DOScaleY (0f, 0.25f).SetEase (Ease.OutCubic);
	}

	public void details(){
		if (isInDetailMode) {
			isInDetailMode = false;
			shrink ();
		} else {
			isInDetailMode = true;
			expand ();
		}
	}

	private void expand(){
		myRect.DOLocalMoveX (myRect.anchoredPosition.x - expandWidth/2, 0.25f).SetEase (Ease.OutCubic).onComplete = delegate() {
			myRect.DOSize(new Vector2(myRect.rect.width + expandWidth, myRect.rect.height),0.25f);
		};
	}
	private void shrink(){
		myRect.DOSize(new Vector2(myRect.rect.width - expandWidth, myRect.rect.height),0.25f).onComplete = delegate() {
			myRect.DOLocalMoveX (myRect.anchoredPosition.x + expandWidth/2, 0.25f).SetEase (Ease.OutCubic);
		};
	}

}
