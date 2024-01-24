using System.Net.Http.Json;
using HealthEHub.Client.Components;
using MudBlazor;
using SharedModels.Models;

namespace HealthEHub.Client.Services
{
    public class WorkoutPlanService(HttpClient http, IDialogService dialogService, ISnackbar snackbar)
    {
        public async Task SelectWorkoutPlanAndAddExercise(Exercise exercise)
        {
            var workoutPlans = await http.GetFromJsonAsync<List<WorkoutPlan>>("/workoutplans");

            if (workoutPlans == null || workoutPlans.Count == 0)
            {
                snackbar.Add("No workout plans available. Please create a plan first.", Severity.Warning);
                return;
            }

            var parameters = new DialogParameters
            {
                ["WorkoutPlans"] = workoutPlans
            };

            var dialog = dialogService.Show<SelectWorkoutPlanDialog>("Select a Workout Plan", parameters);
            var result = await dialog.Result;

            if (!result.Canceled && result.Data is int selectedPlanId)
            {
                await AddExerciseToWorkoutPlan(exercise, selectedPlanId);
            }
        }

        private async Task AddExerciseToWorkoutPlan(Exercise exercise, int workoutPlanId)
        {
            var savedExerciseDto = new SavedExerciseDto
            {
                ExerciseId = exercise.Id,
                Name = exercise.Name,
                WorkoutPlanId = workoutPlanId
            };

            var response = await http.PostAsJsonAsync("/workoutplan/addExercise", savedExerciseDto);

            if (response.IsSuccessStatusCode)
            {
                snackbar.Add("Exercise added to workout plan successfully!", Severity.Success);
            }
            else
            {
                snackbar.Add("This exercise already exists in the selected workout plan.", Severity.Error);
            }
        }
    }
}
