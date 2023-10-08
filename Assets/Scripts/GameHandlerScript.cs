using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameHandlerScript : MonoBehaviour
{
    public static CanvasGroup SomePanel;
    public CanvasGroup SignupPanel;
    public TMP_InputField username;
    public static UsersContainer usersContainer;
    // Start is called before the first frame update
    public static string path = "Assets/users.json";


    void Start()
    {
        SomePanel = SignupPanel;
    }
    public void saveProfile()
    {
        //UsersContainer usersContainer = new UsersContainer();
        Student newStudent = new Student();
        newStudent.username = username.text;
        newStudent.level = 1;
        usersContainer.students.Add(newStudent);

        string jsonText = JsonUtility.ToJson(usersContainer);
        Debug.Log(jsonText);
        System.IO.File.WriteAllText(path, jsonText);
        Debug.Log("ahot");
    }


    public static void loadProfiles() //called after the menu animation is complete.
    {
        if (System.IO.File.Exists(path))
        {
            string jsonText = System.IO.File.ReadAllText(path);
            usersContainer = JsonUtility.FromJson<UsersContainer>(jsonText);


            //Check if there's already accounts registered, if none, then registration panel will popup.
            if (usersContainer.students.Count <= 0)
            {
                Debug.Log("eyyy");
                AnimationManager.ZoomIn(SomePanel);
            }else{
               
            }
        }

    }

}
[System.Serializable]
public class Student
{
    public string username;
    public int level;

}
[System.Serializable]
public class UsersContainer
{
    public List<Student> students = new List<Student>();
}