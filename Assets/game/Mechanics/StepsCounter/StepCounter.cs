using UnityEngine;

public class StepCounter : MonoBehaviour
{

    private int startSteps;
    private int startStepsInGame;
    private int startStepsInAch;
    private float timer;
    private float lastStepTime = 0f;
    private float minStepInterval = 0.4f; // минимальный интервал между шагами
    private float maxDeltaThreshold = 3.0f;   // слишком резкий скачок — игнорируем
    private float minSpeedKmh = 2.5f;  // минимальная скорость ходьбы
    private float maxSpeedKmh = 6f;
    private bool Starts;

    private static StepCounter _instance;
    public static StepCounter Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<StepCounter>();
                if (_instance == null)
                {
                    GameObject container = new GameObject("StepCounter");
                    _instance = container.AddComponent<StepCounter>();
                }
            }
            return _instance;
        }
    }

[Header("Configuration")]
    public StepCounterConfig config;
[Header("Runtime Variables")]
    [SerializeField] private float distanceWalked = 0f;
    [SerializeField] private int stepCount = 0;
    private Vector3 acceleration;
    private Vector3 prevAcceleration;
    private void Start()
    {
        if (config == null)
        {
            Debug.LogError("Oops! StepCounterConfig is missing!");
            return;
        }
        prevAcceleration = Input.acceleration;
        StepDataHandler.Instance.CheckForNewDay();

        startStepsInAch = PlayerPrefs.GetInt("StepsAch", 0);
    }
    private void Update()
    {
        if (config == null) return;
        DetectSteps();
        CalculateDistance();
        StepDataHandler.Instance.SaveDailySteps(stepCount);


        if(!Starts && PlayerPrefs.GetInt("Ach5Level", 0) == 2)
        {
            Starts = true;
            startSteps = stepCount;
        }

        timer += Time.deltaTime;

        if (timer >= 0.15f)
        {
            timer = 0f;

            int stepsAchNow;

            if(PlayerPrefs.GetInt("Ach5Level", 0) == 2)
            {
                stepsAchNow = stepCount - startSteps + startStepsInAch;

                if (stepsAchNow < startStepsInAch)
                    stepsAchNow = startStepsInAch;

                PlayerPrefs.SetInt("StepsAch", stepsAchNow);
            }

            if(PlayerPrefs.GetInt("StepsAch", 0) >= 1000)
            {
                if(PlayerPrefs.GetInt("Ach5Level", 0) == 2)
                PlayerPrefs.SetInt("Ach5Level", 3);
            }
        }
    }
    private void DetectSteps()
    {
        acceleration = Input.acceleration;

        float delta = (acceleration - prevAcceleration).magnitude;

        // Если скачок слишком большой (машина, автобус, резкая тряска)
        if (delta > maxDeltaThreshold)
        {
            prevAcceleration = acceleration;
            return;
        }

        // Нормальный шаг
        if (delta > config.threshold)
        {
            if (Time.time - lastStepTime > minStepInterval)
            {
                stepCount++;
                lastStepTime = Time.time;
                Debug.Log("Step detected! Count: " + stepCount);
            }
        }

        prevAcceleration = acceleration;
    }
    private void CalculateDistance()
    {
        distanceWalked = stepCount * config.stepLength;
    }
    public void CalibrateStepLength(float newStepLength)
    {
        if (newStepLength > 0)
        {
            config.stepLength = newStepLength;
            Debug.Log($"Step length calibrated to: {config.stepLength} meters");
        }
        else
        {
            Debug.LogWarning("Whoops! That's not a valid step length.");
        }
    }
    // Getter methods and data management
    public float GetDistanceWalked() => distanceWalked;
    public int GetStepCount() => stepCount;
    public void ResetStepData()
    {
        stepCount = 0;
        distanceWalked = 0f;
    }
    public void LoadStepData(int loadedStepCount)
    {
        stepCount = loadedStepCount;
        CalculateDistance();
    }
}