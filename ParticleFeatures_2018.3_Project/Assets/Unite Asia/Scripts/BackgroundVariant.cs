using UnityEngine;
using UnityEngine.UI;

public class BackgroundVariant : MonoBehaviour
{
    [System.Serializable]
    public struct UniteLogo
    {
        public UniteEvent.Location unite;
        public Sprite sprite;
    }

    public UniteLogo[] logos;

    public Image target;

    public const string kPreferenceName = "Unite-Event";

    void OnEnable()
    {
        UniteEvent.locationChanged += UpdateLogo;
        UpdateLogo();
    }

    void OnDisable()
    {
        UniteEvent.locationChanged -= UpdateLogo;
    }

    void UpdateLogo()
    {
        var uniteEvent = UniteEvent.location;

        foreach (var uniteLogo in logos)
        {
            if (uniteLogo.unite == uniteEvent)
            {
                target.sprite = uniteLogo.sprite;
                return;
            }
        }

        Debug.Log("Logo not found for: " + uniteEvent, gameObject);
    }


}
