﻿///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// Title画面からSelect画面への遷移
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScreen : MonoBehaviour {
	public void onTap(){
		SceneController.Instance.SceneLoad ("Select", 1.0f);
	}
}
