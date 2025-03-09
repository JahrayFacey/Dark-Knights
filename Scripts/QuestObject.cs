using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class Quests{
        public string Questtitle;
        public string questObj1;
    }
public class QuestObject : MonoBehaviour
{
public GameObject questObj;
public TextMeshProUGUI QuestName, QuestObjecitve;
public Quests[] questObjs;

public void StartNewQuest(Quests tempObj){
    QuestName.text = tempObj.Questtitle;
    QuestObjecitve.text = tempObj.questObj1;
    questObj.SetActive(true);
    Invoke("CloseQuest", 7f);
}

private void CloseQuest()
{
    questObj.SetActive(false);
}
}
}
