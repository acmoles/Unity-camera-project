using UnityEngine;
using System.Collections;

public class cubeBehaviour : MonoBehaviour {

    public int speed = 1;
    Animator CubeAnim;

	// Use this for initialization
	void Awake () {
        CubeAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        AnimStarter ();
	}

    void AnimStarter ()
    {
        bool CheckKey = Input.GetKeyDown("space");
        CubeAnim.SetBool("DoAction", CheckKey);
        CubeAnim.speed = speed;
    }
}
