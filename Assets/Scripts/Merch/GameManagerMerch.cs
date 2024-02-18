using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum BehaviorStrategy
{
    altruist,
    deceiver,
    cunning,
    unpredictable,
    vindictive,
    quirky
}

public class GameManagerMerch : MonoBehaviour
{
    [SerializeField] private GameObject _character;
    [SerializeField] private Transform _panelChar;
    private List<CharacterMerch> allCharacters;

    void Start()
    {
        allCharacters = new List<CharacterMerch>();
        InitCharacters();
    }

    private void InitCharacters()
    {
        for (int i = 0; i < 60; i++)
        {
            var character = Instantiate(_character, _panelChar).GetComponent<CharacterMerch>();
            allCharacters.Add(character);
            character.number = i;
            if (i > 50)
            {
                character.state = BehaviorStrategy.quirky;
                character.init();
                continue;
            }

            if (i > 40)
            {
                character.state = BehaviorStrategy.vindictive;
                character.init();
               continue;
            }

            if (i > 30)
            {
                character.state = BehaviorStrategy.unpredictable;
                character.init();
               continue;
            }

            if (i > 20)
            {
                character.state = BehaviorStrategy.cunning;
                character.init();
                continue;
            }

            if (i > 10)
            {
                character.state = BehaviorStrategy.deceiver;
                character.init();
                continue;
            }

            character.state = BehaviorStrategy.altruist;
            character.init();
        }
    }

    private void Trade()
    {
        
    }
   
    void Update()
    {
    }
}