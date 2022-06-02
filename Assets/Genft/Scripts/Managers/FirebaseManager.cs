using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using UnityEngine.Events;

public class FirebaseManager : MonoBehaviour
{
    public UnityEvent<int> OnFirebaseLoaded= new UnityEvent<int>();
    public UnityEvent OnFirebaseFailed=new UnityEvent();
    // Start is called before the first frame update
    async void Start()
    {
        var dependencyStatus= await FirebaseApp.CheckDependenciesAsync();
        if(dependencyStatus==DependencyStatus.Available)
        {
            OnFirebaseLoaded.Invoke(1);
        }
        else
        {
            OnFirebaseFailed.Invoke();
        }
    }

}
