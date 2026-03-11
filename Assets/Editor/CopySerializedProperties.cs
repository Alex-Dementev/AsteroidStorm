#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class CopyFields
{
    static Component source;

    [MenuItem("CONTEXT/Component/Copy Fields")]
    static void Copy(MenuCommand cmd)
    {
        source = cmd.context as Component;
    }

    [MenuItem("CONTEXT/Component/Paste Fields")]
    static void Paste(MenuCommand cmd)
    {
        if (source == null) return;

        Component target = cmd.context as Component;

        SerializedObject src = new SerializedObject(source);
        SerializedObject dst = new SerializedObject(target);

        SerializedProperty prop = src.GetIterator();

        while (prop.NextVisible(true))
        {
            if (prop.name == "m_Script") continue;

            SerializedProperty dstProp = dst.FindProperty(prop.name);
            if (dstProp == null) continue;
            if (dstProp.propertyType != prop.propertyType) continue;

            switch (prop.propertyType)
            {
                case SerializedPropertyType.Integer:
                    dstProp.intValue = prop.intValue;
                    break;

                case SerializedPropertyType.Float:
                    dstProp.floatValue = prop.floatValue;
                    break;

                case SerializedPropertyType.Boolean:
                    dstProp.boolValue = prop.boolValue;
                    break;

                case SerializedPropertyType.String:
                    dstProp.stringValue = prop.stringValue;
                    break;

                case SerializedPropertyType.ObjectReference:
                    dstProp.objectReferenceValue = prop.objectReferenceValue;
                    break;

                case SerializedPropertyType.Enum:
                    dstProp.enumValueIndex = prop.enumValueIndex;
                    break;

                case SerializedPropertyType.Vector2:
                    dstProp.vector2Value = prop.vector2Value;
                    break;

                case SerializedPropertyType.Vector3:
                    dstProp.vector3Value = prop.vector3Value;
                    break;

                case SerializedPropertyType.Color:
                    dstProp.colorValue = prop.colorValue;
                    break;
            }
        }

        dst.ApplyModifiedProperties();
    }
}
#endif