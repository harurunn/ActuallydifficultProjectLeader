///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// シナリオのテキストファイルを切り替えるクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandJumpNextScenario : IPreCommand {

	public string Tag {
		get {	return "jump"; }
	}

	public void PreCommand (Dictionary<string, string> command) {
		var scenario = GameObject.Find ("ScenarioArea").GetComponent<ScenarioManager> ();
		var fileName = command["fileName"];
		scenario.UpdateLines (fileName);
	}
}
