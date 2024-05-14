using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApplication
{
    // Delegate for notifying when a recipe exceeds 300 calories
    public delegate void RecipeCaloriesExceededEventHandler(Recipe recipe, double totalCalories);

    // Class to manage recipes
    public class RecipeManager
    {
        public List<Recipe> recipes = new List<Recipe>(); // List to store recipes

        // Event for notifying when a recipe exceeds 300 calories
        public event RecipeCaloriesExceededEventHandler RecipeCaloriesExceeded;

        // Method to add a new recipe
        public void AddRecipe()
        {
            Console.WriteLine("\nEnter details for the new recipe:");

            Console.Write("Name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = new Recipe(name);

            recipe.EnterIngredients();
            recipe.EnterSteps();

            recipes.Add(recipe);
            Console.WriteLine("\nRecipe added successfully!");
        }

        // Method to display all recipes in alphabetical order
        public void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("\nNo recipes available.");
                return;
            }

            Console.WriteLine("\nAll Recipes:");
            var sortedRecipes = recipes.OrderBy(r => r.Name);
            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }

            Console.WriteLine("\nEnter the name of the recipe you want to display:");
            string selectedRecipeName = Console.ReadLine();
            var selectedRecipe = recipes.FirstOrDefault(r => r.Name == selectedRecipeName);
            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to calculate total calories of a recipe
        public double CalculateTotalCalories(Recipe recipe)
        {
            double totalCalories = recipe.Ingredients.Sum(ingredient => ingredient.Calories);
            return totalCalories;
        }

        // Method to check if a recipe exceeds 300 calories
        public void CheckRecipeCalories(Recipe recipe)
        {
            double totalCalories = CalculateTotalCalories(recipe);
            if (totalCalories > 300)
            {
                RecipeCaloriesExceeded?.Invoke(recipe, totalCalories);
            }
        }
    }

}