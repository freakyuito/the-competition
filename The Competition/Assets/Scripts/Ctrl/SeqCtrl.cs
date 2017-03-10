using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//this script requires to attach to the main Cam
public class SeqCtrl : MonoBehaviour {

	public FocusPoint[] _focusPoints;
	public InfoPanel _infoPanel;

	int sort;

	public void prev(){
		sort--;
		moveTo ();
	}
	public void next(){
		sort++;
		moveTo ();
	}

	private void moveTo(){
		_infoPanel.hide ();
		transform.DOMove (_focusPoints [sort].transform.position, 0.75f).SetEase (Ease.OutCubic).onComplete = delegate() {
			_infoPanel.assign(_focusPoints[sort].myTitle, _focusPoints[sort].myPic, _focusPoints[sort].myIntro);
			_infoPanel.show();
		};
	}

}
