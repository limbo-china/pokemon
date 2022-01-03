using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokedexMoveHandler : MonoBehaviour
{
    public static PokedexMoveHandler instance;
    public Transform movesContent;
    public Transform detailPanelPivotFlag;
    Vector2 flagLocalPoint;
    
    GameObject pokedexMoveItemPrefab;
    GameObject moveDetailPanelPrefab;
    GameObject moveDetailPanel;
    bool isMoveDetailPanelShow;
    RectTransform moveDetailPanelTransform;

    MoveDetailHandler moveDetailHandler;
    MoveData currPokemonMove;

    ArrayList moveItemList;

    float hoverTime = 0;
    public float secondsToPopUpDetail = 1.5f;

    public void setMoves(PokemonData pokemonData)
    {
        int[] levels = pokemonData.getMovesetLevels();
        string[] moves = pokemonData.getMovesetMoves();
        PokedexMoveItem pokedexMoveItem;
        for (int i = 0; i < moves.Length; i++)
        {
            if (moveItemList != null && i >= moveItemList.Count)
            {
                GameObject go = Instantiate(pokedexMoveItemPrefab, movesContent);
                pokedexMoveItem = go.AddComponent<PokedexMoveItem>();
                moveItemList.Add(pokedexMoveItem);
            }
            else
            {
                pokedexMoveItem = (PokedexMoveItem)moveItemList[i];
            }
            if (pokedexMoveItem != null)
            {
                pokedexMoveItem.gameObject.SetActive(true);
                pokedexMoveItem.initiate(levels[i], PokemonDataUtil.getMoveDataByName(moves[i]));//////
            }
        }
        if (moveItemList != null)
        {
            for (int i = moves.Length; i < moveItemList.Count; i++)
            {
                pokedexMoveItem = (PokedexMoveItem)moveItemList[i];
                pokedexMoveItem.gameObject.SetActive(false);
            }
        }
    }
    void Awake()
    {
        instance = this;
        moveItemList = new ArrayList();
        pokedexMoveItemPrefab = Resources.Load<GameObject>("Prefabs/PokedexMoveItem");
        moveDetailPanelPrefab = Resources.Load<GameObject>("Prefabs/MoveDetailPanel");
    }
    // Start is called before the first frame update
    void Start()
    {
        moveDetailPanel = Instantiate(moveDetailPanelPrefab, this.transform);
        moveDetailHandler = moveDetailPanel.GetComponent<MoveDetailHandler>();
        moveDetailPanelTransform = moveDetailPanel.GetComponent<RectTransform>();
        moveDetailPanel.SetActive(false); 
        isMoveDetailPanelShow = false;

        flagLocalPoint = convertToVector2(detailPanelPivotFlag.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveDetailPanelShow)
        {
            hoverTime += Time.deltaTime;
            if(currPokemonMove != null && hoverTime > secondsToPopUpDetail)
            {
                moveDetailHandler.updateInfo(currPokemonMove);
                moveDetailPanel.SetActive(true);
                Vector2 pos = currMousePosition();
                if (pos.y >= flagLocalPoint.y)
                {
                    moveDetailPanelTransform.pivot = new Vector2(1, 1);

                }
                else
                {
                    moveDetailPanelTransform.pivot = new Vector2(1, 0);
                }
                moveDetailPanelTransform.anchoredPosition = pos;
            }            
        }
        else
        {
            hoverTime = 0;
        }
    }
    public void showMoveDetailPanel(MoveData pokemonMove)
    {
        if (moveDetailPanel != null && !isMoveDetailPanelShow)
        {
            currPokemonMove = pokemonMove;
            isMoveDetailPanelShow = true;
        }
    }
    public void closeMoveDetailPanel()
    {
        if (moveDetailPanel != null && isMoveDetailPanelShow)
        {
            moveDetailPanel.SetActive(false);
            isMoveDetailPanelShow = false;
        }
    }
    Vector2 convertToVector2(Vector3 vector3)
    {
        Vector2 vecMouse;
        RectTransform parentRectTrans = transform.parent.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTrans, vector3, null, out vecMouse);
        return vecMouse;
    }
    Vector2 currMousePosition()
    {
        return convertToVector2(Input.mousePosition);
    }
}
