using UnityEngine;
using System.Collections.Generic;

public class DecksPresets : MonoBehaviour {

    public Dictionary<string,List<Card>> decks = new Dictionary<string,List<Card>>();
    public System.Random rnd = new System.Random();
    private int x;

    public Queue<Card> Shuffle(List<Card> entry)
    {
        Queue<Card> done = new Queue<Card>();
        for(int i=entry.Count; i > 0; i--)
        {
            x = rnd.Next(0, i);
            done.Enqueue(entry[x]);
        }
        return done;
    }

    public void StandardBuildDeck()
    {
        List<Card> temp = new List<Card>();
        for(int i = 0; i < 30; i++)
        {
            temp.Add(new BuildPlatformCard(i));
        }
        for(int i = 29; i < 40; i++)
        {
            temp.Add(new BuildCatapultCard(i));
        }
        for(int i=39; i < 45; i++)
        {
            temp.Add(new DrawCard(i));
        }
        for(int i=44; i<50; i++)
        {
            temp.Add(new DestroyBuilding(i));
        }
        for(int i = 49; i < 60; i++)
        {
            temp.Add(new BuildDoublePlatformCard(i));
        }
        decks.Add("Standard Building Deck", temp);
    }

    public void StandardCompeteDeck()
    {
        List<Card> temp = new List<Card>();
        for (int i = 0; i < 28; i++)
        {
            temp.Add(new BuildPlatformCard(i));
        }
        for (int i = 27; i < 36; i++)
        {
            temp.Add(new BuildCatapultCard(i));
        }
        for (int i = 35; i < 40; i++)
        {
            temp.Add(new DrawCard(i));
        }
        for (int i = 39; i < 50; i++)
        {
            temp.Add(new DestroyBuilding(i));
        }
        for(int i = 49; i < 55; i++)
        {
            temp.Add(new ForcedCardDrawCard(i));
        }
        for(int i = 54; i < 60; i++)
        {
            temp.Add(new StealFirstCard(i));
        }
        decks.Add("Standard Compete Deck", temp);
    }

    public void BuildTeleportDeck()
    {
        List<Card> temp = new List<Card>();
        temp.Add(new BuildTeleportCard(0));
        for (int i = 1; i < 32; i++)
        {
            temp.Add(new BuildPlatformCard(i));
        }
        for (int i = 31; i < 44; i++)
        {
            temp.Add(new BuildCatapultCard(i));
        }
        for (int i = 43; i < 52; i++)
        {
            temp.Add(new DrawCard(i));
        }
        for (int i = 51; i < 60; i++)
        {
            temp.Add(new BuildDoublePlatformCard(i));
        }
        decks.Add("Build Teleport Deck", temp);
    }

    public void StealthyDeck()
    {
        List<Card> temp = new List<Card>();
        for (int i = 0; i < 20; i++)
        {
            temp.Add(new BuildPlatformCard(i));
        }
        for (int i = 19; i < 25; i++)
        {
            temp.Add(new BuildCatapultCard(i));
        }
        for (int i = 24; i < 35; i++)
        {
            temp.Add(new DrawCard(i));
        }
        for (int i = 34; i < 40; i++)
        {
            temp.Add(new DestroyBuilding(i));
        }
        for (int i = 39; i < 50; i++)
        {
            temp.Add(new ForcedCardDrawCard(i));
        }
        for (int i = 49; i < 60; i++)
        {
            temp.Add(new StealFirstCard(i));
        }
        decks.Add("Stealthy Deck", temp);
    }

    public void QuickEndDeck()
    {
        List<Card> temp = new List<Card>();
        for (int i = 0; i < 20; i++)
        {
            temp.Add(new BuildPlatformCard(i));
        }
        for (int i = 19; i < 25; i++)
        {
            temp.Add(new BuildCatapultCard(i));
        }
        for (int i = 24; i < 35; i++)
        {
            temp.Add(new EverybodyDrawsCard(i));
        }
        for (int i = 34; i < 40; i++)
        {
            temp.Add(new DestroyBuilding(i));
        }
        for (int i = 39; i < 50; i++)
        {
            temp.Add(new ForcedCardDrawCard(i));
        }
        for (int i = 49; i < 60; i++)
        {
            temp.Add(new StealFirstCard(i));
        }
        decks.Add("Quick End Deck", temp);
    }
    // Use this for initialization
    void Start ()
    {
        StandardBuildDeck();
        StandardCompeteDeck();
        BuildTeleportDeck();
        StealthyDeck();
        QuickEndDeck();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
