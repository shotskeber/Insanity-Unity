using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class Boss01_CameraAdjustment : ProCamera2D {

    public IA_Boss_01 iaBoss01_script;
    public ProCamera2DNumericBoundaries cameraBoundary_script;
	public float phase2_bound = 60f;
	public float phase3_bound = 150f;

	// Use this for initialization
	void Start () {
        iaBoss01_script.GetComponent<IA_Boss_01>();
        cameraBoundary_script.GetComponent<ProCamera2DNumericBoundaries>();
    }

    // Update is called once per frame
    void Update () {
        if (iaBoss01_script.phase_2)
        {
            cameraBoundary_script.GetComponent<ProCamera2DNumericBoundaries>().RightBoundary = phase2_bound;
        }

        if (iaBoss01_script.phase_3)
        {
            cameraBoundary_script.GetComponent<ProCamera2DNumericBoundaries>().RightBoundary = phase3_bound;
        }
    }
}
