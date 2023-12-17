using Firebase;
using Firebase.Database;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Database : MonoBehaviour
{
    public static Database Instance;
    [Space]
    [Header("Create Account")]
    public TMP_InputField UserEmailInput;
    public TMP_InputField UserPasswordInput;


    public UIManager dato;

    private  User user;

    private DatabaseReference dataReference;

    [SerializeField] private string userID;

    public string idKey;

    private void Awake()
    {
        userID = SystemInfo.deviceUniqueIdentifier;

     
    }

    void Start()
    {
        dataReference = FirebaseDatabase.DefaultInstance.RootReference;
        Invoke("CreateUser", 1f);
        Invoke("GetUserInfo", 1f);
        Debug.Log(userID);
    }
    public void CreateUser()
    {
         user = new User();
        if (IsValidEmail(UserEmailInput.text))
        {
            Debug.Log("Correo electrónico válido: " + UserEmailInput.text);

            user.email = UserEmailInput.text;
            string json = JsonUtility.ToJson(user);
            dataReference.Child("users").Child(idKey).SetRawJsonValueAsync(json).ContinueWith(
                task =>
                {
                    if (task.IsCompleted)
                    {
                        Debug.Log("Done Update");
                    }
                    else
                    {
                        Debug.Log("Failed Attempt");
                    }
                });
        }
        else
        {
            Debug.LogError("Formato de correo electrónico incorrecto");
        }
        if(user.password == null)
        {
            user.password = UserPasswordInput.text;
            string json = JsonUtility.ToJson(user);
            dataReference.Child("users").Child(idKey).SetRawJsonValueAsync(json).ContinueWith(
                task =>
                {
                    if (task.IsCompleted)
                    {
                        Debug.Log("Done Update P");
                    }
                    else
                    {
                        Debug.Log("Failed Attempt P");
                    }
                });
        }
        else
        {
            Debug.LogError("Ingrese Contraseña...");
        }
       
        
    }

    //Actualiza Datos - correo
    public void ChangeUsername(string newUserEmail)
    {
        dataReference.Child("users").Child(idKey).Child("email").SetValueAsync(newUserEmail);
        
    }

    public void UpdateScore(string score)
    {
        score = user.password;
        dataReference.Child("users").Child(idKey).Child("password").SetValueAsync(score);
    }
    public string checkEmail()
    {
        string data = user.email;
        return data;
    }
    public string checkPassword()
    {
        string data = user.password;
        return data;
    }

    private IEnumerator GetFirstName(Action<string> onCallBack)
    {
        var userNameData = dataReference.Child("users").Child(idKey).Child("firstName").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallBack?.Invoke(snapshot.Value.ToString());
        }
    }

    private IEnumerator GetLastName(Action<string> onCallBack)
    {
        var userNameData = dataReference.Child("users").Child(idKey).Child("lastName").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallBack?.Invoke(snapshot.Value.ToString());
        }
    }

    private IEnumerator GetCodeID(Action<int> onCallBack)
    {
        var userNameData = dataReference.Child("users").Child(idKey).Child(nameof(User.codeID)).GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            //(int) -> Casting
            //int.Parse -> Parsing
            //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
            onCallBack?.Invoke(int.Parse(snapshot.Value.ToString()));
        }
    }

    private IEnumerator GetEmail(Action<string> onCallBack)
    {
        var userNameData = dataReference.Child("users").Child(idKey).Child("email").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallBack?.Invoke(snapshot.Value.ToString());
        }
    }
    private IEnumerator GetPassword(Action<string> onCallBack)
    {
        var userNameData = dataReference.Child("users").Child(idKey).Child("password").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallBack?.Invoke(snapshot.Value.ToString());
        }
    }

    public void SetScoresData(string scores)
    {
        DatabaseReference scoresReference = dataReference.Child("users").Child(idKey).Child("scores");

        scoresReference.SetValueAsync(scores).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Scores registrados exitosamente");
            }
            else
            {
                Debug.Log("Error al registrar los scores");
            }
        });
    }
    //***
    public void RegisterUserScore(int score)
    {
        DatabaseReference scoresReference = dataReference.Child("users").Child(idKey).Child("scores");

        scoresReference.Push().SetValueAsync(score).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log($"Score {score} registrado exitosamente");
            }
            else
            {
                Debug.Log($"Error al registrar el score {score}");
            }
        });
    }
   
    public void GetUserInfo()
    {
        StartCoroutine(GetFirstName(PrintData));
        StartCoroutine(GetLastName(PrintData));
        StartCoroutine(GetCodeID(PrintData));
        StartCoroutine(GetEmail(PrintData));
        StartCoroutine(GetPassword(PrintData));
    }


    private void PrintData(string name)
    {
        Debug.Log(name);
    }

    private void PrintData(int code)
    {
        Debug.Log(code);
    }
    bool IsValidEmail(string email)
    {
        // Verificar si el correo electrónico contiene "@gmail.com"
        return email.EndsWith("@gmail.com");
    }
}
[Serializable]
public struct User
{
    public string firstName;
    public string lastName;
    public int codeID;
    public string email;
    public string password;
    public User(string firstName, string lastName, int codeID, string emAil, string Password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.codeID = codeID;
        this.email = emAil;
        this.password = Password;
    }

}

