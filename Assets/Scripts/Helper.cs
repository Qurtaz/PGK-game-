using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Helper
{
	public static class MousePoint
	{
		public static Vector3 mousePoint(float unit)
		{
			Vector3 hitPoint = new Vector3();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.gameObject.tag == "TopPlatform") {
						hitPoint = hit.collider.attachedRigidbody.transform.position;
					} else {
						hitPoint = hit.point;
					}
					hitPoint.x = Mathf.Round (hitPoint.x / unit) * unit;
					hitPoint.z = Mathf.Round (hitPoint.z / unit) * unit;
					hitPoint.y += 1F;

				}
			
			return hitPoint;
			}
		}



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
    public static class DataString
    {
        public static string BUDOWANIE = "Building";
        public static string RUCH = "Moving";
    }

}