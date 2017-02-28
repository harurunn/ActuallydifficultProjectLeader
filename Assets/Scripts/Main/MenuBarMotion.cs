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

	/// <summary>
	/// アニメーション
	/// </summary>
	public AnimationCurve animCurve = AnimationCurve.Linear (0, 0, 1, 1);
	/// <summary>
	/// スライドインの後のポジション
	/// </summary>
	public Vector3 inPosition;
	/// <summary>
	/// スライドアウトの後のポジション
	/// </summary>
	public Vector3 outPosition;
	/// <summary>
	/// スライド時間
	/// </summary>
	public float slideTime;

	/// <summary>
	/// スライドイン
	/// </summary>
	public void SlideIn(){
		StartCoroutine (StartSlidePanel (true));
	}

	/// <summary>
	/// スライドアウト
	/// </summary>
	public void SlideOut(){
		StartCoroutine (StartSlidePanel (false));
	}

	private IEnumerator StartSlidePanel(bool isSlideIn){
		// 開始時間
		float startTime = Time.time;
		// 開始位置
		Vector3 startPos = transform.localPosition;
		// 移動距離、方向
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
