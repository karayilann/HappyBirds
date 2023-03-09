using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    monster[] _monsters;
    [SerializeField] string nextLevelName;

    void OnEnable()
    {
        _monsters = FindObjectsOfType<monster>();
    }

    void Update()
    {
        if (MonstersDie())
        {
            GoNextLevel();
        }
    }

    void GoNextLevel()
    {
        Debug.Log("Go To Next Level " + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
    }

    bool MonstersDie()                   // Monsterlarýn tamamý ölünce olmasý gerekenler
    {
        foreach(var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)    
                return false;
        }
        return true;
    
    }
}
