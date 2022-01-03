using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokedexType : MonoBehaviour
{

    public Image background;
    public TMP_Text typeText;
    void Awake()
    {
        background= GetComponent<Image>();
        typeText= transform.Find("typeText").GetComponent<TMP_Text>();
    }

    public void initiate(PokemonType type)
    {
        this.background.color = type.color;
        this.typeText.text = type.type;
    }
}
