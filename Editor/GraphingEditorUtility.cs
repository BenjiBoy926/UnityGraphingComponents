using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class GraphingEditorUtility
{
    private static int currentHoverID = 0;

    public static float standardControlHeight
    {
        get
        {
            return EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        }
    }

    public static bool ResponsiveGUIButton(Rect rect, GUIContent content, GUIStyle style)
    {
        // Paint the button
        bool ret = GUI.Button(rect, content, style);

        if(Event.current.type == EventType.MouseMove)
        {
            // Get control with focus
            int newHoverID = GUIUtility.GetControlID(content, FocusType.Passive);

            // Check if the mouse is in this button
            if (rect.Contains(Event.current.mousePosition))
            {
                if (newHoverID != currentHoverID)
                {
                    currentHoverID = newHoverID;

                    // Repaint the editor window with the mouse
                    if (EditorWindow.mouseOverWindow != null)
                    {
                        EditorWindow.mouseOverWindow.Repaint();
                    }
                }
            }
            // If the rect does not contain the mouse position,
            // but this recently had the hover,
            // the mouse has exited, so repaint the window
            else if(newHoverID == currentHoverID)
            {
                currentHoverID = 0;

                if(EditorWindow.mouseOverWindow != null)
                {
                    EditorWindow.mouseOverWindow.Repaint();
                }
            }
        }

        return ret;
    }
}
