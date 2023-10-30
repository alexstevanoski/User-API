const form = document.getElementById('form1')

form.addEventListener('submit', function(e) {
    const payload = new FormData(form)
    console.log([...payload])
    fetch('https://localhost:7006/api/Person/CreatePerson', {
            method: 'POST',
            headers: { 'accept': '*/*','Content-Type': 'application/json' },
            body: payload})
    .then(res => res.json())
    .then(data => console.log(data))
    .catch(error => console.log(error));        

})