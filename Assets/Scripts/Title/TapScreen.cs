using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScreen : MonoBehaviour {
	public void onTap(){
		SceneController.Instance.SceneLoad ("Select", 1.0f);
	}
}
