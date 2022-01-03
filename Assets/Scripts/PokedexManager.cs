using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokedexManager : MonoBehaviour
{
    public static PokedexManager instance;

    public GameObject pokedexItemPrefab;
    public Transform pokedexContent;
    public Transform pokeballIcon;
    public Button searchButton;

    public GameObject pokedexDetailPanel;
    public TMP_InputField searchInputField;

    List<PokedexItem> itemList;
    
    //private int currentPokemon = 0;

    void Awake()
    {
        instance = this;
        itemList = new List<PokedexItem>();
        pokedexItemPrefab = Resources.Load<GameObject>("Prefabs/PokedexItem");
    }

    void Start()
    {
        PokemonDataUtil.initMovesMap();
        PokemonDataUtil.initTypes();

        pokedexDetailPanel.SetActive(false);
        searchButton.onClick.AddListener(delegate
        {
            AudioHandler.instance.playClickClip();
            onSearch();
        });
        searchInputField.onValueChanged.AddListener(delegate
        {
            AudioHandler.instance.playSelectClip();
            onInputFieldChanged();
        });

        drawPokedexItems();
    }

    void Update()
    {
        pokeballIcon.Rotate(new Vector3(0, 0, 1) * 60 * Time.deltaTime);
    }
        
    void drawPokedexItems()
    {

       for (int i = 1; i < PokemonDatabase.getPokedexLength(); i++)
        {
            GameObject go = Instantiate(pokedexItemPrefab, pokedexContent);
            PokedexItem pokedexItem = go.AddComponent<PokedexItem>();
            itemList.Add(pokedexItem);
            pokedexItem.initiate(PokemonDatabase.getPokedex()[i]);
        }
    }
    void onSearch()
    {
        string searchString = searchInputField.text;
        if (itemList == null) return;
        for(int i =0; i < itemList.Count; i++)
        {
            if(searchString == null || searchString == "" 
                || itemList[i].getPokemonData().getName().IndexOf(searchString, StringComparison.OrdinalIgnoreCase)>=0)
            {
                itemList[i].gameObject.SetActive(true);
            }
            else
            {
                itemList[i].gameObject.SetActive(false);
            }
        }
    }
    void onInputFieldChanged()
    {
        string searchString = searchInputField.text;
        if (searchString == null || searchString == "")
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].gameObject.SetActive(true);
            }
        }
            
    }

}
