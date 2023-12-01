using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameSpeed = 1.0f;
    public string[] seasons = { "Spring", "Summer", "Autumn", "Winter" };
    public int daysPerSeason = 30;

    private float timeSinceLastDay = 0.0f;
    private int currentDay = 1;
    private int currentSeasonIndex = 0;
    public int currentYear = 1600;

    public List<City> Cities;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastDay += Time.deltaTime * gameSpeed;
        if (timeSinceLastDay >= 10.0f)
        {
            timeSinceLastDay = 0.0f;
            currentDay++;
            foreach (City city in Cities)
            {
                city.newDay();
            }
            // Check if it's time to advance the season
            if (currentDay > daysPerSeason)
            {
                currentDay = 1;
                currentSeasonIndex = (currentSeasonIndex + 1) % seasons.Length;
                if (currentSeasonIndex == 0)
                {
                    currentYear++;
                }
            }
        }
    }

    // Get the current season as a string
   public string GetCurrentSeason()
    {
        return seasons[currentSeasonIndex];
    }
}
