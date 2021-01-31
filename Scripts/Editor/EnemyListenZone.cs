using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Enemy_MudGuard))]
public class EnemyListenZone : Editor
{


    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void OnDrawGizmo(Enemy_MudGuard enemy, GizmoType gizmoType)
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(enemy.transform.position, Vector3.forward, enemy.listenZone);
    }
}
