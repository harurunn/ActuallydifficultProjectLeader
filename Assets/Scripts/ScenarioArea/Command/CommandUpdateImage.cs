///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// シナリオの進行に合わせてバックグラウンドを更新するクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandUpdateImage : IPreCommand, ICommand {

	public string Tag {
		get { return "img"; }
	}

	public void Command(Dictionary<string, string> command){
		var filename = command ["image"];
		var background = GameObject.Find ("BackGround").GetComponent<Image> ();
		var sprite = Resources.Load<Sprite> ("Image/" + filename);

		background.sprite = sprite;
	}

	public void PreCommand(Dictionary<string, string> command) {
	}
}
