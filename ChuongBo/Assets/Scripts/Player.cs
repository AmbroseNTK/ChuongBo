using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Locale locale;
	// Use this for initialization
	void Start () {
        Setting.GetInstance().LoadSetting();
        locale = new LocaleVi();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDestroy()
    {
        Setting.GetInstance().Close();
    }
}
