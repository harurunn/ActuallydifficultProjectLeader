///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// コマンドに実装するインターフェイス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 文字表示が終わった後に呼び出される
public interface ICommand {
	string Tag{get;}
	void Command(Dictionary<string, string> command);
}
	
// 事前に呼ばれるコマンド
public interface IPreCommand {
	string Tag{get;}
	void PreCommand(Dictionary<string, string> command);
}
