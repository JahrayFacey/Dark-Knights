using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// namespace BattleSystem
// {
//     [CreateAssetMenu(fileName = "New Character", menuName = "Characters", order = 0)]
[System.Serializable]
public class HeroData
{
    public string Name;
    public int currentHP;
    public float maxHP;
    public float currentMP;
    public float maxMP;
    public float speed;
    public int attack;
    public int defense;
    
}


//}