using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class HandleAttacks
{
    public string Attacker; // name of unit
    public string Type;
    public GameObject AttackGameObject; // who attacks
    public GameObject AttackersTarget; // the target of the action

    // which attack is performed
}
