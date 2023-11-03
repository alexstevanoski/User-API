addEventListener('DOMContentLoaded', onloadCb);

function onloadCb() {
    const forms = document.querySelectorAll('form[method]');

    forms.forEach(function (form) {
        form.addEventListener('submit', displayInfo);
    });
};

function displayInfo(event) {
    event.preventDefault()

    const formData = new FormData(event.target);

    logAsTitle('Data:');
    for (let [key, val] of formData.entries()) {
        console.log(`${key} \t ${val || '<Empty>'}`);
    }

    logAsTitle('Form attributes');
    const neededAttributes = ['action', 'method', 'enctype'];
    for (let attr of neededAttributes) {
        console.log(`${attr} - ${event.target[[attr]] || '<empty>'}`);
    }
}
function logAsTitle(str) {
    console.log('\n' + str);
    console.log('='.repeat(str.length));
}