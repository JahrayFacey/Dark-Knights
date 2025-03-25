using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}


public class BattleSystem_Simple : MonoBehaviour
{

    public GameObject playerPrefab_1;
    public GameObject playerPrefab_2;
    public GameObject EnemyPrefab_1;
    public GameObject EnemyPrefab_2;

    public Transform playerBattleStation_1;
    public Transform playerBattleStation_2;
    public Transform enemyBattleStation_1;
    public Transform enemyBattleStation_2;

    public BattleState state;
    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();

    }

    void SetupBattle()
    {
        Instantiate(playerPrefab_1, playerBattleStation_1);
        Instantiate(playerPrefab_2, playerBattleStation_2);
        Instantiate(EnemyPrefab_1, enemyBattleStation_1);
        Instantiate(EnemyPrefab_2, enemyBattleStation_2);
    }

}
