using UnityEngine;
using System.Collections;

public class BuffDestroy : MonoBehaviour {
    public Buff buff;
    private ControlerGame _gameControler;
    private BuffMenager _buffMenager;
	// Use this for initialization
	void Start () {
        _gameControler = gameObject.GetComponentInParent<BuffMenager>().GetGameControler();
        _buffMenager = gameObject.GetComponentInParent<BuffMenager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if( buff.TurnToFinish(_gameControler.GetPlayerTurn()))
        {
            _buffMenager.Destroy(gameObject);
        }
	}
}
