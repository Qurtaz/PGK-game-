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
        _builgingInstruction = "Wciśniecie scrola na myszce ruch kamera "+ 
            "\nLewy klawisz myszy zatwierdzamy budowanie " +
            "\nPrawy klawisz myszy anulujemy budowanie";
        _movingInstruction = "Wciśniecie scrola na myszce ruch kamera " +
            "\nLewy klawisz myszy zatwierdzamy mijce do którego się ruszamy " +
            "\nPrawy klawisz myszy blokujmey ruch";

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
