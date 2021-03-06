using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;
    
    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0)) {
    //         LoadNextLevel();
    //     }
    // }

    public void LoadNextLevel() {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    public void LoadLevelIndex(int levelToLoad) {
       StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(int levelIndex) {
        // play anim
        transition.SetTrigger("Start");
        
        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
