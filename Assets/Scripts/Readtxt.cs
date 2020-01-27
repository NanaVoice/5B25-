using UnityEngine;
using System.Collections;

public class ReadTxt : MonoBehaviour
{

    public TextAsset mytxt;
    void OnGUI()
    {
        GUILayout.Label(mytxt.text);
    }
}
