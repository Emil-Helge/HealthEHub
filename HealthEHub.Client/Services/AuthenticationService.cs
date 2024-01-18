using HealthEHub.Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace HealthEHub.Client.Services
{
    public class AuthenticationService(HttpClient httpClient, NavigationManager navigationManager)
    {
        public event Action? OnLoginStateChanged;

        public bool IsLoggedIn { get; private set; }

        public async Task Register(RegisterRequest registerRequest)
        {
            var response = await httpClient.PostAsJsonAsync("/register", registerRequest);

            if (response.IsSuccessStatusCode)
            {
                navigationManager.NavigateTo("/login");
            }
            else
            {
                throw new HttpRequestException("Registration failed");
            }
        }

        public async Task Login(LoginRequest loginRequest)
        {
            var response = await httpClient.PostAsJsonAsync("/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                IsLoggedIn = true;
                OnLoginStateChanged?.Invoke();
                navigationManager.NavigateTo("/");
            }
            else
            {
                IsLoggedIn = false;
                OnLoginStateChanged?.Invoke();
            }
        }

        public void Logout()
        {
            IsLoggedIn = false;
            OnLoginStateChanged?.Invoke();
            navigationManager.NavigateTo("/login");
        }
    }
}
