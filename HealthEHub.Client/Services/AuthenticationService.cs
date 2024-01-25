using HealthEHub.Client.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using System.Net.Http.Headers;

namespace HealthEHub.Client.Services
{
    public class AuthenticationService(HttpClient httpClient, NavigationManager navigationManager, IJSRuntime jsRuntime)
    {
        public event Action? OnLoginStateChanged;

        public bool IsLoggedIn { get; private set; }

        public async Task Initialize()
        {
            var token = await GetAccessToken();
            if (!string.IsNullOrEmpty(token))
            {
                IsLoggedIn = true;
                await AddTokenToHttpClient();
            }
            else
            {
                IsLoggedIn = false;
            }
            OnLoginStateChanged?.Invoke();
        }

        public async Task AddTokenToHttpClient()
        {
            var token = await GetAccessToken();
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }


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
                var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
                if (tokenResponse != null && tokenResponse.AccessToken != null)
                {
                    await jsRuntime.InvokeVoidAsync("localStorage.setItem", "accessToken", tokenResponse.AccessToken);
                    await jsRuntime.InvokeVoidAsync("localStorage.setItem", "refreshToken", tokenResponse.RefreshToken);
                    IsLoggedIn = true;
                    await AddTokenToHttpClient();
                    OnLoginStateChanged?.Invoke();
                    navigationManager.NavigateTo("/profile");
                }
            }
            else
            {
                IsLoggedIn = false;
                OnLoginStateChanged?.Invoke();
                throw new HttpRequestException("Login failed");
            }
        }

        public async Task Logout()
        {
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "accessToken");
            await jsRuntime.InvokeVoidAsync("localStorage.removeItem", "refreshToken");
            IsLoggedIn = false;
            OnLoginStateChanged?.Invoke();
        }

        public async Task<string?> GetAccessToken()
        {
            return await jsRuntime.InvokeAsync<string>("localStorage.getItem", "accessToken");
        }

        public async Task CheckAuthorization()
        {
            try
            {
                var accessToken = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "accessToken");
                var refreshToken = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "refreshToken");

                if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
                {
                    await Logout();
                    return;
                }

                var response = await httpClient.GetAsync("/check-authorization");

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Logout();
                }
            }
            catch (HttpRequestException)
            {
                await Logout();
            }
        }

    }

    public class TokenResponse
    {
        public string? TokenType { get; set; }
        public string? AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
    }

}
