using UnityEngine;
using System.Collections;

namespace Helper
{
    public static class InputPlayer
    {
        public static string VERTICALL ="Vertical";
        public static string HORIZONTAL ="Horizontal";
        public static string JUMP = "Jump";
        public static string CANCEL = "Cancel";
        public static string MOUSEX = "Mouse X";
        public static string MOUSEY = "Mouse Y";
        public static string MOUSESCROLL = "Mouse ScrollWheel";
		public static string WHEELPRESS = "Fire3";
		public static string MOUSE0 = "Fire1";
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
}
public struct WorldPos
{
    public int x, y, z;
    public WorldPos(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public override bool Equals(object obj)
    {
        if (!(obj is WorldPos))
        {
            return false;
        }
        else
        {
            WorldPos pos = (WorldPos)obj;
            if (pos.x != x || pos.y != y || pos.z != z)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
    public static WorldPos GetBlockPos(Vector3 pos)
    {
        WorldPos blockPos = new WorldPos(
            Mathf.RoundToInt(pos.x),
            Mathf.RoundToInt(pos.y),
            Mathf.RoundToInt(pos.z)
            );

        return blockPos;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}