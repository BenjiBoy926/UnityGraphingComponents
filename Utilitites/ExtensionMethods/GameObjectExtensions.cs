using UnityEngine;
using System.Text;

public static class GameObjectExtensions
{
    public static string Path(this GameObject src)
    {
        StringBuilder builder = new StringBuilder(src.name);
        Transform current = src.transform.parent;

        while (current != null)
        {
            // Insert the name at the beginning of the string
            builder.Insert(0, "/");
            builder.Insert(0, current.gameObject.name);

            // Update current game object
            current = current.transform.parent;
        }

        // Insert the name of the scene the GameObject is in,
        // or inser the keyword "Assets" if the GameObject is not in a scene
        builder.Insert(0, ":/");
        if (src.scene != null)
        {
            builder.Insert(0, src.scene.name);
        }
        else builder.Insert(0, "<Assets>");

        return builder.ToString();
    }
}
