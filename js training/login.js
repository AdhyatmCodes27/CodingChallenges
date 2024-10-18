
document.getElementById("loginForm").addEventListener("submit", function (e) {
    e.preventDefault();  
    
    let username = document.getElementById("username").value;
    let password = document.getElementById("password").value;
    
    if (username === "" || password === "") {
        displayError("Both fields are required!");
        return;
    }

    saveUserDetails(username, password);
    displayError("");

    alert("Login successful! Welcome, " + username);
    
});

function saveUserDetails(username, password) {
    // Save user details in local storage 
    localStorage.setItem("username", username);
    localStorage.setItem("password", password);  
}

function displayError(message) {
    let errorDiv = document.getElementById("errorMsg");
    errorDiv.textContent = message;
}