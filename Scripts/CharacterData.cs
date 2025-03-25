// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;
// [System.Serializable]
// public class CharacterData
// {
//     public string CharacterName = "CharacterName";
//     [Space(10)]
//     public int MaxHP = 100;
//     public int CurrHP = 100;

//     [Space(10)]

//     public int MaxMP = 100;
//     public int CurrMP = 100;
//     [Space(10)]
//     public float speed;

//     [Space(10)]

//     public CharacterState characterState;
//     public CharacterTeam characterTeam;

//     [Space(16)]

//     public CharacterData _target;
//     public bool CanAttackTarget;


//     public void Init()
//     {
//         onPlayerAttacked.AddListener(CharacterAttacked);
//     }

//     public UnityEvent onPlayerAttacked;

//     public bool playerJustAttacked;

//     public bool CanAttackTarget
//     {
//         get
//         {
//             return _target.characterState == CharacterState.Idle || _target.characterState == CharacterState.Ready;
//         }
//         }

//         void CharacterAttacked()
//         {
//             playerJustAttacked = false;
//         }

// }
//  public IEnumerator CharacterBehaviour()
//     { //Base character target
//         yield return new WaitUntil(() => CanAttackTarget);

//         yield return new WaitUntil(() => playerData.playerJustAttacked);
//         onPlayerAttacked.Invoke();
//     }

//     public IEnumerator CharacterLoop()
//     {

//     }

// public enum CharacterTeam
// {
//     Friendly,
//     Enemy
// } 
// public enum CharacterState
// {
//     Loading,
//     Idle,
//     Ready,
//     Attacked,
//     Attacking,
//     Died
// }
