﻿using UnityEngine;
using System.Collections;

public class GameManager
{
    public event System.Action<Player> OnPlayerJoined;
    private GameObject gameObject;

    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
                m_Instance.gameObject.AddComponent<Timer>();
                m_Instance.gameObject.AddComponent<Respawner>();
				m_Instance.gameObject.AddComponent<atractionController> ();
            }
            return m_Instance;
        }
    }

    private InputController m_InputController;
    public InputController InputController
    {
        get
        {
            if (m_InputController == null) m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;
        }
    }

    private Timer m_Timer;
    public Timer Timer
    {
        get
        {
            if (m_Timer == null) m_Timer = gameObject.GetComponent<Timer>();
            return m_Timer;
        }
    }

    private Respawner m_Respawner;
    public Respawner Respawner
    {
        get
        {
            if (m_Respawner == null) m_Respawner = gameObject.GetComponent<Respawner>();
            return m_Respawner;
        }
    }

    private Player m_Player;
    public Player Player
    {
        get
        {
            return m_Player;
        }
        set
        {
            m_Player = value;
            if (OnPlayerJoined != null) OnPlayerJoined(m_Player);
        }
    }

	private atractionController m_atractionController;
	public atractionController atractionController
	{
		get
		{
			if (m_atractionController == null)  m_atractionController = gameObject.GetComponent<atractionController>();
			return  m_atractionController;
		}
	}
}
