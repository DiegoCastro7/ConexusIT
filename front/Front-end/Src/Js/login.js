(function () {
	'use strict'

	// Fetch all the forms we want to apply custom Bootstrap validation styles to
	var forms = document.querySelectorAll('.needs-validation')

	// Loop over them and prevent submission
	Array.prototype.slice.call(forms)
		.forEach(function (form) {
			form.addEventListener('submit', function (event) {
				if (!form.checkValidity()) {
					event.preventDefault()
					event.stopPropagation()
				}

				form.classList.add('was-validated')
			}, false)
		})
})()
document.addEventListener("DOMContentLoaded", function() {
    document.getElementById("login-button").addEventListener("click", function(event) {
        event.preventDefault();
        var email = document.getElementById("email").value;
        var password = document.getElementById("password").value;
        // Crear un objeto con los datos del formulario
        var data = {
            email: email,
            password: password
        };
        const endpointUrl = "http://localhost:5019/user/login";
        // Realizar la solicitud HTTP con los datos del formulario
        fetch(endpointUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(data),
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Contraseña o email incorrecto');
                }
                return response.json();
            })
            .then(data => {
                if (data === true) {
                    window.location.href = "/index.html"; // Redirige si la respuesta es verdadera
                } else {
                    // Manejar el caso en el que la respuesta es falsa
                    console.log("La respuesta del backend no es verdadera");
                }
            })
            .catch(error => {
                // Manejar errores y mostrar mensaje de error
                alert(error.message);
            });
    });
});
