
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokedexAbility : MonoBehaviour
{
    public Image background;
    public TMP_Text abilityText;
    void Awake()
    {
        background = GetComponent<Image>();
        abilityText = transform.Find("abilityText").GetComponent<TMP_Text>();
    }

    public void initiate(string ability, bool isHidden)
    {
        if (ability != null) { this.abilityText.text = ability; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
