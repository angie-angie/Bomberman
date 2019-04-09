using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    float lifetime = 2;

	void Update () {
        Destroy(gameObject, lifetime);
	}
}
