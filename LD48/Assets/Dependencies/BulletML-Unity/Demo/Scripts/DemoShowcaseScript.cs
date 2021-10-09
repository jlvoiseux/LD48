// Copyright © 2014 Pixelnest Studio
// This file is subject to the terms and conditions defined in
// file 'LICENSE.md', which is part of this source code package.
using UnityEngine;
using System.Linq;

namespace Pixelnest.BulletML.Demo
{
  /// <summary>
  /// Display and play all avaiable patterns
  /// </summary>
  public class DemoShowcaseScript : MonoBehaviour
  {
    public GameObject emitterPrefab;
    public bool showGui = true;

    private GameObject currentEmitter;
    private int currentPatternIndex;
    private TextAsset[] patterns;

    private BulletManagerScript bulletManager;
    private float previousX;

    void Awake()
    {
      // Read /Resources patterns files
      patterns = Resources.LoadAll<TextAsset>("patterns/");
      if (patterns.Length == 0) Debug.LogError("No pattern found in Resources/patterns!");

      
      

      currentPatternIndex = 0;
      CreateCurrentEmitter();
    }


    void Update()
    {

    }

    void OnGUI()
    {
      if (showGui == false) return;

      // Display a list
      int oldIndex = currentPatternIndex;

      if (GUI.Button(new Rect(5, 2, 50, 50), "<"))
      {
        PreviousPattern();
      }

      GUI.Label(new Rect(80, 2, 250, 40), "Current pattern: ");
      GUI.Label(new Rect(80, 22, 250, 40), patterns[currentPatternIndex].name);

      if (GUI.Button(new Rect(350, 2, 50, 50), ">"))
      {
        NextPattern();
      }

      if (GUI.Button(new Rect(415, 2, 50, 50), "Reset"))
      {
        ResetPattern();
      }

      // Change pattern the hard way
      if (oldIndex != currentPatternIndex)
      {
        DeleteCurrentEmitter();
        CreateCurrentEmitter();
      }

      // Stats
      GUI.Label(new Rect(Screen.width - 75, 0, 150, 20), (1.0f / Time.deltaTime).ToString("00") + " FPS");
      GUI.Label(new Rect(Screen.width - 75, 20, 150, 20), (FindObjectsOfType<BulletScript>().Length + " bullets"));

#if !UNITY_EDITOR
      if (GUI.Button(new Rect(5, Screen.height - 30, 200, 25), "Next demo : Boss fight!"))
      {
        Application.LoadLevel("Demo_Fight");
      }
#endif
    }

    private void NextPattern()
    {
      currentPatternIndex++;
      if (currentPatternIndex >= patterns.Length)
      {
        currentPatternIndex = 0;
      }
    }

    private void PreviousPattern()
    {
      currentPatternIndex--;
      if (currentPatternIndex < 0)
      {
        currentPatternIndex = patterns.Length - 1;
      }
    }

    private void ResetPattern()
    {
      if (currentEmitter != null)
      {
        BulletSourceScript emitterScript = currentEmitter.GetComponent<BulletSourceScript>();
        if (emitterScript != null)
        {
          emitterScript.Reset();
        }
      }
    }

    private void DeleteCurrentEmitter()
    {
      if (currentEmitter != null)
      {
        Destroy(currentEmitter);
      }

      // Delete all bullets
      foreach (var b in FindObjectsOfType<BulletScript>())
      {
        Destroy(b.gameObject);
      }
    }

    private void CreateCurrentEmitter()
    {
      currentEmitter = Instantiate(emitterPrefab) as GameObject;

      BulletSourceScript emitterScript = currentEmitter.GetComponent<BulletSourceScript>();
      emitterScript.xmlFile = patterns[currentPatternIndex];

      currentEmitter.SetActive(true);
    }
  }
}