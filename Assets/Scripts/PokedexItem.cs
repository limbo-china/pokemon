using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PokedexItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Image pokemonSprite;
    public Text pokemonIdText;
    public Text pokemonNameText;
    public Transform types;
    public GameObject pokedexTypePrefab;
    private PokemonData pokemonData;

    void Awake()
    {
        button = GetComponent<Button>();
        Transform content = transform.Find("content");
        pokemonSprite = content.Find("sprite").GetComponent<Image>();
        //types = content.Find("types");
        pokemonIdText = content.Find("title").Find("id").GetComponent<Text>();
        pokemonNameText = content.Find("title").Find("name").GetComponent<Text>();
        //pokedexTypePrefab = Resources.Load<GameObject>("Prefabs/PokedexType");  
    }
    void Start()
    {
        button.onClick.AddListener(() => onClickItem(pokemonData));
    }
    public void initiate(PokemonData pokemonData)
    {
        this.pokemonData = pokemonData;
        pokemonSprite.sprite = PokemonDataUtil.getSpriteById(pokemonData.getID()); //只用一张图
        pokemonIdText.text = PokemonDataUtil.convertLongID(pokemonData.getID());
        pokemonNameText.text = pokemonData.getName();
        //GameObject go = Instantiate(pokedexTypePrefab, types);
        //PokedexType pokedexType = go.AddComponent<PokedexType>();
        //pokedexType.initiate(PokedexManager.instance.types[pokemonData.getType1()]);
        //if(pokemonData.getType2() != PokemonData.Type.NONE)
        //{
        //    GameObject go2 = Instantiate(pokedexTypePrefab, types);
        //    PokedexType pokedexType2 = go2.AddComponent<PokedexType>();
        //    pokedexType2.initiate(PokedexManager.instance.types[pokemonData.getType2()]);
        //}
    }
    void onClickItem(PokemonData pokemonData)
    {
        if(pokemonData == null) {  return; }

        AudioHandler.instance.playClickClip();
        PokedexDetailHandler.instance.showPanel(pokemonData);
          
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioHandler.instance.playSelectClip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    public PokemonData getPokemonData()
    {
        return pokemonData;
    }
}
