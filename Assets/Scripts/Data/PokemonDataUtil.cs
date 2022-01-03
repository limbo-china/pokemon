using System.Collections.Generic;
using UnityEngine;

public static class PokemonDataUtil
{
    public static Dictionary<string, MoveData> movesMap;
    public static Dictionary<PokemonData.Type, PokemonType> types;

    public static void initMovesMap()
    {
        movesMap  = new Dictionary<string, MoveData>();
        MoveData[] moves = MoveDatabase.moves;
        for (int i=0; i < moves.Length; i++)
        {
            movesMap.Add(moves[i].getName(), moves[i]);
        }
    }

    public static void initTypes()
    {
        types = new Dictionary<PokemonData.Type, PokemonType>();
        types.Add(PokemonData.Type.PSYCHIC, new PokemonType(new Color(0.95f, 0.4f, 0.72f, 1), "PSYCHIC"));
        types.Add(PokemonData.Type.STEEL, new PokemonType(new Color(0.77f, 0.77f, 0.77f, 1), "STEEL"));
        types.Add(PokemonData.Type.GRASS, new PokemonType(new Color(0.60f, 0.80f, 0.31f, 1), "GRASS"));
        types.Add(PokemonData.Type.POISON, new PokemonType(new Color(0.72f, 0.5f, 0.78f, 1), "POISON"));
        types.Add(PokemonData.Type.FLYING, new PokemonType(new Color(0.24f, 0.78f, 0.94f, 1), "FLYING"));
        types.Add(PokemonData.Type.FIRE, new PokemonType(new Color(1, 0.5f, 0.15f, 1), "FIRE"));
        types.Add(PokemonData.Type.WATER, new PokemonType(new Color(0.27f, 0.57f, 0.75f, 1), "WATER"));
        types.Add(PokemonData.Type.ELECTRIC, new PokemonType(new Color(0.93f, 0.83f, 0.2f, 1), "ELECTRIC"));
        types.Add(PokemonData.Type.FIGHTING, new PokemonType(new Color(0.83f, 0.4f, 0.14f, 1), "FIGHTING"));
        types.Add(PokemonData.Type.BUG, new PokemonType(new Color(0.45f, 0.62f, 0.25f, 1), "BUG"));
        types.Add(PokemonData.Type.DARK, new PokemonType(new Color(0.45f, 0.35f, 0.35f, 1), "DARK"));
        types.Add(PokemonData.Type.DRAGON, new PokemonType(new Color(0.95f, 0.21f, 0.48f, 1), "DRAGON"));
        types.Add(PokemonData.Type.FAIRY, new PokemonType(new Color(1, 0.6f, 0.74f, 1), "FAIRY"));
        types.Add(PokemonData.Type.GHOST, new PokemonType(new Color(0.48f, 0.38f, 0.64f, 1), "GHOST"));
        types.Add(PokemonData.Type.GROUND, new PokemonType(new Color(0.67f, 0.6f, 0.25f, 1), "GROUND"));
        types.Add(PokemonData.Type.ICE, new PokemonType(new Color(0.32f, 0.77f, 0.9f, 1), "ICE"));
        types.Add(PokemonData.Type.NORMAL, new PokemonType(new Color(0.65f, 0.65f, 0.65f, 1), "NORMAL"));
        types.Add(PokemonData.Type.ROCK, new PokemonType(new Color(0.64f, 0.55f, 0.13f, 1), "ROCK"));
    }

    public static PokemonType getTypeByEnum(PokemonData.Type e)
    {
        return types[e];
    }

    public static MoveData getMoveDataByName(string name)
    {
        return movesMap[name];
    }
    public static Sprite getSpriteById(int id)
    {
        Sprite sprite = Resources.Load<Sprite>("PokemonIcons/icon" + convertLongID(id));
        if (sprite)
        {
            return sprite;
        }
        else
        {
            return Resources.Load<Sprite>("PokemonIcons/icon" + convertLongID(1));
        }
        
    }

    public static string convertLongID(int id)
    {
        string result = id.ToString();
        while (result.Length < 3)
        {
            result = "0" + result;
        }
        return result;
    }
}
