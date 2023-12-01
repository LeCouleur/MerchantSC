using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class City : MonoBehaviour
{
    public Transform spawnLoc;
    public string cityName;
    public int Population;
    public float IronStock;
    public float GoldStock;
    public float CopperStock;
    public float FishStock;
    public float MeatStock;
    public float GunPowderStock;
    public float WoodStock;
    public float LumberStock;
    public float SpiceStock;
    public float FruitStock;
    public float ClothStock;
    public float CannonStock;
    public float SwordStock;
    public float GrainStock;
    public bool wagonBuyable;
    public bool shipBuyable;
    public bool hasAPort;
    public Transform wagonSpawnLoc;
    public bool wagonAccessible;

    public float GrainPrice = 0.5f;
    public float FishPrice = 2f;
    public float MeatPrice = 5f;
    public float FruitPrice = 7f;
    public float IronPrice = 8f;
    public float GunPowderPrice = 12f;
    public float CopperPrice = 15f;
    public float WoodPrice = 12f;
    public float LumberPrice = 17f;
    public float SwordPrice = 25f;
    public float CannonPrice = 50f;
    public float SpicePrice = 60f;
    public float ClothPrice = 45f;

    public float PIronStock;
    public float PGoldStock;
    public float PCopperStock;
    public float PFishStock;
    public float PMeatStock;
    public float PGunPowderStock;
    public float PWoodStock;
    public float PLumberStock;
    public float PSpiceStock;
    public float PFruitStock;
    public float PClothStock;
    public float PCannonStock;
    public float PSwordStock;
    public float PGrainStock;


    public float IronDemandSatisfied;
    public float GunPowderDemandSatisfied;
    public float CopperDemandSatisfied;
    public float WoodDemandSatisfied;
    public float LumberDemandSatisfied;

    public float grainfarmerPerc;
    public float blacksmithPerc;
    public float fishermanPerc;
    public float foresterPerc;
    public float lumberjackPerc;
    public float livestockFarmerPerc;
    public float fruitfarmerPerc;
    public float soldierPerc;
    public float tailorPerc;

    public float lowIncomePop;
    public float highIncomePop;
    public float lowPopulationIncrease;
    public float highPopulationIncrease;

    public int lowIncomePopulation;
    public int highIncomePopulation;

    private const float MaxMeatPrice = 50f;
    private const float MinMeatPrice = 0.1f;
    private const float MaxGrainPrice = 15f;
    private const float MinGrainPrice = 0.1f;
    private const float MaxFishPrice = 25f;
    private const float MinFishPrice = 0.1f;
    private const float MaxFruitPrice = 5f;
    private const float MinFruitPrice = 0.1f;
    private const float MaxIronPrice = 140f;
    private const float MinIronPrice = 0.1f;
    private const float MaxGunPowderPrice = 35f;
    private const float MinGunPowderPrice = 0.1f;
    private const float MaxCopperPrice = 6f;
    private const float MinCopperPrice = 0.1f;
    private const float MaxWoodPrice = 20f;
    private const float MinWoodPrice = 0.1f;
    private const float MaxLumberPrice = 2f;
    private const float MinLumberPrice = 0.1f;
    private const float MaxSwordPrice = 140f;
    private const float MinSwordPrice = 0.1f;
    private const float MaxCannonPrice = 200f;
    private const float MinCannonPrice = 0.1f;
    private const float MaxSpicePrice = 400f;
    private const float MinSpicePrice = 0.1f;
    private const float MaxClothPrice = 100f;
    private const float MinClothPrice = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
    GrainPrice = 0.5f;
    FishPrice = 2f;
    MeatPrice = 5f;
    FruitPrice = 7f;
    IronPrice = 8f;
    GunPowderPrice = 12f;
    CopperPrice = 15f;
    WoodPrice = 12f;
    LumberPrice = 17f;
    SwordPrice = 25f;
    CannonPrice = 50f;
    SpicePrice = 60f;
    ClothPrice = 45f;
        lowIncomePopulation = Mathf.RoundToInt(Population * lowIncomePop / 100f);
        highIncomePopulation = Mathf.RoundToInt(Population * highIncomePop / 100f);
}

    public void newDay()
    {

        if(cityName == "Lisbon")
        {
            SpiceStock += 100;
        }

        if(cityName == "Vienna")
        {
            IronStock += 100;
        }
        if(cityName == "London")
        {
            CopperStock += 100;
        }
        if(cityName == "Warsaw")
        {
            CopperStock += 100;
        }
        float farmers = Population * grainfarmerPerc / 100f;
        GrainStock += farmers * 0.007f;
        Debug.Log(farmers + GrainStock);
        SellGrain(GrainStock);
        float fisherman = Population * fishermanPerc / 100f;
        FishStock += fisherman * 0.007f;
        SellFish(FishStock);
        float livestock = Population * livestockFarmerPerc / 100f;
        MeatStock += livestock * 0.007f;
        SellMeat(MeatStock);
        float fruit = Population * fruitfarmerPerc / 100f;
        FruitStock += fruit * 0.007f;
        SellFruit(FruitStock);

        SellIron(IronStock);
        SellGunPowder(GunPowderStock);
        SellCopper(CopperStock);

        float wood = Population * foresterPerc / 100f;
        WoodStock += wood / 100;
        SellWood(WoodStock);
        float woodDemandEffect = WoodDemandSatisfied / 100f;
        
        float lumber = Population * (lumberjackPerc / 100f) * 0.5f * (woodDemandEffect);
        SellLumber(LumberStock);


        float IronDemandEffect = IronDemandSatisfied / 100f;
        float LumberDemandEffect = LumberDemandSatisfied / 100f;

        float sword = Population * (blacksmithPerc / 100f) * 0.5f * (IronDemandEffect + LumberDemandEffect);
        SwordStock += sword / 500;

        SellSword(SwordStock);


        float copperDemandEffect = CopperDemandSatisfied / 100f;
        float gunPowderDemandEffect = GunPowderDemandSatisfied / 100f;

        float cannon = Population * (blacksmithPerc / 100f) * 0.5f * (copperDemandEffect + gunPowderDemandEffect);


        CannonStock += cannon / 1000f;
        Debug.Log("Canon" + cannon);
        SellCannon(CannonStock);
        SellSpice(SpiceStock);


        float cloth = Population * tailorPerc / 100f;
        ClothStock = cloth * tailorPerc / 100f;
        SellCloth(ClothStock);  


        JobChanges();

        // Calculate the new low and high income populations
        lowIncomePopulation += Mathf.RoundToInt(lowPopulationIncrease * lowIncomePopulation);
        highIncomePopulation += Mathf.RoundToInt(highPopulationIncrease * highIncomePopulation);

        // Ensure that populations don't exceed the total population
        lowIncomePopulation = Mathf.Clamp(lowIncomePopulation, 0, Population);
        highIncomePopulation = Mathf.Clamp(highIncomePopulation, 0, Population);

        Population = lowIncomePopulation + highIncomePopulation;
        // Update the low and high income percentages
        lowIncomePop = (float)lowIncomePopulation / Population * 100f;
        highIncomePop = (float)highIncomePopulation / Population * 100f;

        // Update the total population
        Population = lowIncomePopulation + highIncomePopulation;

        lowPopulationIncrease = 0;
        highPopulationIncrease = 0;



    }

    private void JobChanges()
    {
        List<(System.Action<float>, float)> jobAndPriceList = new List<(System.Action<float>, float)>
    {
        ((value) => grainfarmerPerc += value, GrainPrice),
        ((value) => blacksmithPerc += value, (SwordPrice + CannonPrice)), // Considering Sword and Cannon as part of Blacksmith's job
        ((value) => fishermanPerc += value, FishPrice),
        ((value) => foresterPerc += value, WoodPrice),
        ((value) => lumberjackPerc += value, LumberPrice),
        ((value) => livestockFarmerPerc += value, MeatPrice),
        ((value) => fruitfarmerPerc += value, FruitPrice),
        ((value) => tailorPerc += value, ClothPrice)
    };

        List<(System.Action<float>, float)> sortedList = jobAndPriceList.OrderByDescending(tuple => tuple.Item2).ToList();

        // Find the bottom 4 earners
        var bottom4Earners = sortedList.Skip(4).ToList();

        // Access the top 4 earners
        for (int i = 0; i < 4; i++)
        {
            var (topJobAction, price) = sortedList[i];

            // Iterate over the bottom 4 earners
            for (int j = 0; j < bottom4Earners.Count; j++)
            {
                var (bottomJobAction, _) = bottom4Earners[j];

                // Calculate the proportional allocation based on the bottom earner's percentage
                float proportionalAllocation = 0.1f;

                // Adjust the percentages dynamically using the actions
                topJobAction(proportionalAllocation);
                bottomJobAction(-proportionalAllocation);

                // Update the bottom earners list
                bottom4Earners[j] = (bottomJobAction, 0f);
            }
        }


        float comp = grainfarmerPerc + blacksmithPerc + fishermanPerc + foresterPerc + lumberjackPerc
                + livestockFarmerPerc + fruitfarmerPerc + soldierPerc + tailorPerc;

        float remainingPercentage = Mathf.Max(0f, 100f - comp);

        // If there is remaining percentage, distribute it equally among the percs
        if (remainingPercentage > 0)
        {
            float equalDistribution = remainingPercentage / 9; // 9 percs in total

            grainfarmerPerc += equalDistribution;
            blacksmithPerc += equalDistribution;
            fishermanPerc += equalDistribution;
            foresterPerc += equalDistribution;
            lumberjackPerc += equalDistribution;
            livestockFarmerPerc += equalDistribution;
            fruitfarmerPerc += equalDistribution;
            soldierPerc += equalDistribution;
            tailorPerc += equalDistribution;
        }

        // Debug information
        foreach (var (jobAction, price) in jobAndPriceList)
        {
            Debug.Log($"After Reallocation - Job Percentage: {jobAction.Method.Name}, Price: {price}");

            if(cityName == "Venice")
            {
                float comxp = grainfarmerPerc + fishermanPerc + tailorPerc + blacksmithPerc + foresterPerc + fruitfarmerPerc + livestockFarmerPerc + lumberjackPerc + soldierPerc;

                Debug.Log("Venice" + comxp);
            }
        }
    }

    void SellGrain(float Item)
    {
        float cal = Population * lowIncomePop / 100f;
        float demand = cal / 1000f;

        Debug.Log(demand + cityName);
        if (demand <= 0) { 
            return;
        }

        if (Item >= demand)
        {
            Item -= PGrainStock;

            float percentageFromPlayer = Mathf.Min(PGrainStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;
            if(cityName == "Venice")
            {
                Debug.Log(percentageFromStock + " " + percentageFromPlayer + " " + Item);
            }

            float playerSold = demand * percentageFromPlayer;
            PGrainStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PGrainStock;

            Debug.Log("Item: " + Item + ", PGrainStock: " + PGrainStock + ", GrainStock: " + GrainStock);

            GrainStock = Item;

            // Adjust GrainPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            GrainPrice = Mathf.Min(MaxGrainPrice, GrainPrice - priceAdjustment);

            PGoldStock += playerSold * GrainPrice;

            lowPopulationIncrease += 0.01f;
        }
        else
        {

            float priceAdjustment = (demand - Item) / 1000f;
            GrainPrice = Mathf.Max(MinGrainPrice, GrainPrice + priceAdjustment);


            Item -= PGrainStock;
            GrainStock = 0;
            PGoldStock += PGrainStock * GrainPrice;
            PGrainStock = 0;
            lowPopulationIncrease -= 0.01f;
        }
    }

    void SellFish(float Item)
    {
        float cal = Population * lowIncomePop / 100f;
        float demand = cal / 1000f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PFishStock;

            float percentageFromPlayer = Mathf.Min(PFishStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PFishStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PFishStock;

            FishStock = Item;

            // Adjust FishPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            FishPrice = Mathf.Min(MaxFishPrice, FishPrice - priceAdjustment);

            PGoldStock += playerSold * FishPrice;

            lowPopulationIncrease += 0.01f;
        }
        else
        {

            float priceAdjustment = (demand - Item) / 1000f;
            FishPrice = Mathf.Max(MinFishPrice, FishPrice + priceAdjustment);

            Item -= PFishStock;
            FishStock = 0;
            PGoldStock += PFishStock * FishPrice;
            PFishStock = 0;
            lowPopulationIncrease -= 0.01f;
        }
    }


    void SellMeat(float Item)
    {
        float cal = Population * highIncomePop / 100f;
        float demand = cal / 1000f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PMeatStock;

            float percentageFromPlayer = Mathf.Min(PMeatStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PMeatStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PMeatStock;

            MeatStock = Item;

            // Adjust MeatPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            MeatPrice = Mathf.Min(MaxMeatPrice, MeatPrice - priceAdjustment);

            PGoldStock += playerSold * MeatPrice;

            highPopulationIncrease += 0.01f;
        }
        else
        {

            float priceAdjustment = (demand - Item) / 1000f;
            MeatPrice = Mathf.Max(MinMeatPrice, MeatPrice + priceAdjustment);

            Item -= PMeatStock;
            MeatStock = 0;
            PGoldStock += PMeatStock * MeatPrice;
            PMeatStock = 0;

            // Remaining demand after selling Meat
            float remainingDemand = demand - Item;
            if (Item >= remainingDemand)
            {
                Item -= PGrainStock;

                float percentageFromPlayer = Mathf.Min(PGrainStock / Item, 1f);
                float percentageFromStock = 1 - percentageFromPlayer;
                if (cityName == "Venice")
                {
                    Debug.Log(percentageFromStock + " " + percentageFromPlayer + " " + Item);
                }

                float playerSold = remainingDemand * percentageFromPlayer;
                PGrainStock -= playerSold;

                float stockSold = remainingDemand * percentageFromStock;
                Item -= stockSold;
                Item += PGrainStock;

                Debug.Log("Item: " + Item + ", PGrainStock: " + PGrainStock + ", GrainStock: " + GrainStock);

                GrainStock = Item;

                // Adjust GrainPrice when Item is greater than or equal to demand
                float apriceAdjustment = (Item - remainingDemand) / 1000f;
                GrainPrice = Mathf.Min(MaxGrainPrice, GrainPrice - apriceAdjustment);

                PGoldStock += playerSold * GrainPrice;

                highPopulationIncrease -= 0.01f;
            }
            else
            {

                float bpriceAdjustment = (remainingDemand - Item) / 1000f;
                GrainPrice = Mathf.Max(MinGrainPrice, GrainPrice + bpriceAdjustment);


                Item -= PGrainStock;
                GrainStock = 0;
                PGoldStock += PGrainStock * GrainPrice;
                PGrainStock = 0;
                highPopulationIncrease -= 0.01f;
            }
            // Check if there is still demand and FishStock is available
            if (remainingDemand >= 0 && FishStock > 0)
            {
                if (Item >= remainingDemand)
                {
                    Item -= PFishStock;

                    float percentageFromPlayer = Mathf.Min(PFishStock / Item, 1f);
                    float percentageFromStock = 1 - percentageFromPlayer;

                    float playerSold = remainingDemand * percentageFromPlayer;
                    PFishStock -= playerSold;

                    float stockSold = remainingDemand * percentageFromStock;
                    Item -= stockSold;
                    Item += PFishStock;

                    FishStock = Item;

                    // Adjust FishPrice when Item is greater than or equal to demand
                    float cpriceAdjustment = (Item - remainingDemand) / 1000f;
                    FishPrice = Mathf.Min(MaxFishPrice, FishPrice - cpriceAdjustment);

                    PGoldStock += playerSold * FishPrice;

                    lowPopulationIncrease += 0.01f;
                }
                else
                {

                    float dpriceAdjustment = (remainingDemand - Item) / 1000f;
                    FishPrice = Mathf.Max(MinFishPrice, FishPrice + dpriceAdjustment);

                    Item -= PFishStock;
                    FishStock = 0;
                    PGoldStock += PFishStock * FishPrice;
                    PFishStock = 0;
                    lowPopulationIncrease -= 0.01f;
                }
            }
        }
    }


    void SellFruit(float Item)
    {
        float cal = Population * highIncomePop / 100f;
        float demand = cal / 100f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PFruitStock;

            float percentageFromPlayer = Mathf.Min(PFruitStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PFruitStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PFruitStock;

            FruitStock = Item;

            // Adjust FruitPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            FruitPrice = Mathf.Min(MaxFruitPrice, FruitPrice - priceAdjustment);

            PGoldStock += playerSold * FruitPrice;

            highPopulationIncrease += 0.01f;
        }
        else
        {

            float priceAdjustment = (demand - Item) / 1000f;
            FruitPrice = Mathf.Max(MinFruitPrice, FruitPrice + priceAdjustment);

            Item -= PFruitStock;
            FruitStock = 0;
            PGoldStock += PFruitStock * FruitPrice;
            PFruitStock = 0;

            // Remaining demand after selling Fruit
            float remainingDemand = demand - Item;
            if (GrainStock > 0)
            {
                if (Item >= remainingDemand)
                {
                    Item -= PGrainStock;

                    float percentageFromPlayer = Mathf.Min(PGrainStock / Item, 1f);
                    float percentageFromStock = 1 - percentageFromPlayer;
                    if (cityName == "Venice")
                    {
                        Debug.Log(percentageFromStock + " " + percentageFromPlayer + " " + Item);
                    }

                    float playerSold = remainingDemand * percentageFromPlayer;
                    PGrainStock -= playerSold;

                    float stockSold = remainingDemand * percentageFromStock;
                    Item -= stockSold;
                    Item += PGrainStock;

                    Debug.Log("Item: " + Item + ", PGrainStock: " + PGrainStock + ", GrainStock: " + GrainStock);

                    GrainStock = Item;

                    // Adjust GrainPrice when Item is greater than or equal to demand
                    float epriceAdjustment = (Item - remainingDemand) / 1000f;
                    GrainPrice = Mathf.Min(MaxGrainPrice, GrainPrice - epriceAdjustment);

                    PGoldStock += playerSold * GrainPrice;

                    highPopulationIncrease -= 0.01f;
                }
                else
                {

                    float fpriceAdjustment = (remainingDemand - Item) / 1000f;
                    GrainPrice = Mathf.Max(MinGrainPrice, GrainPrice + fpriceAdjustment);


                    Item -= PGrainStock;
                    GrainStock = 0;
                    PGoldStock += PGrainStock * GrainPrice;
                    PGrainStock = 0;
                    highPopulationIncrease -= 0.01f;
                }
                // Check if there is still demand and FishStock is available
                if (remainingDemand >= 0 && FishStock > 0)
                {
                    if (Item >= remainingDemand)
                    {
                        Item -= PFishStock;

                        float percentageFromPlayer = Mathf.Min(PFishStock / Item, 1f);
                        float percentageFromStock = 1 - percentageFromPlayer;

                        float playerSold = remainingDemand * percentageFromPlayer;
                        PFishStock -= playerSold;

                        float stockSold = remainingDemand * percentageFromStock;
                        Item -= stockSold;
                        Item += PFishStock;

                        FishStock = Item;

                        // Adjust FishPrice when Item is greater than or equal to demand
                        float gpriceAdjustment = (Item - remainingDemand) / 1000f;
                        FishPrice = Mathf.Min(MaxFishPrice, FishPrice - gpriceAdjustment);

                        PGoldStock += playerSold * FishPrice;

                        lowPopulationIncrease += 0.01f;
                    }
                    else
                    {

                        float hpriceAdjustment = (remainingDemand - Item) / 1000f;
                        FishPrice = Mathf.Max(MinFishPrice, FishPrice + hpriceAdjustment);

                        Item -= PFishStock;
                        FishStock = 0;
                        PGoldStock += PFishStock * FishPrice;
                        PFishStock = 0;
                        lowPopulationIncrease -= 0.01f;
                    }
                }
            }
        }
    }

    void SellIron(float Item)
    {
        // Assuming Iron demand is based on the blacksmithPerc
        float cal = Population * blacksmithPerc / 100f;
        float demand = cal / 1000;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PIronStock;

            float percentageFromPlayer = Mathf.Min(PIronStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PIronStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PIronStock;

            IronStock = Item;

            // Adjust IronPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            IronPrice = Mathf.Min(MaxIronPrice, IronPrice - priceAdjustment);

            PGoldStock += playerSold * IronPrice;

            // Set IronDemandSatisfied to 100 since the full demand is satisfied
            IronDemandSatisfied = 100f;
        }
        else
        {
            float priceAdjustment = (demand - Item) / 1000f;
            IronPrice = Mathf.Max(MinIronPrice, IronPrice + priceAdjustment);

            Item -= PIronStock;
            IronStock = 0;
            PGoldStock += PIronStock * IronPrice;
            

            // Calculate the percentage of satisfied Iron demand for the remaining stock
            float satisfiedPercentageStock = (Item + PIronStock) / demand;
            PIronStock = 0;

            // Set IronDemandSatisfied based on the overall market satisfaction
            IronDemandSatisfied = satisfiedPercentageStock * 100f;

            // Remaining demand after selling Iron
            float remainingDemand = demand - Item;

            // Handle remaining demand (you can customize this part based on your game logic)
            // For example, you may want to decrease IronDemandSatisfied or take other actions.
        }
    }

    void SellGunPowder(float Item)
    {
        float cal = Population * blacksmithPerc / 100f;
        float demand = cal / 1000f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PGunPowderStock;

            float percentageFromPlayer = Mathf.Min(PGunPowderStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PGunPowderStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PGunPowderStock;

            GunPowderStock = Item;

            // Adjust GunPowderPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            GunPowderPrice = Mathf.Min(MaxGunPowderPrice, GunPowderPrice - priceAdjustment);

            PGoldStock += playerSold * GunPowderPrice;

            // Set GunPowderDemandSatisfied to 100 since the full demand is satisfied
            GunPowderDemandSatisfied = 100f;
        }
        else
        {
            float priceAdjustment = (demand - Item) / 1000f;
            GunPowderPrice = Mathf.Max(MinGunPowderPrice, GunPowderPrice + priceAdjustment);

            Item -= PGunPowderStock;
            GunPowderStock = 0;
            PGoldStock += PGunPowderStock * GunPowderPrice;

            // Calculate the percentage of satisfied GunPowder demand for the remaining stock
            float satisfiedPercentageStock = (Item + PGunPowderStock) / demand;
            PGunPowderStock = 0;

            // Set GunPowderDemandSatisfied based on the overall market satisfaction
            GunPowderDemandSatisfied = satisfiedPercentageStock * 100f;

            // Remaining demand after selling GunPowder
            float remainingDemand = demand - Item;

            // Handle remaining demand (customize based on your game logic)
            // For example, you may want to decrease GunPowderDemandSatisfied or take other actions.
        }
    }
    void SellCopper(float Item)
    {
        float cal = Population * blacksmithPerc / 100f;
        float demand = cal / 1000f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PCopperStock;

            float percentageFromPlayer = Mathf.Min(PCopperStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PCopperStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PCopperStock;

            CopperStock = Item;

            // Adjust CopperPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            CopperPrice = Mathf.Min(MaxCopperPrice, CopperPrice - priceAdjustment);

            PGoldStock += playerSold * CopperPrice;

            // Set CopperDemandSatisfied to 100 since the full demand is satisfied
            CopperDemandSatisfied = 100f;
        }
        else
        {
            float priceAdjustment = (demand - Item) / 1000f;
            CopperPrice = Mathf.Max(MinCopperPrice, CopperPrice + priceAdjustment);

            Item -= PCopperStock;
            CopperStock = 0;
            PGoldStock += PCopperStock * CopperPrice;

            // Calculate the percentage of satisfied Copper demand for the remaining stock
            float satisfiedPercentageStock = (Item + PCopperStock) / demand;
            PCopperStock = 0;

            // Set CopperDemandSatisfied based on the overall market satisfaction
            CopperDemandSatisfied = satisfiedPercentageStock * 100f;

            // Remaining demand after selling Copper
            float remainingDemand = demand - Item;

            // Handle remaining demand (customize based on your game logic)
            // For example, you may want to decrease CopperDemandSatisfied or take other actions.
        }
    }

    void SellWood(float Item)
    {
        // Assuming Wood demand is based on the lumberjackPerc
        float cal = Population * lumberjackPerc / 100f;
        float demand = cal / 1000f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PWoodStock;

            float percentageFromPlayer = Mathf.Min(PWoodStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PWoodStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PWoodStock;

            WoodStock = Item;

            // Adjust WoodPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            WoodPrice = Mathf.Min(MaxWoodPrice, WoodPrice - priceAdjustment);

            PGoldStock += playerSold * WoodPrice;

            // Set WoodDemandSatisfied to 100 since the full demand is satisfied
            WoodDemandSatisfied = 100f;
        }
        else
        {
            float priceAdjustment = (demand - Item) / 1000f;
            WoodPrice = Mathf.Max(MinWoodPrice, WoodPrice + priceAdjustment);

            Item -= PWoodStock;
            WoodStock = 0;
            PGoldStock += PWoodStock * WoodPrice;

            // Calculate the percentage of satisfied Wood demand for the remaining stock
            float satisfiedPercentageStock = (Item + PWoodStock) / demand;
            PWoodStock = 0;

            // Set WoodDemandSatisfied based on the overall market satisfaction
            WoodDemandSatisfied = satisfiedPercentageStock * 100f;

            // Remaining demand after selling Wood
            float remainingDemand = demand - Item;

            // Handle remaining demand (customize based on your game logic)
            // For example, you may want to decrease WoodDemandSatisfied or take other actions.
        }
    }
    void SellLumber(float Item)
    {
        // Assuming Lumber demand is based on the blacksmithPerc
        float cal = Population * blacksmithPerc / 100f;
        float demand = cal / 1000f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            Item -= PLumberStock;

            float percentageFromPlayer = Mathf.Min(PLumberStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PLumberStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PLumberStock;

            LumberStock = Item;

            // Adjust LumberPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            LumberPrice = Mathf.Min(MaxLumberPrice, LumberPrice - priceAdjustment);

            PGoldStock += playerSold * LumberPrice;

            // Set LumberDemandSatisfied to 100 since the full demand is satisfied
            LumberDemandSatisfied = 100f;
        }
        else
        {
            float priceAdjustment = (demand - Item) / 1000f;
            LumberPrice = Mathf.Max(MinLumberPrice, LumberPrice + priceAdjustment);

            Item -= PLumberStock;
            LumberStock = 0;
            PGoldStock += PLumberStock * LumberPrice;

            // Calculate the percentage of satisfied Lumber demand for the remaining stock
            float satisfiedPercentageStock = (Item + PLumberStock) / demand;
            PLumberStock = 0;

            // Set LumberDemandSatisfied based on the overall market satisfaction
            LumberDemandSatisfied = satisfiedPercentageStock * 100f;

            // Remaining demand after selling Lumber
            float remainingDemand = demand - Item;

            // Handle remaining demand (customize based on your game logic)
            // For example, you may want to decrease LumberDemandSatisfied or take other actions.
        }
    }

    void SellSword(float Item)

    {
        // Assuming sword demand is based on the soldierPerc
        float cal = Population * (soldierPerc / 2)  / 100f;
        float demand = cal / 1000f; 

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            // Adjust Item and related variables when the supply is greater than or equal to demand
            Item -= PSwordStock;

            float percentageFromPlayer = Mathf.Min(PSwordStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PSwordStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PSwordStock;

            SwordStock = Item;

            // Adjust SwordPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            SwordPrice = Mathf.Min(MaxSwordPrice, SwordPrice - priceAdjustment);

            PGoldStock += playerSold * SwordPrice;

            // Set SwordDemandSatisfied to 100 since the full demand is satisfied
        }
        else
        {
            // Adjust Item and related variables when the supply is less than demand
            float priceAdjustment = (demand - Item) / 1000f;
            SwordPrice = Mathf.Max(MinSwordPrice, SwordPrice + priceAdjustment);

            Item -= PSwordStock;
            SwordStock = 0;
            PGoldStock += PSwordStock * SwordPrice;

            // Calculate the percentage of satisfied Sword demand for the remaining stock
            float satisfiedPercentageStock = Item + PSwordStock / demand;
            PSwordStock = 0;

            // Remaining demand after selling Swords
            float remainingDemand = demand - Item;

            // Handle remaining demand (you can customize this part based on your game logic)
            // For example, you may want to decrease SwordDemandSatisfied or take other actions.
        }
    }

    void SellCannon(float Item)
    {
        // Assuming cannon demand is based on the soldierPerc
        float cal = Population * (soldierPerc / 2) / 100f;
        float demand = cal / 1000f;
        Debug.Log("Cannon demand" + demand);

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            // Adjust Item and related variables when the supply is greater than or equal to demand
            Item -= PCannonStock;

            float percentageFromPlayer = Mathf.Min(PCannonStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PCannonStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PCannonStock;

            CannonStock = Item;

            // Adjust CannonPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            CannonPrice = Mathf.Min(MaxCannonPrice, CannonPrice - priceAdjustment);

            PGoldStock += playerSold * CannonPrice;
        }
        else
        {
            // Adjust Item and related variables when the supply is less than demand
            float priceAdjustment = (demand - Item) / 1000f;
            CannonPrice = Mathf.Max(MinCannonPrice, CannonPrice + priceAdjustment);

            Item -= PCannonStock;
            CannonStock = 0;
            PGoldStock += PCannonStock * CannonPrice;
            PCannonStock = 0;

            // Remaining demand after selling Cannons
            float remainingDemand = demand - Item;

            // Handle remaining demand (you can customize this part based on your game logic)
            // For example, you may want to decrease population or take other actions.
        }
    }

    void SellSpice(float Item)
    {
        // Assuming spice demand is based on the highIncomePop
        float cal = Population * highIncomePop / 100f;
        float demand = cal / 1000f;

        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            // Adjust Item and related variables when the supply is greater than or equal to demand
            Item -= PSpiceStock;

            float percentageFromPlayer = Mathf.Min(PSpiceStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PSpiceStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PSpiceStock;

            SpiceStock = Item;

            // Adjust SpicePrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            SpicePrice = Mathf.Min(MaxSpicePrice, SpicePrice - priceAdjustment);

            PGoldStock += playerSold * SpicePrice;
        }
        else
        {
            // Adjust Item and related variables when the supply is less than demand
            float priceAdjustment = (demand - Item) / 1000f;
            SpicePrice = Mathf.Max(MinSpicePrice, SpicePrice + priceAdjustment);

            Item -= PSpiceStock;
            SpiceStock = 0;
            
            PGoldStock += PSpiceStock * SpicePrice;
            PSpiceStock = 0;
            // Remaining demand after selling Spice
            float remainingDemand = demand - Item;

            // Handle remaining demand (you can customize this part based on your game logic)
            // For example, you may want to decrease highIncomePop or take other actions.
        }
    }

    void SellCloth(float Item)
    {
        // Assuming cloth demand is based on the highIncomePop
        float cal = Population * highIncomePop / 100f;
        float demand = cal / 1000f;
        if (demand <= 0)
        {
            return;
        }

        if (Item >= demand)
        {
            // Adjust Item and related variables when the supply is greater than or equal to demand
            Item -= PClothStock;

            float percentageFromPlayer = Mathf.Min(PClothStock / Item, 1f);
            float percentageFromStock = 1 - percentageFromPlayer;

            float playerSold = demand * percentageFromPlayer;
            PClothStock -= playerSold;

            float stockSold = demand * percentageFromStock;
            Item -= stockSold;
            Item += PClothStock;

            ClothStock = Item;

            // Adjust ClothPrice when Item is greater than or equal to demand
            float priceAdjustment = (Item - demand) / 1000f;
            ClothPrice = Mathf.Min(MaxClothPrice, ClothPrice - priceAdjustment);

            PGoldStock += playerSold * ClothPrice;
        }
        else
        {
            // Adjust Item and related variables when the supply is less than demand
            float priceAdjustment = (demand - Item) / 1000f;
            ClothPrice = Mathf.Max(MinClothPrice, ClothPrice + priceAdjustment);

            Item -= PClothStock;
            ClothStock = 0;
            PGoldStock += PClothStock * ClothPrice;
            PClothStock = 0;

            // Remaining demand after selling Cloth
            float remainingDemand = demand - Item;

            // Handle remaining demand (you can customize this part based on your game logic)
            // For example, you may want to decrease highIncomePop or take other actions.
        }
    }



    void Update()
    {
        
           if (GrainPrice < MinGrainPrice)
            {
                GrainPrice = MinGrainPrice;
            }

            if (FishPrice < MinFishPrice)
            {
                FishPrice = MinFishPrice;
            }

            if (MeatPrice < MinMeatPrice)
            {
                MeatPrice = MinMeatPrice;
            }

            if (FruitPrice < MinFruitPrice)
            {
                FruitPrice = MinFruitPrice;
            }

            if (IronPrice < MinIronPrice)
            {
                IronPrice = MinIronPrice;
            }

            if (GunPowderPrice < MinGunPowderPrice)
            {
                GunPowderPrice = MinGunPowderPrice;
            }

            if (CopperPrice < MinCopperPrice)
            {
                CopperPrice = MinCopperPrice;
            }

            if (WoodPrice < MinWoodPrice)
            {
                WoodPrice = MinWoodPrice;
            }

            if (LumberPrice < MinLumberPrice)
            {
                LumberPrice = MinLumberPrice;
            }

            if (SwordPrice < MinSwordPrice)
            {
                SwordPrice = MinSwordPrice;
            }

            if (CannonPrice < MinCannonPrice)
            {
                CannonPrice = MinCannonPrice;
            }

            if (SpicePrice < MinSpicePrice)
            {
                SpicePrice = MinSpicePrice;
            }

            if (ClothPrice < MinClothPrice)
            {
                ClothPrice = MinClothPrice;
            } 
        }
    

    public void Unload(string Type, float Carriage, CharacterController CS)
    {
        switch (Type)
        {
            case "Iron":
                if (CS.Type == Type)
                {
                    PIronStock += Carriage;
                    IronStock += Carriage;
                }
                else
                {
                    Debug.Log("Wrong Type");
                }
                break;
            case "Gold":
                if (CS.Type == Type)
                {
                    PGoldStock += Carriage;
                    CS.Carriage = 0;
                }
                break;
            case "Copper":
                if (CS.Type == Type)
                {
                    PCopperStock += Carriage;
                    CopperStock += Carriage;
                }
                break;
            case "Fish":
                if (CS.Type == Type)
                {
                    PFishStock += Carriage;
                    FishStock += Carriage;
                }
                break;
            case "Meat":
                if (CS.Type == Type)
                {
                    PMeatStock += Carriage;
                    MeatStock += Carriage;
                }
                break;
            case "GunPowder":
                if (CS.Type == Type)
                {
                    PGunPowderStock += Carriage;
                    GunPowderStock += Carriage;
                }
                break;
            case "Wood":
                if (CS.Type == Type)
                {
                    PWoodStock += Carriage;
                    WoodStock += Carriage;
                }
                break;
            case "Lumber":
                if (CS.Type == Type)
                {
                    PLumberStock += Carriage;
                    LumberStock += Carriage;
                }
                break;
            case "Spice":
                Debug.LogError("ALooo222");
                if (CS.Type == Type)
                {
                    PSpiceStock += Carriage;
                    SpiceStock += Carriage;
                    CS.Carriage = 0;
                    Debug.LogError("ALooo");
                }
                break;
            case "Fruit":
                if (CS.Type == Type)
                {
                    PFruitStock += Carriage;
                    FruitStock += Carriage;
                }
                break;
            case "Cloth":
                if (CS.Type == Type)
                {
                    PClothStock += Carriage;
                    ClothStock += Carriage;
                }
                break;
            case "Cannon":
                if (CS.Type == Type)
                {
                    PCannonStock += Carriage;
                    CannonStock += Carriage;
                }
                break;
            case "Sword":
                if (CS.Type == Type)
                {
                    PSwordStock += Carriage;
                    SwordStock += Carriage;
                }
                break;
            case "Grain":
                if (CS.Type == Type)
                {
                    PGrainStock += Carriage;
                    GrainStock += Carriage;
                }   
                break;
            default:
                Debug.LogError("YOOOO wtf " + Type);
                break;
        }
    }

    public void Load(string Type, float maxCarriage, CharacterController CS)
    {
        switch (Type)
        {
            case "Iron":
                
                {
                    if(CS.Type == Type || CS.Carriage == 0)
                        LoadStock(ref PIronStock, ref IronStock, maxCarriage, CS, Type, IronPrice);
                    break;
                }
            case "Gold":
                if(CS.Type == Type || CS.Carriage == 0)
                    LoadPlayerStock(ref PGoldStock, maxCarriage, CS, Type);
                break;

            case "Copper":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PCopperStock, ref CopperStock, maxCarriage, CS, Type, CopperPrice);
                break;

            case "Fish":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PFishStock, ref FishStock, maxCarriage, CS, Type, FishPrice);
                break;

            case "Meat":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PMeatStock, ref MeatStock, maxCarriage, CS, Type, MeatPrice);
                break;

            case "GunPowder":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PGunPowderStock, ref GunPowderStock, maxCarriage, CS, Type, GunPowderPrice);
                break;

            case "Wood":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PWoodStock, ref WoodStock, maxCarriage, CS, Type, WoodPrice);
                break;

            case "Lumber":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PLumberStock, ref LumberStock, maxCarriage, CS, Type, LumberPrice);
                break;

            case "Spice":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PSpiceStock, ref SpiceStock, maxCarriage, CS, Type, SpicePrice);
                Debug.LogWarning("It is supposed to work");
                break;

            case "Fruit":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PFruitStock, ref FruitStock, maxCarriage, CS, Type, FruitPrice);
                break;

            case "Cloth":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PClothStock, ref ClothStock, maxCarriage, CS, Type, ClothPrice);
                break;

            case "Cannon":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PCannonStock, ref CannonStock, maxCarriage, CS, Type, CannonPrice);
                break;

            case "Sword":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PSwordStock, ref SwordStock, maxCarriage, CS, Type, SwordPrice);
                break;

            case "Grain":
                if (CS.Type == Type || CS.Carriage == 0)
                    LoadStock(ref PGrainStock, ref GrainStock, maxCarriage, CS, Type, GrainPrice);
                break;

            // Add cases for other types similarly

            default:
                // Handle unknown type if needed
                break;
        }
    }

    private void LoadStock(ref float playerStock, ref float stock, float maxCarriage, CharacterController CS, string Type, float Price)
    {
        maxCarriage -= CS.Carriage;
        if (playerStock > 0)
        {
            if (playerStock > maxCarriage)
            {
                CS.Carriage = maxCarriage;
                stock -= maxCarriage;
                CS.Type = Type;
                playerStock -= maxCarriage;
                Debug.LogWarning("Wtf");
            }
            else
            {
                CS.Carriage += playerStock;
                stock -= playerStock;
                playerStock = 0;

                float remainingStock = maxCarriage - CS.Carriage;
                float maxAffordableQuantity = Mathf.Floor(CS.Player.Gold / Price);
                float toPayAffordable = Price * maxAffordableQuantity;

                if (remainingStock >= maxAffordableQuantity)
                {
                    if (maxAffordableQuantity <= stock)
                    {
                        if (CS.Player.Gold >= toPayAffordable)
                        {
                            CS.Carriage += maxAffordableQuantity;
                            stock -= maxAffordableQuantity;
                            CS.Player.Gold -= toPayAffordable;
                            CS.Type = Type;
                            Debug.LogWarning("Not enough gold to buy maxCarriage. Bought max affordable quantity instead.");
                        }
                        else
                        {
                            float price = stock * Price;

                            // Handle the case where the player can afford the remaining stock but not all of it
                            if (CS.Player.Gold >= price)
                            {
                                CS.Carriage += stock;
                                playerStock -= stock;
                                stock = 0;
                                CS.Player.Gold -= price;
                                CS.Type = Type;
                                Debug.LogWarning("Not enough gold to buy maxCarriage. Bought remaining stock instead.");
                            }
                            else
                            {
                                // Handle the case where the player can't afford the remaining stock
                                Debug.LogWarning("Not enough gold to buy remaining stock.");
                            }
                        }
                    }
                }
                else
                {
                    float price = remainingStock * Price;

                    // Handle the case where the player can't afford any or all of the remaining stock
                    if (CS.Player.Gold >= price)
                    {
                        CS.Carriage += remainingStock;
                        stock -= remainingStock;
                        CS.Player.Gold -= price;
                        CS.Type = Type;
                        Debug.LogWarning("Not enough gold to buy maxCarriage. Bought remaining stock instead.");
                    }
                    else
                    {
                        // Handle the case where the player can't afford any of the remaining stock
                        Debug.LogWarning("Not enough gold to buy remaining stock.");
                    }
                }
            }
        }
        else
        {
            float remainingStock = maxCarriage;

            float toPay1 = Price * remainingStock;
            float maxAffordableQuantity1 = Mathf.Floor(CS.Player.Gold / Price);
            float toPayAffordable1 = Price * maxAffordableQuantity1;

            if (stock >= remainingStock)
            {
                if (CS.Player.Gold >= toPay1)
                {
                    CS.Carriage = maxCarriage;
                    stock -= maxCarriage;
                    CS.Type = Type;
                    CS.Player.Gold -= toPay1; // Deduct money from player's gold
                    Debug.LogWarning("first");
                }
                else if (CS.Player.Gold >= toPayAffordable1)
                {
                    CS.Carriage = maxAffordableQuantity1;
                    stock -= maxAffordableQuantity1;
                    CS.Type = Type;
                    CS.Player.Gold -= toPayAffordable1; // Deduct money from player's gold
                    Debug.LogWarning("second.");
                }
            }
            else
            {
                float toPay2 = Price * remainingStock;
                float maxAffordableQuantity2 = Mathf.Floor(CS.Player.Gold / Price);
                float toPayAffordable2 = Price * maxAffordableQuantity2;

                if (CS.Player.Gold > toPay2)
                {
                    CS.Carriage += remainingStock;
                    stock -= remainingStock;
                    CS.Type = Type;
                    CS.Player.Gold -= toPay2; // Deduct money from player's gold
                    Debug.LogWarning("third");
                }
                else if (CS.Player.Gold >= toPayAffordable2)
                {
                    CS.Carriage += maxAffordableQuantity2;
                    stock -= maxAffordableQuantity2;
                    CS.Type = Type;
                    CS.Player.Gold -= toPayAffordable2; // Deduct money from player's gold
                    Debug.LogWarning("fourth.");
                }

         
            }
        }
    }





        private void LoadPlayerStock(ref float playerStock, float maxCarriage, CharacterController CS, string Type)
    {
        if (playerStock >= maxCarriage)
        {
            CS.Carriage = maxCarriage;
            playerStock -= maxCarriage;
            CS.Type = Type;
        }
        else
        {
            CS.Carriage = playerStock;
            playerStock = 0;
            CS.Type = Type; 
        }
    }




}
