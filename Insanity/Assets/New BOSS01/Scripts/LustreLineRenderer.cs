using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LustreLineRenderer : MonoBehaviour {

    LineRenderer lr;
    public Transform lustreHaut;
	// Use this for initialization
	void Start () {
        lr = this.gameObject.GetComponent<LineRenderer>();
        lustreHaut.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        lr.SetPosition(1, lustreHaut.position);
	}
}
