using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Vector3 panelPosition; // Vị trí của Panel;
    private float threshold = 0.2f; // Threshold để khi swipe quá 1/3 panel thì sẽ chuyển sang panel mới
    private float distance = 800f; // Khoảng cách giữa các Panel
    private float easing = 0.5f; // How long in seconds we want our panel to ease into the location

    private GameObject playerList;
    private Vector3 playerListPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        panelPosition = transform.localPosition;
        // Set vị trí cho Panel Holder để luôn ở vị trí ban đầu 
        rectTransform.offsetMax = new Vector2(0, 0);
        rectTransform.offsetMin = new Vector2(0, 0);
        playerList = GameObject.Find("Player List");
        playerListPosition = playerList.transform.position;
    }

    private void Update()
    {
        //Somehow khi Drag thì Panel bị đổi top và bottom? Set top và bottom = 0
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, 0);
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, 0);
    }

    public void OnDrag(PointerEventData data)
    {     
        float x_diff = data.pressPosition.x - data.position.x; // Khoảng cách giữa lúc tay chạm vào và hiện tại
        // Set lại vị trí Left và Right của Rect Transform
        transform.localPosition = panelPosition - new Vector3(x_diff, 0, 0);
        playerList.transform.position = playerListPosition - new Vector3(x_diff, 0, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / distance;
        if(Mathf.Abs(percentage) > threshold)
        {
            Vector3 newLocation = panelPosition;
            Vector3 newPlayerListLocation = playerListPosition;
            if (percentage < 0)
            {
                newLocation += new Vector3(distance, 0, 0);
                newPlayerListLocation += new Vector3(Screen.width, 0, 0);
            }
            else if(percentage > 0)
            {
                newLocation += new Vector3(-distance, 0, 0);
                newPlayerListLocation += new Vector3(-Screen.width, 0, 0);
            }
            StartCoroutine(SmoothMove(transform.localPosition, newLocation, easing));
            StartCoroutine(PlayerSmoothMove(playerList.transform.position, newPlayerListLocation, easing));
            panelPosition = newLocation;
            playerListPosition = newPlayerListLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.localPosition, panelPosition, easing));
            StartCoroutine(PlayerSmoothMove(playerList.transform.position, playerListPosition, easing));
        }
    }

    IEnumerator SmoothMove(Vector2 startPos, Vector2 endPos, float seconds)
    {
        float t = 0;
        while(t <= 1)
        {
            t += Time.deltaTime / seconds;
            transform.localPosition = Vector2.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
    }
    IEnumerator PlayerSmoothMove(Vector2 startPos, Vector2 endPos, float seconds)
    {
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime / seconds;
            playerList.transform.position = Vector2.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
    }

}
