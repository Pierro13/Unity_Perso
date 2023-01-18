using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestCoroutines : MonoBehaviour
{
    [SerializeField] Transform[] m_WayPoints; IEnumerator m_MyCoroutine;���� // Start is called before the first frame update
��� void Start()
    {
������� //StartCoroutine(WaitCoroutine(2));
������� //StartCoroutine(UpdateCoroutineIA());
������� //StartCoroutine(UpdateCoroutineGameLogic());
������� //StartCoroutine(MyTools.TranslationCoroutine(transform,transform.position, transform.position + Random.onUnitSphere * 6, 2));
��� }
    private void Update()
    {
        MyTools.LOG(this, "UPDATE");
    }
    IEnumerator WaitCoroutine(float waitDuration)
    {
        Debug.Log("START WaitCoroutine");
        yield return new WaitForSeconds(waitDuration);
        Debug.Log("END WaitCoroutine");
    }
    IEnumerator UpdateCoroutineIA()
    {
        MyTools.LOG(this, "Start UpdateCoroutineIA");
        while (true)
        {
            MyTools.LOG(this, "Update UpdateCoroutineIA");
            yield return null; // atends la prochaine frame
������� }
        MyTools.LOG(this, "End UpdateCoroutineIA"); yield break; // return violent
��� }
    IEnumerator UpdateCoroutineGameLogic()
    {
        MyTools.LOG(this, "Start UpdateCoroutineGameLogic");
        while (true)
        {
            MyTools.LOG(this, "Update UpdateCoroutineGameLogic");
            yield return null; // atends la prochaine frame
������� }
        MyTools.LOG(this, "End UpdateCoroutineGameLogic"); yield break; // return violent
��� }
    IEnumerator PatrolCoroutine(Transform[] wayPoints, float translationSpeed)
    {
        int indexWayPoint = 0; while (true)
        {
            yield return StartCoroutine(MyTools.TranslationCoroutine(transform, wayPoints[indexWayPoint % wayPoints.Length].position,
            wayPoints[(indexWayPoint + 1) % wayPoints.Length].position,
            translationSpeed)); yield return new WaitForSeconds(1);
            indexWayPoint++;
        }
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 200, 40), "STOP COROUTINE"))
        {
            StopCoroutine(m_MyCoroutine);
            m_MyCoroutine = null;
        }
        if (GUI.Button(new Rect(10, 50, 200, 40), "STOP ALL COROUTINES"))
        {
            StopAllCoroutines();
            m_MyCoroutine = null;
        }
        if (GUI.Button(new Rect(10, 90, 200, 40), "START COROUTINE"))
        {
            m_MyCoroutine = PatrolCoroutine(m_WayPoints, 4); // Closure ... attention la m�thode n'est pas appel�e ici
����������� StartCoroutine(m_MyCoroutine);
        }
    }
}