using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RythmGame : MonoBehaviour
{
    private float scrollSpeed;
    public int tempo;
    public bool randomise = false;
    public int noteCount;

    public Texture rightArrow;
    public Texture leftArrow;
    public Texture upArrow;
    public Texture downArrow;

    public GameObject arrowPrefab;

    GameObject gameArrows;
    RectTransform arrows;

    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = 64*tempo / 60.0f;
        gameArrows = transform.parent.Find("Arrows").gameObject;
        arrows = gameArrows.GetComponent<RectTransform>();
        if(randomise)
        {
            int r = 0;
            Vector3 newPosition;
            GameObject newArrow;
            for (int i = 0; i < noteCount; i++)
            {
                r = Random.Range(0, 4);
                newPosition = new Vector3(-96 + r * 64, i * 64, 0);
                newPosition += gameArrows.transform.position;
                newArrow = Instantiate(arrowPrefab, newPosition, Quaternion.identity,gameArrows.transform);
                switch (r)
                {
                    case 0:
                        newArrow.GetComponent<RawImage>().texture = leftArrow;
                        break;
                    case 1:
                        newArrow.GetComponent<RawImage>().texture = downArrow;
                        break;
                    case 2:
                        newArrow.GetComponent<RawImage>().texture = upArrow;
                        break;
                    case 3:
                        newArrow.GetComponent<RawImage>().texture = rightArrow;
                        break;
                    default:
                        break;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        arrows.Translate(new Vector3(0.0f, -scrollSpeed * Time.deltaTime, 0.0f));

        foreach (Transform child in gameArrows.transform)
        {
            if (child.position.y < -32)
            {
                Destroy(child.gameObject);
                continue;
            }
            else if(child.position.y>64)
            {
                continue;
            }
            if (Input.GetKeyDown(KeyCode.D)&& child.localPosition.x==96)
            {
                Debug.Log("Bang");
                Destroy(child.gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.W) && child.localPosition.x ==32)
            {
                Destroy(child.gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.S) && child.localPosition.x ==-32)
            {
                Destroy(child.gameObject);
            }
            else if (Input.GetKeyDown(KeyCode.A) && child.localPosition.x ==-96)
            {
                Destroy(child.gameObject);
            }

        }

    }
}
