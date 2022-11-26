using UnityEngine;

public class PlantGuidePlant : Taggable
{
    public PlantInfo info;
    public bool selected = false;

    public override void Start()
    {
        base.Start();
        Tags.Add(gameObject, "plant_guide_displays");
        if (selected)
        {
            gameObject.AddComponent<Spinnnnnnn>();
        }
    }

    public void Update()
    {
        bool overlap = GetComponent<Collider2D>()
            .OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        bool mousePressed = Input.GetMouseButtonDown(0);
        if (!selected && overlap && mousePressed)
        {
            selected = true;
            foreach (GameObject plant in Tags.GetAll("plant"))
            {
                Destroy(plant);
            }
            GameObject newPlant = Instantiate(info.plant);
            newPlant.transform.position = Tags.GetAll("plant_spot")[0].transform.position;
            Plant plantScript = newPlant.GetComponent<Plant>();
            for (int i = 0; i < 1000; i++)
            {
                plantScript.Grow();
            }
            if (!Tags.HasTag(newPlant, "plant"))
            {
                Tags.Add(newPlant, "plant");
            }
            foreach (GameObject plant in Tags.GetAll("plant_guide_displays"))
            {
                if (plant != this)
                {
                    plant.GetComponent<PlantGuidePlant>().Deselect();
                }
            }
            gameObject.AddComponent<Spinnnnnnn>();

            foreach (GameObject bug in Tags.GetAll("bug"))
            {
                Destroy(bug);
            }

            foreach (GameObject bugSpot in Tags.GetAll("bug_spawn"))
            {
                bugSpot.GetComponent<SpawnSpot>().Spawn();
            }
            
            foreach (GameObject lifeLilySpot in Tags.GetAll("life_lily_spawn"))
            {
                lifeLilySpot.GetComponent<SpawnSpot>().Spawn();
            }
            
            GuideText.instance.SetText(info.displayName + ": $" + info.cost + "\n" + info.guideDescription);
        }
    }

    private void Deselect()
    {
        selected = false;
        Destroy(GetComponent<Spinnnnnnn>());
    }
}
