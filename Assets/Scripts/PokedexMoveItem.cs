using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PokedexMoveItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text levelText, nameText,typeText;
    public MoveData pokemonMove;
    
    Image background;
    Color blue = new Color(0.05f, 0.75f, 1), white = new Color(1, 1, 1);

    void Awake()
    {
        levelText = transform.Find("level").GetComponent<TMP_Text>();
        nameText = transform.Find("name").GetComponent<TMP_Text>();
        typeText = transform.Find("type").GetComponent<TMP_Text>();
        background = GetComponent<Image>();
    }
    public void initiate(int level, MoveData pokemonMove)
    {
        this.levelText.text = "Lv." + level.ToString();
        this.pokemonMove = pokemonMove;
        this.nameText.text = pokemonMove.getName();
        this.typeText.text = PokemonDataUtil.getTypeByEnum(pokemonMove.getType()).type;
        background.color = PokemonDataUtil.getTypeByEnum(pokemonMove.getType()).color;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        changeColorEnter();
        AudioHandler.instance.playSelectClip();
        PokedexMoveHandler.instance.showMoveDetailPanel(pokemonMove);
    }

    private void changeColorEnter()
    {
        background.color = white;
        levelText.color = blue;
        nameText.color = blue;
        typeText.color = blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        changeColorExit();       
        PokedexMoveHandler.instance.closeMoveDetailPanel();
    }

    private void changeColorExit()
    {
        background.color = PokemonDataUtil.getTypeByEnum(pokemonMove.getType()).color;
        levelText.color = white;
        nameText.color = white;
        typeText.color = white;
    }
}
