using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Submarine          player;
    [SerializeField] private Image              image;
    [SerializeField] private TextMeshProUGUI    text;
    [SerializeField] private Transform          relativeTransform;

    RectTransform   rectTransform;
    Quaternion      initialRotation;
    Vector3         deltaPos;
    CanvasGroup     canvasGroup;

    void Start()
    {
        rectTransform = transform as RectTransform;
        initialRotation = transform.rotation;
        deltaPos = transform.position - relativeTransform.transform.position;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.item == null)
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 0.0f);
            canvasGroup.FadeOut(0.25f);
        }
        else
        {
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 12.0f);
            image.sprite = player.item.resourceImage;
            text.text = $"x{player.itemCount}";
            text.color = player.item.displayColor;
            canvasGroup.FadeIn(0.25f);
        }
    }

    private void LateUpdate()
    {
        transform.rotation = initialRotation;
        transform.position = relativeTransform.position + deltaPos;
    }
}
