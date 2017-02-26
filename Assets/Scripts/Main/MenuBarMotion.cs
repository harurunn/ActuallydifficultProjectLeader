///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// メニューバーを押した時非表示の部分が上に出るようにする
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBarMotion : MonoBehaviour {

	public AnimationCurve animCurve = AnimationCurve.Linear (0, 0, 1, 1);
	public Vector3 inPosition;
	public Vector3 outPosition;
	public float slideTime;

	public void SlideIn(){
		StartCoroutine (StartSlidePanel (true));
	}

	public void SlideOut(){
		StartCoroutine (StartSlidePanel (false));
	}

	private IEnumerator StartSlidePanel(bool isSlideIn){
		Debug.Log ("a");
		float startTime = Time.time;
		Vector3 startPos = transform.localPosition;
		Vector3 moveDistance;

		if (isSlideIn) {
			moveDistance = (inPosition - startPos);
		} else {
			moveDistance = (outPosition - startPos);
		}

		while((Time.time - startTime) < slideTime){
			transform.localPosition = startPos + moveDistance * animCurve.Evaluate ((Time.time - startTime) / slideTime);
			yield return 0;
		}
		transform.localPosition = startPos + moveDistance;
	}
}
