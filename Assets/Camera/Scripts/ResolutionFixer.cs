using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFixer : MonoBehaviour
{
	void Start ()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
