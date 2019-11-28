using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISetup : MonoBehaviour
{
    public static UISetup Instance;
    private HealthSystem healthSystem;

    public RectTransform visualHealthTransform;
    public RectTransform visualTimeBar;
    //public RectTransform visualGunBar;

    public GameObject GameOver;

    public Image visualGunGun;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;

        healthSystem.onHealthChanged += HealthSystem_onHealthChanged;
    }

    private void HealthSystem_onHealthChanged(object sender, System.EventArgs e)
    {
        visualHealthTransform.localScale = new Vector3(healthSystem.GetHealthPercent(),1f,1f);
    }

    public void UpdateVirtualTime(float _t, float _tM)
    {
        visualTimeBar.localScale = new Vector3(_t/_tM,1f,1f);
    }

    /*public void UpdateVisualGunBar(float val)
    {
        visualGunBar.localScale = new Vector3(1f,val,1f);
    }*/

    public void SetupGunBarSprite(Sprite sprite)
    {
        visualGunGun.sprite = sprite;
    }

    public void GameOverReady()
    {
        GameOver.SetActive(true);
    }

    public void RestartBtn()
    {
        Debug.Log("Restart Game!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quitting Successful!");
        Application.Quit();
    }
}
