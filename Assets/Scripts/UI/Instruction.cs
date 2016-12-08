using UnityEngine;
using UnityEngine.UI;
using Helper;

public class Instruction : MonoBehaviour {
    public ControlerGame gameControler;
    public Text text;
    private string _builgingInstruction;
    private string _movingInstruction;
    public int howManyTurnSeeInstruction;
	// Use this for initialization
	void Start () {
        _builgingInstruction = "Wciśniecie scroll na myszce: ruch kamera "+ 
            "\nLewy przycisk myszy: zatwierdzenie budowanie " +
            "\nPrawy przycisk myszy: anulowanie budowanie";
        _movingInstruction = "Wciśniecie scroll na myszce: ruch kamera " +
            "\nLewy przycisk myszy: zatwierdzenie wyboru miejsca do którego ma podążyć postać" +
            "\nPrawy prycisk myszy: cofnięcie ruchu";

    }
	
	// Update is called once per frame
	void Update () {
	    if(gameControler.GetPlayerTurn() <= howManyTurnSeeInstruction)
        {
            if(gameControler.GetPlayerPhase() ==  DataString.BUDOWANIE)
            {
                text.text = _builgingInstruction;
            }
            else
            {
                text.text = _movingInstruction;
            }
        }
        else
        {
            text.gameObject.SetActive(false);
        }
	}
}
