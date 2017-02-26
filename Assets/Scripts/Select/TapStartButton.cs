///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// Startボタンを押した時の処理
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapStartButton : MonoBehaviour {
	public void onTap(){
		SceneController.Instance.SceneLoad ("Main", 1.0f);
	}
}
