using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gamepaused = false;
    bool gameover = false;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvas1;
    [SerializeField] int numenem;
    
    [SerializeField] Text numenemigospant;
   
    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        canvas1.SetActive(false);

        

    }

    // Update is called once per frame
    void Update()
    {


        //mostrar los enemigos en pantalla de juego
        
        //contador enemigos pantalla
        if (numenem == 0)
        {
            Debug.Log("XD");
        }
        //codigo pantalla
        numenemigospantalla();
    

    }

    public void Reducirnumene()
    {
        numenem = numenem - 1;
        if (numenem < 1)
        {

            Ganar();

        }
    }

    void numenemigospantalla()
    {

        numenemigospant.text = numenem.ToString();

    }
    public void Startgame()
    {
        //cargar escena de juego
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {

        SceneManager.LoadScene(1);
    }
   

    

    void Ganar()
    {

        gameover = true;
        Time.timeScale = 0;
        player.gamepaused = true;
        Debug.Log("ganaste");
        Time.timeScale = gamepaused ? 0 : 1;
        canvas1.SetActive(gameover);

    }


}
