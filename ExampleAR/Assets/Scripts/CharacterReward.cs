using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterReward : MonoBehaviour
{
    [SerializeField]
    List<Sprite> Characters = new List<Sprite>();

    [SerializeField]
    Image CharacterImage;

    int chosenCharacter;

    // Start is called before the first frame update
    void Start()
    {
        chosenCharacter = Random.Range(0, Characters.Count);
        CharacterImage.sprite = Characters[chosenCharacter];
    }

    // Update is called once per frame
}
