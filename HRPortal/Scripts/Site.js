toastr.options = {
    "closeButton": true,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

$(document).ready(function () {
    $("body").overlayScrollbars({});
    $('[data-toggle="tooltip"]').tooltip();
})

function ChangeLanguagexxx(code)
{
    document.cookie = "_hrportalCulture=" + (code) + "; expires=Fri, 31 Dec 9999 23:59:59 GMT";
    location.reload();
}

function confirmLogout(message, confirmButton, cancelButton, logoutURL) {

    Swal.fire({
        text: message,
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: confirmButton,
        cancelButtonText: cancelButton
    }).then((result) => {
        if (result.value) {
            window.location.href = logoutURL;
        }
    });
}