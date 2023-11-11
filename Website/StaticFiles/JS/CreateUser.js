addEventListener('DOMContentLoaded', CreateUser());

function CreateUser() {
    const apiUrl = 'https://localhost:7006/api/Person/CreatePerson';
    const form = document.getElementById('form1');

    const data = {
        name: name,
        email: email,
        password: password,
    };

    fetch(apiUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => response.json())
        .then(data => {
            console.log(data);
            SuccessfulUserCreation();
        })
        .catch(error => {
            console.error(error);
        });
}