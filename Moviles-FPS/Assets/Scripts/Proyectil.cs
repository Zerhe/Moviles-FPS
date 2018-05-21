using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proyectil : MonoBehaviour {

	public abstract void Activarse(Vector3 pos, Quaternion rot);
    public abstract void Desactivarse();
    public abstract void AddVelocity();


}
