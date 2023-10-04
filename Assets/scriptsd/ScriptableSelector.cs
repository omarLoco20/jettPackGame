using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "scriptableObject", menuName = "scriptables/scriptableSelector")]
public class ScriptableSelector : ScriptableObject
{
    public int life;
    public float force;
    public Sprite character;
    public Quaternion rotacion;


}
