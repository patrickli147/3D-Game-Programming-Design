using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySpace {
    public class UserGUI : MonoBehaviour {
        private string guide = "游戏规则：\n小船核载两人\n船上有人才会移动\n任意一边恶魔多于牧师，牧师死亡，游戏结束\n";
        private IUserAction action;
        private GUIStyle guideStyle;
        private GUIStyle buttonStyle;
        private GUIStyle textStyle;
        public CharacterController characterController;
        public int status = 0;
        public bool flag = false;
        void Start() {
            //status = 3;
            action = Director.GetInstance().CurrentSecnController as IUserAction;
        }

        void OnGUI() {
            textStyle = new GUIStyle {
                fontSize = 60,
                alignment = TextAnchor.MiddleCenter
            };
            textStyle.normal.textColor = Color.white;
            guideStyle = new GUIStyle {
                fontSize = 30,
                fontStyle = FontStyle.Normal
            };
            guideStyle.normal.textColor = Color.yellow;
            buttonStyle = new GUIStyle("Button") {
                fontSize = 24
            };
            GUI.Label(new Rect(50, 150, 100, 50), guide, guideStyle);
            GUI.Label(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 250, 100, 50), "Priest And Devil", textStyle);
            GUI.Label(new Rect(50, Screen.height / 2 - 400, 100, 50), "友情提示：\n立方形表示牧师\n球形表示恶魔", guideStyle);
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 150, 120, 80), "Restart", buttonStyle)) {
                status = 0;
                action.Restart();
            }
            //if (status != 1 && status != 0)
            if(status == -1) {
                //游戏结束
                flag = true;
                GUI.Label(new Rect(Screen.width / 2 - 60, 500, 100, 50), "You Lose!", textStyle);
            }
            if (status == 1) {
                GUI.Label(new Rect(Screen.width / 2 - 60, 500, 100, 50), "You Win!", textStyle);

            }
            //Debug.Log("Status" + aa);
        }
        public void SetCharacterCtrl(CharacterController _cc) {
            characterController = _cc;
        }

        public void OnMouseDown() {
            //Debug.Log("status" + status);
            if (flag == true) return;
            if (gameObject.name == "boat") {
                action.MoveBoat();
            }
            else {
                action.CharacterClicked(characterController);
            }
        }
    }
}