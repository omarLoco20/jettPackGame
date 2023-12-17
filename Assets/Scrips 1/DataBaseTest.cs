//using Firebase;
//using Firebase.Database;
//using System;
//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class DatabaseTest : MonoBehaviour
//{
//    public User user;
//    private DatabaseReference dataReference;
//    private string userID;
//    //public InputField emailInput;
//    //public InputField passwordInput;

//    private void Awake()
//    {
//        userID = SystemInfo.deviceUniqueIdentifier;
//    }

//    void Start()
//    {
//        dataReference = FirebaseDatabase.DefaultInstance.RootReference;
//        Invoke("CreateUser", 1f);
//    }
//    private void CreateUser()
//    {
//        //User newUser = new User("Pedro", "Piedrito", 9781235);
//        string json = JsonUtility.ToJson(user);
//        dataReference.Child("users").Child(userID).SetRawJsonValueAsync(json).ContinueWith(
//            task =>
//            {
//                if (task.IsCompleted)
//                {
//                    Debug.Log("Done Update");
//                }
//                else
//                {
//                    Debug.Log("Failed Attempt");
//                }
//            });
//    }

//    private IEnumerator GetFirstName(Action<string> onCallBack)
//    {
//        var userNameData = dataReference.Child("users").Child(userID).Child("firstName").GetValueAsync();

//        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

//        if (userNameData != null)
//        {
//            DataSnapshot snapshot = userNameData.Result;
//            onCallBack?.Invoke(snapshot.Value.ToString());
//        }
//    }

//    private IEnumerator GetLastName(Action<string> onCallBack)
//    {
//        var userNameData = dataReference.Child("users").Child(userID).Child("lastName").GetValueAsync();

//        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

//        if (userNameData != null)
//        {
//            DataSnapshot snapshot = userNameData.Result;
//            onCallBack?.Invoke(snapshot.Value.ToString());
//        }
//    }

//    private IEnumerator GetCodeID(Action<int> onCallBack)
//    {
//        var userNameData = dataReference.Child("users").Child(userID).Child(nameof(User.codeID)).GetValueAsync();

//        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

//        if (userNameData != null)
//        {
//            DataSnapshot snapshot = userNameData.Result;
//            //(int) -> Casting
//            //int.Parse -> Parsing
//            //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
//            onCallBack?.Invoke(int.Parse(snapshot.Value.ToString()));
//        }
//    }

//    public void GetUserInfo()
//    {

//        StartCoroutine(GetFirstName(PrintData));
//        StartCoroutine(GetLastName(PrintData));
//        StartCoroutine(GetCodeID(PrintData));
//    }

//    private void PrintData(string name)
//    {
//        Debug.Log(name);
//    }

//    private void PrintData(int code)
//    {
//        Debug.Log(code);
//    }
//}

//[Serializable]
//public struct User
//{
//    public string firstName;
//    public string lastName;
//    public int codeID;
//    public User(string firstName, string lastName, int codeID)
//    {
//        this.firstName = firstName;
//        this.lastName = lastName;
//        this.codeID = codeID;
//    }
//}

//using Firebase;
//using Firebase.Auth;
//using Firebase.Database;
//using Firebase.Extensions;
//using System;
//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class FirebaseManager : MonoBehaviour
//{
//    public User user;
//    public InputField emailInput;
//    public InputField passwordInput;

//    private DatabaseReference dataReference;
//    private FirebaseAuth auth;
//    private string userID;

//    private void Awake()
//    {
//        userID = SystemInfo.deviceUniqueIdentifier;
//    }

//    void Start()
//    {
//        // Inicializar Firebase
//        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
//        {
//            FirebaseApp app = FirebaseApp.DefaultInstance;
//            auth = FirebaseAuth.GetAuth(app);

//            if (auth != null && auth.CurrentUser != null)
//            {
//                // El usuario ya está autenticado, puedes redirigirlo a la pantalla principal
//                // En este ejemplo, simplemente imprimo el UID del usuario
//                Debug.Log("Usuario ya autenticado. UID: " + auth.CurrentUser.UserId);
//            }
//        });

//        dataReference = FirebaseDatabase.DefaultInstance.RootReference;
//        Invoke("CreateUser", 1f);
//    }

//    private void CreateUser()
//    {
//        if (auth.CurrentUser == null)
//        {
//            // Si el usuario no está autenticado, intenta iniciar sesión o registrarse
//            SignInOrSignUp();
//        }
//        else
//        {
//            // El usuario ya está autenticado, puedes realizar acciones relacionadas con la base de datos
//            string json = JsonUtility.ToJson(user);
//            dataReference.Child("users").Child(userID).SetRawJsonValueAsync(json).ContinueWith(
//                task =>
//                {
//                    if (task.IsCompleted)
//                    {
//                        Debug.Log("Done Update");
//                    }
//                    else
//                    {
//                        Debug.Log("Failed Attempt");
//                    }
//                });
//        }
//    }

//    private void SignInOrSignUp()
//    {
//        // Función para manejar el inicio de sesión o registro según la situación
//        string email = emailInput.text;
//        string password = passwordInput.text;

//        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
//        {
//            if (task.IsCanceled || task.IsFaulted)
//            {
//                // El inicio de sesión falló, intentar el registro
//                SignUp(email, password);
//            }
//            else
//            {
//                // Inicio de sesión exitoso, realizar acciones relacionadas con la base de datos
//                CreateUser();
//            }
//        });
//    }

//    private void SignUp(string email, string password)
//    {
//        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
//        {
//            if (task.IsCanceled || task.IsFaulted)
//            {
//                // El registro también falló, manejar el error según sea necesario
//                Debug.LogError("Error al registrar: " + task.Exception);
//            }
//            else
//            {
//                // Registro exitoso, realizar acciones relacionadas con la base de datos
//                CreateUser();
//            }
//        });
//    }
////..................................................................

//    private IEnumerator GetFirstName(Action<string> onCallBack)
//    {
//        var userNameData = dataReference.Child("users").Child(userID).Child("firstName").GetValueAsync();

//        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

//        if (userNameData != null)
//        {
//            DataSnapshot snapshot = userNameData.Result;
//            onCallBack?.Invoke(snapshot.Value.ToString());
//        }
//    }

//    private IEnumerator GetLastName(Action<string> onCallBack)
//    {
//        var userNameData = dataReference.Child("users").Child(userID).Child("lastName").GetValueAsync();

//        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

//        if (userNameData != null)
//        {
//            DataSnapshot snapshot = userNameData.Result;
//            onCallBack?.Invoke(snapshot.Value.ToString());
//        }
//    }

//    private IEnumerator GetCodeID(Action<int> onCallBack)
//    {
//        var userNameData = dataReference.Child("users").Child(userID).Child(nameof(User.codeID)).GetValueAsync();

//        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

//        if (userNameData != null)
//        {
//            DataSnapshot snapshot = userNameData.Result;
//            //(int) -> Casting
//            //int.Parse -> Parsing
//            //https://teamtreehouse.com/community/when-should-i-use-int-and-intparse-whats-the-difference
//            onCallBack?.Invoke(int.Parse(snapshot.Value.ToString()));
//        }
//    }

//    public void GetUserInfo()
//    {

//        StartCoroutine(GetFirstName(PrintData));
//        StartCoroutine(GetLastName(PrintData));
//        StartCoroutine(GetCodeID(PrintData));
//    }

//    private void PrintData(string name)
//    {
//        Debug.Log(name);
//    }

//    private void PrintData(int code)
//    {
//        Debug.Log(code);
//    }
//}

//[Serializable]
//public struct User
//{
//    public string firstName;
//    public string lastName;
//    public int codeID;
//    public User(string firstName, string lastName, int codeID)
//    {
//        this.firstName = firstName;
//        this.lastName = lastName;
//        this.codeID = codeID;
//    }
//}

