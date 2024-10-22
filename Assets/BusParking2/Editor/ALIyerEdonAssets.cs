// ALIyerEdon@gmail.com - Writed at July 2021
// All rights reserved

using UnityEditor;
using UnityEngine;

public class ALIyerEdonAssets : EditorWindow
{
    [MenuItem("Window/Game Templates")]
    public static void ShowWindow()
    { 
        GetWindow<ALIyerEdonAssets>(false, "Game Templates", true);
    }
    public static void DrawUILine(Color color, int thickness = 2, int padding = 10)
    {
        Rect r = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
        r.height = thickness;
        r.y += padding / 2;
        r.x -= 2;
        r.width += 6;
        EditorGUI.DrawRect(r, color);
    }

    private const int windowWidth = 610;
    private const int windowHeight = 500;
    Vector2 _scrollPosition;
    public bool dontShow;

    void OnEnable()
    {
        titleContent = new GUIContent("Complete Game Templates");
        maxSize = new Vector2(windowWidth, windowHeight);
        minSize = maxSize;

    }

    private void OnGUI()
    {
              
        Texture2D border = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/border.psd") as Texture2D;
        Texture2D ad1 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad1.psd") as Texture2D;
        Texture2D ad2 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad2.psd") as Texture2D;
        Texture2D ad3 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad3.psd") as Texture2D;
        Texture2D ad4 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad4.psd") as Texture2D;
        Texture2D ad5 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad5.psd") as Texture2D;
        Texture2D ad6 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad6.psd") as Texture2D;
        Texture2D ad7 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad7.psd") as Texture2D;
        Texture2D ad8 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad8.psd") as Texture2D;
        Texture2D ad9 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad9.psd") as Texture2D;
        Texture2D ad10 = EditorGUIUtility.Load("Assets/BusParking2/Textures/UI/Ads/ad10.psd") as Texture2D;

        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("Buy My Complete Game Templates", MessageType.None);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition,
                     false,
                     false,
                     GUILayout.Width(windowWidth),
                     GUILayout.Height(windowHeight-20));        //---------Ad 1-------------------------------------------------
                                                                      //  GUILayout.BeginVertical("Box");

        //_scrollPosition = EditorGUILayout.BeginScrollView(scrollViewRect, _scrollPosition, new Rect(0, 0, 2000, 2000));
       
        if (GUILayout.Button(border, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/publishers/23606");
        }
       
        if (GUILayout.Button(ad1, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/truck-parking-kit-81767");
        }

        if (GUILayout.Button(ad2, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/2d-racing-game-76989");
        }

        if (GUILayout.Button(ad3, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/traffic-ride-template-86956");
        }

        if (GUILayout.Button(ad4, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/off-road-truck-template-2-76990");
        }

        if (GUILayout.Button(ad5, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/tools/physics/real-drift-manager-78510");
        }

        if (GUILayout.Button(ad6, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/traffic-race-crash-template-83204");
        }

        if (GUILayout.Button(ad7, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/car-parking-kit-2-2-71914");
        }

        if (GUILayout.Button(ad8, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/car-parking-template-3-106716");
        }

        if (GUILayout.Button(ad9, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/car-parking-kit-1-7-116482");
        }

        if (GUILayout.Button(ad10, "", GUILayout.Width(600), GUILayout.Height(130)))
        {
            Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/bus-parking-kit-2-107077");
        }
        EditorGUILayout.EndScrollView();

    }
}


[InitializeOnLoad]
public class Startup
{
    static Startup()
    { 
        EditorPrefs.SetInt("showCounts_BPK", EditorPrefs.GetInt("showCounts_BPK") + 1);
        if (EditorPrefs.GetInt("showCounts_BPK") < 2)
        {       
            EditorApplication.ExecuteMenuItem("Window/Game Templates");
        }           
        else    
        { 
            if(EditorPrefs.GetInt("showCounts_BPK") >= 20)
               EditorPrefs.SetInt("showCounts_BPK", 0); 
        }            
    }
}
