using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveDetailHandler : MonoBehaviour
{
    public PokedexType type;
    public TMP_Text nameText, powerText, accuracyText, descriptionText;


    public void updateInfo(MoveData pokemonMove)
    {
        nameText.text = pokemonMove.getName();
        type.initiate(PokemonDataUtil.getTypeByEnum(pokemonMove.getType()));
        powerText.text = "power: " + pokemonMove.getPower().ToString();
        accuracyText.text = "accuracy: " + (pokemonMove.getAccuracy() * 100).ToString() + " %";
        descriptionText.text = "description"; /////pokemonMove.getDescription();
    }
    
}
