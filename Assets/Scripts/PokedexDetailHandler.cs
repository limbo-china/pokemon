using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokedexDetailHandler : MonoBehaviour
{
    public static PokedexDetailHandler instance;
    public TMP_Text pokemonId, pokemonName, descriptionText;

    public Image sprite;
    public Transform types, abilities, stats, description;
    GameObject pokedexTypePrefab, pokedexAbilityPrefab;
    public PokedexMoveHandler pokedexMovePanel;
    public Button backButton;
    

    void setData(PokemonData pokemonData)
    {
        pokemonId.text = "#"+PokemonDataUtil.convertLongID(pokemonData.getID());
        pokemonName.text = pokemonData.getName();
        sprite.sprite = PokemonDataUtil.getSpriteById(pokemonData.getID());
        drawTypes(pokemonData);
        drawAbilities(pokemonData);
        descriptionText.text = pokemonData.getPokedexEntry();
        drawStatsBars(pokemonData);
        drawMoves(pokemonData);
    }
    void Awake()
    {
        instance = this;
        pokedexTypePrefab = Resources.Load<GameObject>("Prefabs/PokedexType");
        pokedexAbilityPrefab = Resources.Load<GameObject>("Prefabs/PokedexAbility");
    }
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(delegate { 
            AudioHandler.instance.playClickClip(); 
            closePanel(); 
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void drawTypes(PokemonData pokemonData)
    {
        Transform type1 = types.GetChild(0);
        Transform type2 = types.GetChild(1);
        PokedexType pokedexType = type1.GetComponent<PokedexType>();
        pokedexType.initiate(PokemonDataUtil.getTypeByEnum(pokemonData.getType1()));
        if (pokemonData.getType2() == PokemonData.Type.NONE)
        {
            type2.gameObject.SetActive(false);
            return ;            
        }
        type2.gameObject.SetActive(true);
        PokedexType pokedexType2 = type2.GetComponent<PokedexType>();
        pokedexType2.initiate(PokemonDataUtil.getTypeByEnum(pokemonData.getType2()));
    }
    void drawAbilities(PokemonData pokemonData)
    {
        Transform[] abilitiesTransforms = { abilities.GetChild(0), abilities.GetChild(1), abilities.GetChild(2) };
        for (int i = 0; i < 3; i++)
        {
            if (pokemonData.getAbility(i) != null)
            {
                abilitiesTransforms[i].gameObject.SetActive(true);
                PokedexAbility pokedexAbility = abilitiesTransforms[i].GetComponent<PokedexAbility>();
                pokedexAbility.initiate(pokemonData.getAbility(i), (i < 2) ? false : true);
            }
            else
            {
                abilitiesTransforms[i].gameObject.SetActive(false);
            }
        }
    }
    void drawStatsBars(PokemonData pokemonData)
    {
        Transform statsBars = stats.GetChild(0);
        int[] statsValues = pokemonData.getBaseStats();
        for(int i =0;i < statsBars.childCount;i++)
        {
            statsBars.GetChild(i).GetChild(0).GetComponent<TMP_Text>().text = statsValues[i].ToString();
            statsBars.GetChild(i).GetComponent<Image>().fillAmount = statsValues[i] / 200f;
        }
    }
    void drawMoves(PokemonData pokemonData)
    {
        pokedexMovePanel.setMoves(pokemonData);
    }
    public void showPanel(PokemonData pokemonData)
    {
        PokedexManager.instance.pokedexDetailPanel.SetActive(true);
        setData(pokemonData);
    }
    public void closePanel()
    {
        PokedexManager.instance.pokedexDetailPanel.SetActive(false);
    }
}
