using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using System.IO;
public class BetaTestManager : MonoBehaviour
{
    // Game Objects
    public GameObject[] sounds;
    public GameObject[] visual1;
    public GameObject[] visual2;
    public InputActionReference trigger;
    public InputActionReference next;
    private Stack<GameObject> actives = new Stack<GameObject>();
    private Stack<GameObject> visualsActive = new Stack<GameObject>();
    public XRRayInteractor GuessRay;

    private bool test = false;
    private int cycle = 0;
    private int attempt = 0;
    public int attemptNumber = 3;
    public int iterLen = 5;
    private int n;
    private string testRes = "";
    
    // Start is called before the first frame update
    void Start()
    {
        n = iterLen;
        Debug.Log(Directory.GetCurrentDirectory() + "/test.txt");
    }
    
    // Update is called once per frame
    void Update() 
    {

    }

    void OnEnable()
    {
        trigger.action.Enable();
        trigger.action.performed += OnGuess;
        next.action.Enable();
        next.action.performed += OnNext;
    }

    void OnGuess(InputAction.CallbackContext context)
    {
        if (test)
        {
            testRes += "Attempt #" + attempt.ToString() + ": ";
            GetGuess();
            testRes += "\n";
            ++attempt;
            if (attempt == attemptNumber)
            {
                EndCurrent();
                return;
            }
        }
    }

    void OnNext(InputAction.CallbackContext context)
    {
        if (!test){
            StartNext();
        }
    }

    private RaycastHit hit;
    public GameObject origin;
    void GetGuess()
    { 
        GuessRay.TryGetCurrent3DRaycastHit(out hit);
        Debug.Log(hit.point.ToString());
        testRes += "From: " + origin.transform.position.ToString() + "\nTo: " + hit.point.ToString();
        testRes += "\n";
    }
    
    void EndCurrent()
    {
        test = false;
        while(actives.Count > 0) {
            Deactivate();
        }
        ++cycle;
        testRes += "End of test\n========================\n";
        if (cycle % n == 0) {
            while(visualsActive.Count > 0) {
                DeactivateVisual();
            }
        }
        if (cycle == n * 3) {
            string path = Directory.GetCurrentDirectory() + "/test.txt";
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine("Test");
            writer.WriteLine(testRes);
            writer.Close();
            StreamReader reader = new StreamReader(path);
            //Print the text from the file
            Debug.Log(reader.ReadToEnd());
            reader.Close();
        }
    }

    void StartNext()
    {
        testRes += "Test #" + cycle.ToString() + "\n------------------------\n";
        test = true;
        int iter = cycle % n;
        attempt = 0;
        Activate(sounds[cycle]);
        if (cycle % n == 0)
        {
            switch (cycle / n)
            {
                case 1:
                    for (int i = 0; i < visual1.Length; ++i)
                    {
                        ActivateVisual(visual1[i]);
                    }
                    break;
                case 2:
                    for (int i = 0; i < visual2.Length; ++i)
                    {
                        ActivateVisual(visual2[i]);
                    }
                    break;
            }
        }
    }

    void Activate(GameObject obj)
    {
        obj.SetActive(true);
        actives.Push(obj);
    }

    //Deactivate top of the actives stack
    void Deactivate()
    {
        GameObject obj = actives.Pop();
        obj.SetActive(false);
    }

    void ActivateVisual(GameObject obj)
    {
        obj.SetActive(true);
        visualsActive.Push(obj);
    }

    //Deactivate top of the actives stack
    void DeactivateVisual()
    {
        GameObject obj = visualsActive.Pop();
        obj.SetActive(false);
    }


}
