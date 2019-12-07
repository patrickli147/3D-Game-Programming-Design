using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using baseCode ;

public class FirstSceneGuiCtrl : MonoBehaviour {
	firstScenceUserAction action ;
	bool ifShowHelp = true;
	string helpText = "黑色代表魔鬼，白色代表牧师。";
	// Use this for initialization
	void Start () {
		action = Director.getInstance().currentSceneController as firstScenceUserAction;
	}
	
	// Update is called once per frame
	void OnGUI () {
		firstScenceUserAction action = Director.getInstance().currentSceneController as firstScenceUserAction;
		string status = action.getStatus ();
		if (ifShowHelp == true) {
			GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 90, 200, 100), "" );
			GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 90, 200, 100), helpText);
			if(	GUI.Button (new Rect (Screen.width / 2 - 20, Screen.height / 2 + 60, 40, 30), "了解") ){
				ifShowHelp = false;

			} 

		}

		if (GUI.Button (new Rect(10 , 10 , 100, 50), "规则") ) {
			ifShowHelp = true;
		}



		if (status == "playing") {
			if (GUI.Button (new Rect(130 , 10 , 100, 50), "重新开始")) {
				action.reset ();
			}
		}
		else {
			string showMsg;
			if (status == "lost") {
				showMsg = "你输了!!";
			}
			else {
				showMsg = "你赢了!!";
			}
			if (GUI.Button (new Rect(Screen.width/2-50, Screen.height/2-25, 100, 50), showMsg) ) {
				action.reset ();
			}
		}

		if (GUI.Button (new Rect(250 , 10 , 100, 50), "帮助")) {
			action.nextStep ();
		}
	}
}
