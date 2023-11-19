document.addEventListener("DOMContentLoaded", function () {
    var mailAlert = document.getElementById("mailAlert");

    if (mailAlert) {
        setTimeout(() => {
            mailAlert.style.display = 'none';
        }, 4000);
    }
});