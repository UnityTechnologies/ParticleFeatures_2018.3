using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public static class UniteEvent
{
    public enum Location
    {
        Seoul,
        Tokyo,
        Beijing,
        LA,
        Berlin
    }

    const string k_KPreferenceName = "Location-Event";

    public static Action locationChanged;

    public static Location location
    {
        get { return (Location)PlayerPrefs.GetInt(k_KPreferenceName, (int)Location.Seoul); }
        set
        {
            PlayerPrefs.SetInt(k_KPreferenceName, (int)value);
            if (Application.isPlaying && locationChanged != null)
                locationChanged();
        }
    }

    #if UNITY_EDITOR
    [MenuItem("Unite/Location/Seoul")]
    static void SetSeoul()
    {
        location = Location.Seoul;
    }

    [MenuItem("Unite/Location/Seoul", true)]
    static bool ValidateSeoul()
    {
        return location != Location.Seoul;
    }

    [MenuItem("Unite/Location/Tokyo")]
    static void SetTokyo()
    {
        location = Location.Tokyo;
    }

    [MenuItem("Unite/Location/Tokyo", true)]
    static bool ValidateTokyo()
    {
        return location != Location.Tokyo;
    }

    [MenuItem("Unite/Location/Beijing")]
    static void SetBeijing()
    {
        location = Location.Beijing;
    }

    [MenuItem("Unite/Location/Beijing", true)]
    static bool ValidateBeijing()
    {
        return location != Location.Beijing;
    }

    [MenuItem("Unite/Location/LA")]
    static void SetLA()
    {
        location = Location.LA;
    }

    [MenuItem("Unite/Location/LA", true)]
    static bool ValidateLA()
    {
        return location != Location.LA;
    }

    [MenuItem("Unite/Location/Berlin")]
    static void SetBerlin()
    {
        location = Location.Berlin;
    }

    [MenuItem("Unite/Location/Berlin", true)]
    static bool ValidateBerlin()
    {
        return location != Location.Berlin;
    }
    #endif
}
