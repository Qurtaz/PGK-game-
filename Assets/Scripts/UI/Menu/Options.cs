using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class Options : MonoBehaviour {
    public MenageOptions sound;
    public MenageOptions effects;
    public GameObject data;
    private OptionsData options;
	// Use this for initialization
	void Start () {
        if(File.Exists(Application.persistentDataPath + "/Options.data"))
        {
            Load();
        }
        else
        {
            options.sound = 100;
            options.efect = 100;
            options.efectMute = false;
            options.soundMute = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(data.activeSelf)
        {
            sound.SetData(options.sound, options.soundMute);
            effects.SetData(options.efect, options.efectMute);
            options.Set(sound.GetValue(), effects.GetValue(), sound.GetMute(), effects.GetMute());
        }
	
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/Options.data", FileMode.OpenOrCreate);
        OptionsData op = new OptionsData();
        op.Copy(options);

        bf.Serialize(file, op);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/Options.data"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Options.data", FileMode.Open);
            OptionsData op = (OptionsData)bf.Deserialize(file);
            file.Close();
            options.Copy(op);
        }
    }

}
[Serializable]
public struct OptionsData
{
    public float sound;
    public float efect;
    public bool soundMute;
    public bool efectMute;
    public void Copy(OptionsData op)
    {
        this.sound = op.sound;
        this.efect = op.efect;
        this.efectMute = op.efectMute;
        this.soundMute = op.soundMute;
    }
    public void Set(float sound, float effect, bool muteSound, bool muteEfect)
    {
        this.sound = sound;
        this.efect = effect;
        this.soundMute = muteSound;
        this.efectMute = muteEfect;
    }
}
