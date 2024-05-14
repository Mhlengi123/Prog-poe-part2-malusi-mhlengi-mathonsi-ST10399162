# Prog poe part2 malusi mhlengi mathonsi ST10399162
This Recipe Application allows users to create and manage recipes. Users can add new recipes with ingredients and steps, display all recipes, scale a recipe by a factor, and reset ingredient quantities.

How the Code Works:

RecipeManager Class
  - Manages the list of recipes.
  - Provides methods to add a new recipe, display all recipes, calculate total calories of a recipe, and check if a recipe exceeds 300 calories.
  - Subscribes to the `RecipeCaloriesExceeded` event and raises the event when a recipe exceeds 300 calories.

Recipe Class
  - Represents a recipe with a name, list of ingredients, and list of steps.
  - Allows users to enter ingredients and steps for the recipe.
  - Provides methods to display the recipe, scale the recipe by a factor, reset ingredient quantities, and validate food groups.

Ingredient Class
  - Represents an ingredient with properties like name, quantity, unit, calories, and food group.

Step Class
  - Represents a step in a recipe with a description.

Program Class
  - Main class to run the application.
  - Allows users to interact with the application by adding a recipe, displaying recipes, scaling a recipe, and resetting quantities.

Event Handling
  - The `RecipeCaloriesExceededHandler` method is called when a recipe exceeds 300 calories.

How to Use the Application:

1. Run the program.
2. Enter commands to add a recipe, display all recipes, scale a recipe, reset quantities, or exit.
3. When adding a recipe, enter the name, ingredients, and steps, when you are done entering the ingredients and steps run name of ingredients without entering any value and the menu option will then pop up.
4. Option to scale a recipe allows entering the name of the recipe and a scaling factor.
5. Option to reset quantities allows entering the name of the recipe to reset.
6. Recipes are displayed with ingredients, total calories, and steps.

Note:
- The application includes error handling for invalid commands and input validation for food groups.
- Users can add multiple recipes and manage them accordingly.

This application provides a basic framework for managing recipes and can be expanded with additional features and functionalities as needed.
