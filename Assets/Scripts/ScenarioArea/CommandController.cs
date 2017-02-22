///////////////////////////////////////
/// タイトル：実は難しいプロジェクトリーダー
/// ios,androidアプリ
/// フレームワーク:Unity
/// コマンドの判別・処理を行うクラス
///////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CommandController : MonoBehaviour {

	// 文字の表示が完了したタイミングで呼ばれる処理
	private List<IPreCommand> preCommandList = new List<IPreCommand> () {
		new CommandUpdateImage(), new CommandJumpNextScenario()
	};


	private readonly List<ICommand> commandList = new List<ICommand> () {
		new CommandUpdateImage()
	}; 

	/// <summary>
	/// 事前に呼び出すコマンド
	/// </summary>
	/// <param name="line">Line.</param>
	public void PreLoadCommand(string line) {
		var dictionary = CommandAnalytics (line); 
		foreach (var command in preCommandList) {
			if (command.Tag == dictionary["tag"]) {
				command.PreCommand (dictionary);
			}
		}
	}

	/// <summary>
	/// 文字表示が終わった後に呼び出される
	/// 戻り値falseで全てのコマンド終了
	/// </summary>
	/// <param name="line">Line.</param>
	public bool LoadCommand(string line) {
		var dictionary = CommandAnalytics (line);
		foreach (var command in commandList) {
			if (command.Tag == dictionary["tag"]) {
				command.Command(dictionary);
				return true;
			}
		}
		return false;
	}


	/// <summary>
	/// コマンドの処理内容を連想配列で返します
	/// </summary>
	/// <returns>The analytics.</returns>
	/// <param name="line">Line.</param>
	private Dictionary<string, string> CommandAnalytics(string line) {
		Dictionary<string, string> command = new Dictionary<string, string>();
		// コマンド名を取得　\\S+１文字以上の任意の文字列　\\s改行
		var tag = Regex.Match(line, "@(\\S+)\\s");
		// Groupsで正規表現かっこの部分をString型で代入
		command.Add("tag", tag.Groups[1].ToString());

		// コマンドのパラメータ取得
		Regex regex = new Regex("(\\S+)=(\\S+)");
		var matches = regex.Matches(line);

		foreach( Match match in matches ) {
			command.Add(match.Groups[1].ToString(), match.Groups[2].ToString());
		}
		return command;
	}
}
