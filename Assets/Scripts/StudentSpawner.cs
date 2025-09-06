using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
    public int spawnCount = 10;
    public Student Student;
    public float speed = 3f;
    public int WaitAt = 0; // break students up into waves
    public float WaitTime = 0f;
    public GameObject Target;
    public GameObject EntranceTrigger;
    public GameObject playerFollow;
    public GameObject EscapeTrigger;
    public Transform hinterland;
    public float timescale = 1f;
    float timer;
    float subTimer = 0f;
    private int totalStudents;

    private void Start()
    {
        totalStudents = spawnCount;
    }
    public void SpawnStudent()
    {
        Student newStudent =  Instantiate(Student);
        newStudent.transform.position = transform.position;
        newStudent.Target = Target;
        newStudent.playerFollow = playerFollow;
        newStudent.speed = speed;
        newStudent.GrinderEntry = EntranceTrigger;
        newStudent.EscapeTrigger = EscapeTrigger;
        newStudent.freedomDrive = Random.Range(0.2f, 1f);
        newStudent.hinterland = hinterland;
    }

    
    void Update()
    {
        if (spawnCount == totalStudents - WaitAt & subTimer < WaitTime)
        {
            subTimer += Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
            if ((timer >= timescale) & spawnCount > 0)
            {
                SpawnStudent();
                timer = 0;
                spawnCount--;
            }
        }
    }

}
