using System;
using UnityEngine;

public class PointController : MonoBehaviour
{

    public GUIText total;
    public GUIText coin;

    private static PointController m_instance;

    public static PointController instance
    {
        get
        {
            if (m_instance == false)
            {
                m_instance = FindObjectOfType<PointController>();
            }
            return m_instance;
        }
    }

    public void AddCoin()
    {
        coin.text = (Convert.ToInt32(coin.text) + 1).ToString("00");
        total.text = (Convert.ToInt32(total.text) + 100).ToString("0000000");
    }
}
