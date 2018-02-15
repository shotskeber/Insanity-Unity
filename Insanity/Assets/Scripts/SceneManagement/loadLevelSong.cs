using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.SoundManagerNamespace;

public class loadLevelSong : MonoBehaviour {

	public enum levelSong{
		Champs,
		Eglise,
		Lavoir,
		maisonBourg,
		Manoir,
		Menu,
		phasePrep,
		GrandePlace,
		PorteVille,
		RueArti,
		other,
	}
	public levelSong SongLevel;
	// Use this for initialization
	void Start () {
		StartCoroutine (lateStart ());

	}
	
	// Update is called once per frame
	void Update () {
	}
	IEnumerator lateStart(){
		SoundM.Instance.stopAllMusic ();
		yield return 0;
		switch (SongLevel) {
		case levelSong.Champs:
			SoundM.Instance.PlayMusic (0);
			break;
		case levelSong.Eglise:
			SoundM.Instance.PlayMusic (1);
			break;
		case levelSong.Lavoir:
			SoundM.Instance.PlayMusic (2);
			break;
		case levelSong.maisonBourg:
			SoundM.Instance.PlayMusic (3);
			break;
		case levelSong.Manoir:
			SoundM.Instance.PlayMusic (4);
			break;
		case levelSong.Menu:
			SoundM.Instance.PlayMusic (5);
			break;
		case levelSong.phasePrep:
			SoundM.Instance.PlayMusic (6);
			break;
		case levelSong.GrandePlace:
			SoundM.Instance.PlayMusic (7);
			break;
		case levelSong.PorteVille:
			SoundM.Instance.PlayMusic (8);
			break;
		case levelSong.RueArti:
			SoundM.Instance.PlayMusic (9);
			break;
		case levelSong.other:
			SoundM.Instance.PlayMusic (7);
			break;
		default:
			SoundM.Instance.PlayMusic (7);
			break;
		}
	}
}
