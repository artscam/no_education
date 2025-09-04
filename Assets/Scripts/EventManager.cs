
using UnityEngine;
using UnityEngine.Events;
public static class EventManager
{
    public static event UnityAction Guitar2;
    public static void onGuitar2() => Guitar2?.Invoke();

    public static event UnityAction DestroyGuitar2;
    public static void onDestroyGuitar2() => DestroyGuitar2?.Invoke();

    public static event UnityAction StudentEscape;
    public static void onStudentEscape() => StudentEscape?.Invoke();
}
