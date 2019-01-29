using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemySight))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI() {
        EnemySight es = (EnemySight)target;
        Handles.color = Color.yellow;
        Handles.DrawWireArc(es.transform.position, Vector3.up, Vector3.forward, 360, es.viewRadius);
        Handles.color = Color.red;
        Handles.DrawWireArc(es.transform.position, Vector3.up, Vector3.forward, 360, es.tooCloseRadius);
        Vector3 viewAngleA = es.DirFromAngle(-es.viewAngle / 2, false);
        Vector3 viewAngleB = es.DirFromAngle(es.viewAngle / 2, false);

        Handles.DrawLine(es.transform.position, es.transform.position + viewAngleA * es.viewRadius);
        Handles.DrawLine(es.transform.position, es.transform.position + viewAngleB * es.viewRadius);

        Handles.color = Color.cyan;
        if (es.playerVisible != null) Handles.DrawLine(es.transform.position, es.playerVisible.position);

    }
}
