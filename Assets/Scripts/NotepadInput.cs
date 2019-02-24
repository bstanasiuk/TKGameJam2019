using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NotepadInput : MonoBehaviour
{
    #region saving
    const string notepadHashKey = "noteKey";

    private void Start()
    {
        if (!PlayerPrefs.HasKey(notepadHashKey)) PlayerPrefs.SetString(notepadHashKey, "");
        notepad.text = PlayerPrefs.GetString(notepadHashKey);
    }

    #endregion

    TextMeshProUGUI _notepad;
    TextMeshProUGUI notepad
    {
        get
        {
            if(_notepad == null)
            {
                _notepad = GetComponent<TextMeshProUGUI>();              
            }
           
            return _notepad;
        }
    }
    List<KeyCode> keys = new List<KeyCode> {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5,
        KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0,
        KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P,
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon,
        KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.Comma, KeyCode.Period, KeyCode.Slash };
    Dictionary<KeyCode, string> keysLiteral = new Dictionary<KeyCode, string>
    {
        { KeyCode.Alpha1, "1" },
        { KeyCode.Alpha2, "2" },
        { KeyCode.Alpha3, "3" },
        { KeyCode.Alpha4, "4" },
        { KeyCode.Alpha5, "5" },
        { KeyCode.Alpha6, "6" },
        { KeyCode.Alpha7, "7" },
        { KeyCode.Alpha8, "8" },
        { KeyCode.Alpha9, "9" },
        { KeyCode.Alpha0, "0" },
        { KeyCode.Q, "q" },
        { KeyCode.W, "w" },
        { KeyCode.E, "e" },
        { KeyCode.R, "r" },
        { KeyCode.T, "t" },
        { KeyCode.Y, "y" },
        { KeyCode.U, "u" },
        { KeyCode.I, "i" },
        { KeyCode.O, "o" },
        { KeyCode.P, "p" },
        { KeyCode.A, "a" },
        { KeyCode.S, "s" },
        { KeyCode.D, "d" },
        { KeyCode.F, "f" },
        { KeyCode.G, "g" },
        { KeyCode.H, "h" },
        { KeyCode.J, "j" },
        { KeyCode.K, "k" },
        { KeyCode.L, "l" },
        { KeyCode.Semicolon, ";" },
        { KeyCode.Z, "z" },
        { KeyCode.X, "x" },
        { KeyCode.C, "c" },
        { KeyCode.V, "v" },
        { KeyCode.B, "b" },
        { KeyCode.N, "n" },
        { KeyCode.M, "m" },
        { KeyCode.Comma, "," },
        { KeyCode.Period, "." },
        { KeyCode.Slash, "/" }
    };

    // Update is called once per frame
    void Update()
    {
        WriteInput();
    }

    public void WriteInput()
    {
        foreach (KeyValuePair<KeyCode, string> e in keysLiteral)
        {
            if (Input.GetKeyDown(e.Key))
            {
                notepad.text += e.Value;
                PlayerPrefs.SetString(notepadHashKey, notepad.text);
            }
        }
    }
}
