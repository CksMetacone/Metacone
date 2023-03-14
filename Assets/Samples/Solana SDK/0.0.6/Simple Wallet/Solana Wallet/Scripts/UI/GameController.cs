using UnityEngine;

// ReSharper disable once CheckNamespace
public class GameController : MonoBehaviour
{
    private const string RepoUrl = "https://github.com/CksMetacone";
    
    public void OpenSDKRepo()
    {
        Application.OpenURL(RepoUrl);
    }
    
}
