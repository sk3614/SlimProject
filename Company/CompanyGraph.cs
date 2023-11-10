using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompanyGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    public RectTransform graphContainer;
    public List<GameObject> GO= new List<GameObject>();
    private void Awake()
    {
    }

    public GameObject CreateCircle(Vector2 anchoredPosition,int size=20)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(size, size);
        GO.Add(gameObject);
        return gameObject;
    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0,0.5f);
        if (dotPositionA.y==0||dotPositionB.y==0)
        {
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.sizeDelta = new Vector2(distance, 6f);
        rectTransform.anchoredPosition = dotPositionA+dir*distance*0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        GO.Add(gameObject);
    }

    public void ShowGraph(List<int> valueList,int maxvalue,int minvalue)
    {
        ClearGO();
        float xSize = -400;
        GameObject lastCircleGameobject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize + 100f * i;
            float yPosition;
            if (valueList[i]>=0)
            {
                yPosition = 250 * ((float)valueList[i] / maxvalue);
            }
            else
            {
                yPosition = 250 * ((float)valueList[i] / -minvalue);
            }
            
            GameObject circleGameObject=CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameobject != null)
            {
                CreateDotConnection(lastCircleGameobject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameobject = circleGameObject;
        }
    }
    public void ShowGraph(List<int> valueList, int maxvalue)
    {
        ClearGO();
        float xSize = 100;
        GameObject lastCircleGameobject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize + 200f * i;
            float yPosition = 425 * ((float)valueList[i] / maxvalue);

            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition),35);
            if (lastCircleGameobject != null)
            {
                CreateDotConnection(lastCircleGameobject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameobject = circleGameObject;
        }
    }
    public void ClearGO()
    {
        for (int i = GO.Count; i > 0; i--)
        {
            GameObject tmpGO = GO[i-1];
            GO.Remove(tmpGO);
            Destroy(tmpGO);
        }
    }
}
