using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Hex : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private List<Hex> _neighbourArray = new List<Hex>();

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private ChooseZoneAction chooseZone;

    private Color currentColor;
    private Vector2Int idHex;
    public Vector2Int PositionInGrid { get; set; }
    public List<Hex> NeighbourArray { get => _neighbourArray; set => _neighbourArray = value; }


    private void Start()
    {
        currentColor = sprite.color;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(PositionInGrid.x + " -" + PositionInGrid.y);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sprite.color = Color.gray;
        chooseZone.CurrentPosition = PositionInGrid;
        gameEvent.Raise();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        sprite.color = currentColor;
    }

    public void OnColorize() 
    {
        sprite.color = Color.gray;
    }

    public void OffColorize() 
    {
        sprite.color = currentColor;
    }


}
