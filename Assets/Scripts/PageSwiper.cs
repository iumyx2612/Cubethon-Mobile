using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    [SerializeField]
    private float left = 0, right = 0;
    private float threshold = 0.3f;
    [SerializeField]
    private float distance = 800;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        rectTransform.offsetMax = new Vector2(0, 0);
        rectTransform.offsetMin = new Vector2(0, 0);
    }

    private void Update()
    {
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, 0);
        rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, 0);
    }

    public void OnDrag(PointerEventData data)
    {
        float x_diff = data.pressPosition.x - data.position.x;
        rectTransform.offsetMax = new Vector2(-right - x_diff, 0);
        rectTransform.offsetMin = new Vector2(-left - x_diff, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        //Why does it work, wtf is this????????????
        //float x_diff = data.pressPosition.x - data.position.x;
        //right = right + x_diff;
        //Debug.Log("New Right: " + right);
        //left = left + x_diff;
        //Debug.Log("New Left: " + left);
        //rectTransform.offsetMax = new Vector2(-right, 0);
        //rectTransform.offsetMin = new Vector2(-left, 0);

        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= threshold)
        {
            float new_left = left;
            float new_right = right;
            if (percentage >= 0)
            {
                new_left += distance;
                new_right += distance;
            }
            else
            {
                new_left -= distance;
                new_right -= distance;
            }
            rectTransform.offsetMax = new Vector2(-new_right, 0);
            rectTransform.offsetMin = new Vector2(-new_left, 0);
            right = new_right;
            left = new_left;
        }
        else
        {
            rectTransform.offsetMax = new Vector2(-right, 0);
            rectTransform.offsetMin = new Vector2(-left, 0);
        }
    }
}
