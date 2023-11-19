function isValidEmail(email) {
    // Regular expression for basic email validation
    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
}
function submitEmail() {
    // Get the email value
    var userEmail = $("#userEmail").val();

    // Validating email
    if (!isValidEmail(userEmail)) {
        $("#emailError").text("Invalid email format.");
        return;
    }

    // Perform AJAX request
    $.ajax({
        url: "/Authorization/ResetPassword",
        type: "POST",
        data: { userEmail: userEmail },
        success: function (data) {

            if (data.success) {
                // Success scenario
                $("#forgotPasswordModal").modal('hide'); // Close the modal
                // You can update content or show a success message
            } else {
                // Handle error scenario
                $("#emailError").text(data.error);
            }
        },
        error: function () {
            // Handle AJAX request error
            $("#emailError").text("An error occurred during the request.");
        }
    });
}