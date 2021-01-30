using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PatrolPath))]
public class PatrolPathGizmo : Editor
{

    public void OnSceneGUI()
    {
        var path = target as PatrolPath;
        using (var cc=new EditorGUI.ChangeCheckScope())
        {
            var sp = path.transform.InverseTransformPoint(Handles.PositionHandle(path.transform.TransformPoint(path.startPos), path.transform.rotation));
            var ep = path.transform.InverseTransformPoint(Handles.PositionHandle(path.transform.TransformPoint(path.endPos), path.transform.rotation));
            if (cc.changed)
            {
                ep.y = sp.y;
                path.startPos = sp;
                path.endPos = ep;
            }
        }
        Handles.Label(path.transform.position, (path.startPos - path.endPos).magnitude.ToString());
    }

    [DrawGizmo(GizmoType.Selected|GizmoType.NonSelected)]
    static void OnDrawGizmo(PatrolPath path,GizmoType gizmoType)
    {
        var start = path.transform.TransformPoint(path.startPos);
        var end = path.transform.TransformPoint(path.endPos);
        Handles.color = Color.red;
        Handles.DrawDottedLine(start, end, 5);
        Handles.DrawSolidDisc(start, path.transform.forward,0.05f);
        Handles.DrawSolidDisc(end, path.transform.forward,0.05f);
    }

    
}
