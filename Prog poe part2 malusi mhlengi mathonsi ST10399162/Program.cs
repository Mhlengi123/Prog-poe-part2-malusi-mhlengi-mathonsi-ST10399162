// Main program class
using MiNET.Crafting;
using RecipeApplication;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        RecipeManager recipeManager = new RecipeManager();

        // Subscribe to the RecipeCaloriesExceeded event
        recipeManager.RecipeCaloriesExceeded += RecipeCaloriesExceededHandler;

        bool exit = false;

        // Allow the user to add the first recipe
        recipeManager.AddRecipe();

        while (!exit)
        {
            Console.WriteLine("\nCommands:");
            Console.WriteLine("1. Add Recipe");
            Console.WriteLine("2. Display All Recipes");
            Console.WriteLine("3. Scale Recipe");
            Console.WriteLine("4. Reset Quantities");
            Console.WriteLine("5. Exit");

            Console.Write("\nEnter command number: ");
            int command = int.Parse(Console.ReadLine());

            switch (command)
            {
                case 1:
                    recipeManager.AddRecipe();
                    break;
                case 2:
                    recipeManager.DisplayAllRecipes();
                    break;
                case 3:
                    ScaleRecipe(recipeManager);
                    break;
                case 4:
                    ResetQuantities(recipeManager);
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("\nInvalid command!");
                    break;
            }
        }
    }

    // Event handler for RecipeCaloriesExceeded event
    static void RecipeCaloriesExceededHandler(Recipe recipe, double totalCalories)
    {
        Console.WriteLine($"\nWarning: The total calories of {recipe.Name} recipe exceed 300. Total Calories: {totalCalories}");
    }

    // Method to scale a recipe
    static void ScaleRecipe(RecipeManager recipeManager)
    {
        Console.WriteLine("\nEnter the name of the recipe you want to scale:");
        string selectedRecipeName = Console.ReadLine();
        var selectedRecipe = recipeManager.recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
        if (selectedRecipe != null)
        {
            Console.Write("\nEnter scaling factor: ");
            double factor = double.Parse(Console.ReadLine());
            selectedRecipe.ScaleRecipe(factor);
            Console.WriteLine("\nRecipe scaled successfully!");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }

    // Method to reset quantities of a recipe
    static void ResetQuantities(RecipeManager recipeManager)
    {
        Console.WriteLine("\nEnter the name of the recipe you want to reset quantities:");
        string selectedRecipeName = Console.ReadLine();
        var selectedRecipe = recipeManager.recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
        if (selectedRecipe != null)
        {
            selectedRecipe.ResetQuantities();
            Console.WriteLine("\nQuantities reset successfully!");
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }
}

