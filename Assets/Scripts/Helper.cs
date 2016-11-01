using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Helper
{
    public static class InputPlayer
    {
        public static string VERTICALL = "Vertical";
        public static string HORIZONTAL = "Horizontal";
        public static string JUMP = "Jump";
        public static string CANCEL = "Cancel";
        public static string MOUSEX = "Mouse X";
        public static string MOUSEY = "Mouse Y";
        public static string MOUSESCROLL = "Mouse ScrollWheel";
        public static string WHEELPRESS = "Fire3";
        public static string MOUSE0 = "Fire1";
		public static string MOUSE1 = "Fire2";
        public static string ROTAION_OBJECT = "Rotation";
    }
    public static class GameTag
    {
        public static string UNTAGGED = "Untagged";
        public static string RESPAWN = "Respawn";
        public static string FINISH = "Finish";
        public static string EDITORONLY = "EditorOnly";
        public static string MAINCAMERA = "MainCamera";
        public static string PLAYER = "Player";
        public static string GAMECONTROLER = "GameController";
    }
    [System.Serializable]
    public class CardUI
        {
            public GameObject plane;
            public Text cardTitle;
        }
}