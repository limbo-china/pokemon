using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonMove
{
    public int id;
    public string name;
    public string type;
    public float power;
    public float accuracy;
    public string description;

    public PokemonMove(int id, string name, string type, float power, float accuracy, string description)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.power = power;
        this.accuracy = accuracy;
        this.description = description;
    }
}
