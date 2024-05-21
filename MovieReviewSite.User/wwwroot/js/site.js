// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
@inject IJSRuntime JsRuntime

async function getUserInfo() {
    const token = localStorage.getItem('your_token_key');
    if (token) {
        const payload = await JsRuntime.invokeAsync<string>('decodeToken', token);
        const userInfo = JSON.parse(atob(payload.split('.')[1])); // Decode payload
        console.log(userInfo); // Example usage
    }
}

getUserInfo();

function decodeToken(token) {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace('-', '+').replace(/_/g, '/');
    const payload = decodeURIComponent(atob(base64));
    return JSON.parse(payload);
}
